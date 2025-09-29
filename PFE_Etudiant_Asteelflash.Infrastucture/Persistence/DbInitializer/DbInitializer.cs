using PFE_Etudiant_Asteelflash.Domain.Entities;
using PFE_Etudiant_Asteelflash.Domain.Enums;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFE_Etudiant_Asteelflash.Infrastucture.Persistence.DbInitializer
{
    public static class DbInitializer
    {
        public static async Task InitializeAsync(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            await SeedDataAsync(serviceScope.ServiceProvider);
        }

        private static async Task SeedDataAsync(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            // S'assurer que la base de données est créée
            context.Database.EnsureCreated();

            // Créer les rôles s'ils n'existent pas
            var roleNames = Enum.GetNames(typeof(Fonction)).ToList();
            roleNames.Add("Admin");
            // Rôles spécifiques QRQC
            roleNames.Add("Responsable_ZAP");
            roleNames.Add("ChefEquipe_ZAP");
            foreach (var roleName in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // On ne retourne plus ici ; la création d'utilisateurs et de ZAPs doit toujours être vérifiée.
            // La génération de FNCs de test reste conditionnée plus bas par !context.Fnc.Any()
            if (context.Fnc.Any())
            {
                // ...
            }

            // Créer les ZAPs s'ils n'existent pas
            if (!context.Zap.Any())
            {
                var zaps = new List<Zap>
                {
                    new Zap { Name = zapName.CMS, nbre_de_lignes = 3 },
                    new Zap { Name = zapName.VAGUE, nbre_de_lignes = 2 },
                    new Zap { Name = zapName.INTEGRATION, nbre_de_lignes = 4 },
                    new Zap { Name = zapName.PREPARATION, nbre_de_lignes = 2 }
                };

                context.Zap.AddRange(zaps);
                await context.SaveChangesAsync();
                Console.WriteLine("ZAPs créés avec succès.");
            }

            // Créer des utilisateurs si nécessaire
            var users = new List<ApplicationUser>();
            if (!userManager.Users.Any())
            {
                // Créer des utilisateurs pour chaque ZAP et chaque fonction (2 par combinaison)
                var usersToCreate = new List<(ApplicationUser User, string Password)>();

                // Obtenir tous les ZAPs de la base de données
                var zaps = context.Zap.ToList();

                // Liste des fonctions
                var fonctions = new[]
                {
                    Fonction.Conducteur,
                    Fonction.Chef_Equipe,
                    Fonction.Opérateur,
                    Fonction.Technicien,
                    Fonction.Controleur,
                    Fonction.Responsable,
                    Fonction.Ingenieur
                };

                // Créer 2 utilisateurs pour chaque combinaison ZAP/Fonction
                foreach (var zap in zaps)
                {
                    string zapNameStr = zap.Name.ToString();

                    foreach (var fonction in fonctions)
                    {
                        // Pour les ZAPs autres que CMS, on exclut Conducteur et Controleur
                        if (zap.Name != zapName.CMS && (fonction == Fonction.Conducteur || fonction == Fonction.Controleur))
                            continue;
                        string fonctionName = fonction.ToString();

                        // Premier utilisateur pour cette combinaison
                        usersToCreate.Add((new ApplicationUser
                        {
                            UserName = $"{fonctionName.ToLower()}1.{zapNameStr.ToLower()}@asteelflash.com",
                            Email = $"{fonctionName.ToLower()}1.{zapNameStr.ToLower()}@asteelflash.com",
                            FirstName = $"{fonctionName}1",
                            LastName = zapNameStr,
                            Matricule = $"{fonctionName.Substring(0, 3).ToUpper()}{zapNameStr.Substring(0, 1)}001",
                            Gender = Gender.Homme,  // Par défaut
                            Fonction = fonction,
                            UsersZaps = new List<UsersZaps> { new UsersZaps { ZapId = zap.Id } },
                            EmailConfirmed = true,
                            ProfileImagePath = "/images/profiles/Default.jpg"
                        }, "Password1!"));

                        // Deuxième utilisateur pour cette combinaison
                        usersToCreate.Add((new ApplicationUser
                        {
                            UserName = $"{fonctionName.ToLower()}2.{zapNameStr.ToLower()}@asteelflash.com",
                            Email = $"{fonctionName.ToLower()}2.{zapNameStr.ToLower()}@asteelflash.com",
                            FirstName = $"{fonctionName}2",
                            LastName = zapNameStr,
                            Matricule = $"{fonctionName.Substring(0, 3).ToUpper()}{zapNameStr.Substring(0, 1)}002",
                            Gender = Gender.Femme,  // Par défaut, alternance pour diversité
                            Fonction = fonction,
                            UsersZaps = new List<UsersZaps> { new UsersZaps { ZapId = zap.Id } },
                            EmailConfirmed = true,
                            ProfileImagePath = "/images/profiles/default.png"
                        }, "Password1!"));
                    }
                }

                // Ajouter un utilisateur admin
                usersToCreate.Add((new ApplicationUser
                {
                    UserName = "admin@asteelflash.com",
                    Email = "admin@asteelflash.com",
                    FirstName = "Admin",
                    LastName = "System",
                    Matricule = "ADMIN001",
            ProfileImagePath = "/adminImage.png",
                    Gender = Gender.Homme,
                    Fonction = Fonction.Responsable,
                    UsersZaps = new List<UsersZaps> { new UsersZaps { ZapId = 1 } }, // CMS par défaut
                    EmailConfirmed = true
                }, "Admin1234!"));

                Console.WriteLine($"Création de {usersToCreate.Count} utilisateurs...");
                foreach (var (user, password) in usersToCreate)
                {
                    var result = await userManager.CreateAsync(user, password);
                    if (result.Succeeded)
                    {
                        // Assigner le rôle Admin à l'utilisateur système
                        if (user.Matricule == "ADMIN001")
                        {
                            await userManager.AddToRoleAsync(user, "Admin");
                        }
                        // marquer email confirmé et image par défaut
                        user.EmailConfirmed = true;
                        if (string.IsNullOrEmpty(user.ProfileImagePath))
                            user.ProfileImagePath = "/images/profiles/default.png";
                        await userManager.UpdateAsync(user);
                        // Assigner le rôle correspondant à la fonction
                        if (user.Fonction == Fonction.Responsable && !await userManager.IsInRoleAsync(user, "Responsable_ZAP"))
                        {
                            await userManager.AddToRoleAsync(user, "Responsable_ZAP");
                        }
                        else if (user.Fonction == Fonction.Chef_Equipe && !await userManager.IsInRoleAsync(user, "ChefEquipe_ZAP"))
                        {
                            await userManager.AddToRoleAsync(user, "ChefEquipe_ZAP");
                        }
                        users.Add(user);
                    }
                    else
                    {
                        Console.WriteLine($"Échec de création de l'utilisateur {user.UserName}: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                    }
                }
            }
            else
            {
                // Utiliser les utilisateurs existants
                users = userManager.Users.ToList();
                // s'assurer que tous ont EmailConfirmed et image par défaut
                foreach (var u in users)
                {
                    bool changed = false;
                    // S'assurer que l'admin possède le rôle Admin
                    if (u.Matricule == "ADMIN001" && !await userManager.IsInRoleAsync(u, "Admin"))
                    {
                        await userManager.AddToRoleAsync(u, "Admin");
                    }
                    // S'assurer que les rôles spécifiques QRQC sont bien assignés
                    if (u.Fonction == Fonction.Responsable && !await userManager.IsInRoleAsync(u, "Responsable_ZAP"))
                    {
                        await userManager.AddToRoleAsync(u, "Responsable_ZAP");
                        changed = true;
                    }
                    else if (u.Fonction == Fonction.Chef_Equipe && !await userManager.IsInRoleAsync(u, "ChefEquipe_ZAP"))
                    {
                        await userManager.AddToRoleAsync(u, "ChefEquipe_ZAP");
                        changed = true;
                    }

                    if (!u.IsActive)
                    {
                        u.IsActive = true;
                        changed = true;
                    }
                    if (!u.EmailConfirmed)
                    {
                        u.EmailConfirmed = true;
                        changed = true;
                    }
                    if (u.Matricule == "ADMIN001")
                    {
                        if (u.ProfileImagePath != "/adminImage.png")
                        {
                            u.ProfileImagePath = "/adminImage.png";
                            changed = true;
                        }
                    }
                    if (string.IsNullOrEmpty(u.ProfileImagePath))
                    {
                        u.ProfileImagePath = "/images/profiles/default.png";
                        changed = true;
                    }
                    if (changed)
                    {
                        await userManager.UpdateAsync(u);
                    }
                }
            }

            // Créer 20 FNCs pour tester avec différents utilisateurs et différents ZAPs
            if (!context.Fnc.Any())
            {
                // S'assurer qu'il y a des utilisateurs
                if (users.Count < 4)
                    throw new InvalidOperationException("Au moins quatre utilisateurs sont nécessaires pour créer des FNCs de test");

                // Récupérer les utilisateurs par ZAP pour une meilleure distribution
                var usersByZap = users
                    .SelectMany(u => u.UsersZaps.Select(uz => new { uz.ZapId, User = u }))
                    .GroupBy(x => x.ZapId)
                    .ToDictionary(g => g.Key, g => g.Select(x => x.User).ToList());

                var statuses = new[] { StatusFNC.ouvert, StatusFNC.en_cours, StatusFNC.fermé, StatusFNC.annulé };
                var clients = new[] { "Renault", "Peugeot", "Citroën", "Toyota", "BMW", "Mercedes", "Ford" };
                var locations = new[] { "Ligne 1", "Ligne 2", "Réception", "Contrôle final", "Logistique", "Zone test" };
                var descriptions = new[]
                {
                    "Défaut d'assemblage sur connecteur principal",
                    "Absence de gaine de protection",
                    "Marquage incorrect sur câble",
                    "Non-conformité des dimensions",
                    "Défaut de sertissage",
                    "Problème d'isolation du câble",
                    "Court-circuit détecté"
                };

                var fncs = new List<Fnc>();
                var random = new Random();

                // Nombre total de FNCs à créer
                int totalFncs = 20;

                // Créer des FNCs internes (même ZAP que l'utilisateur créateur)
                for (int i = 1; i <= totalFncs / 2; i++)
                {
                    // Choisir un ZAP aléatoire
                    var zapId = random.Next(1, 5); // ZapId entre 1 et 4

                    // Sélectionner un utilisateur du même ZAP
                    var usersOfZap = usersByZap[zapId];
                    var transmitter = usersOfZap[random.Next(usersOfZap.Count)];

                    var creationDate = DateTime.Now.AddDays(-random.Next(1, 60));

                    var fnc = new Fnc
                    {
                        Ref = $"FNC-{DateTime.Now.Year}-{i.ToString("D3")}",
                        ZapEmettriceId = zapId,
                        ZapReceptriceId = zapId,
                        TransmitterID = transmitter.Id,
                        Date = creationDate,
                        Hour = new TimeSpan(random.Next(8, 18), random.Next(0, 60), 0),
                        Client_name = clients[random.Next(clients.Length)],
                        Status = statuses[random.Next(statuses.Length)],
                        Detection_loc = locations[random.Next(locations.Length)],
                        Quantity_NOK = random.Next(1, 50),
                        Description = descriptions[random.Next(descriptions.Length)],
                        Enonce_de_la_reclamaion = "Enoncé auto",
                        pour_quoi = "Auto",
                        Bilan_de_tri = random.Next(2) == 1,
                        TypeDefaut = (TypeDefaut)random.Next(5),
                        ImageUrl_Piece_bonne = string.Empty,
                        ImageUrl_Piece_Mauvaise = string.Empty,
                        
                        TypeFnc = TypeFnc.Interne, // FNC interne
                        NcImpact = (NcImpact)random.Next(3),
                        actionImmediate = (ActionImm)random.Next(4),
                    };

                    fncs.Add(fnc);
                }

                // Créer des FNCs externes (ZAP différent de l'utilisateur créateur)
                for (int i = totalFncs / 2 + 1; i <= totalFncs; i++)
                {
                    // Choisir un ZAP destination aléatoire
                    var destZapId = random.Next(1, 5); // ZapId entre 1 et 4

                    // Choisir un ZAP source différent
                    var sourceZapId = random.Next(1, 5);
                    while (sourceZapId == destZapId)
                    {
                        sourceZapId = random.Next(1, 5);
                    }

                    // Sélectionner un utilisateur du ZAP source
                    var usersOfSourceZap = usersByZap[sourceZapId];
                    var transmitter = usersOfSourceZap[random.Next(usersOfSourceZap.Count)];

                    var creationDate = DateTime.Now.AddDays(-random.Next(1, 60));

                    var fnc = new Fnc
                    {
                        Ref = $"FNC-{DateTime.Now.Year}-{i.ToString("D3")}",
                        ZapEmettriceId = sourceZapId, // ZAP source (émettrice)
                        ZapReceptriceId = destZapId, // ZAP destination (réceptrice)
                        TransmitterID = transmitter.Id, // Utilisateur d'un autre ZAP
                        Date = creationDate,
                        Hour = new TimeSpan(random.Next(8, 18), random.Next(0, 60), 0),
                        Client_name = clients[random.Next(clients.Length)],
                        Status = statuses[random.Next(statuses.Length)],
                        Detection_loc = locations[random.Next(locations.Length)],
                        Quantity_NOK = random.Next(1, 50),
                        Description = descriptions[random.Next(descriptions.Length)],
                        Enonce_de_la_reclamaion = "Enoncé auto",
                        pour_quoi = "Auto",
                        Bilan_de_tri = random.Next(2) == 1,
                        TypeDefaut = (TypeDefaut)random.Next(5),
                        ImageUrl_Piece_bonne = string.Empty,
                        ImageUrl_Piece_Mauvaise = string.Empty,
                        
                        TypeFnc = TypeFnc.Externe, // FNC externe
                        NcImpact = (NcImpact)random.Next(3),
                        actionImmediate = (ActionImm)random.Next(4),
                    };

                    fncs.Add(fnc);
                }

                context.Fnc.AddRange(fncs);
                await context.SaveChangesAsync();

                // Créer des notifications de test pour les FNCs
                if (!context.Notification.Any())
                {
                    var notifications = new List<Notification>();
                    var types = new[] { "Nouvelle FNC", "Mise à jour", "Clôturée", "En attente", "Assignée" };
                    // Utiliser le même random que pour les FNCs
                    // Pour chaque utilisateur actif, créer quelques notifications
                    foreach (var user in users.Take(10)) // Limiter à 10 utilisateurs pour les tests
                    {
                        // Créer entre 2 et 5 notifications par utilisateur
                        int notifCount = random.Next(2, 6);

                        for (int i = 0; i < notifCount; i++)
                        {
                            // Choisir une FNC aléatoire
                            var fnc = fncs[random.Next(fncs.Count)];
                            var type = types[random.Next(types.Length)];
                            var isRead = random.Next(2) == 0; // 50% chance d'être lue


                            var notification = new Notification
                            {
                                UserId = user.Id,
                                Type = type,
                                Message = type == "Nouvelle FNC"
                                    ? $"Une nouvelle FNC {fnc.Ref} a été créée dans votre ZAP"
                                    : type == "Mise à jour"
                                        ? $"La FNC {fnc.Ref} a été mise à jour."
                                        : type == "Clôturée"
                                            ? $"La FNC {fnc.Ref} a été clôturée."
                                            : type == "En attente"
                                                ? $"La FNC {fnc.Ref} est en attente de validation."
                                                : $"Vous avez été assigné à la FNC {fnc.Ref}.",
                                Link = $"/Fnc/Details/{fnc.Id}",
                                IsRead = isRead,
                                CreatedAt = DateTime.Now.AddDays(-random.Next(0, 14)).AddHours(-random.Next(0, 24))
                            };


                            notifications.Add(notification);
                        }
                    }

                    context.Notification.AddRange(notifications);
                    await context.SaveChangesAsync();
                    Console.WriteLine($"{notifications.Count} notifications créées avec succès.");
                }
            }
        }
    }
}
