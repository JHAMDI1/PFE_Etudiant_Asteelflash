using PFE_Etudiant_Asteelflash.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace PFE_Etudiant_Asteelflash.Infrastucture.Persistence
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<ActD7> ActD7 { get; set; }
        public DbSet<ActionDeSecurisationD3> ActionDeSecurisationD3 { get; set; }
        public DbSet<ActionImmediateGlobale> ActionImmediateGlobale { get; set; }
        public DbSet<AssurerD3> AssurerD3 { get; set; }
        public DbSet<CauseOccurenceD4> CauseOccurenceD4 { get; set; }
        public DbSet<CausesNonDetectionD4> CausesNonDetectionD4 { get; set; }
        public DbSet<ClotureD8> ClotureD8 { get; set; }
        public DbSet<ContenirD3> ContenirD3 { get; set; }
        public DbSet<DescriptionDuProblemeD2> DescriptionDuProblemeD2 { get; set; }
        public DbSet<Equipe> Equipe { get; set; }
        public DbSet<Fnc> Fnc { get; set; }
        public DbSet<ListeDesActionsD3> ListeDesActionsD3 { get; set; }
        public DbSet<PlanActionsCorrectivesD5> PlanActionsCorrectivesD5 { get; set; }
        public DbSet<Qrqc> Qrqc { get; set; }
        public DbSet<QuantitéTriéeParJour> QuantitéTriéeParJour { get; set; }
        public DbSet<Recherche_causes_racinesD4> Recherche_causes_racinesD4 { get; set; }
        public DbSet<Réclamation> Réclamation { get; set; }
        public DbSet<ReparerD3> ReparerD3 { get; set; }
        public DbSet<SuiviD6> SuiviD6 { get; set; }
        public DbSet<TriActionImmediateGlobale> TrieActionImmediateGlobale { get; set; }
        public DbSet<TrierD3> TrierD3 { get; set; }
        public DbSet<Zap> Zap { get; set; }
        public DbSet<Notification> Notification { get; set; }

        // Suivi de tri (QRQC)
        public DbSet<TriFncQrqc> TriFncQrqc { get; set; }
        public DbSet<TriFncQrqcLigne> TriFncQrqcLigne { get; set; }

        // Plan d'actions (QRQC)
        public DbSet<PlanActionFncQrqc> PlanActionFncQrqc { get; set; }
        public DbSet<PlanActionFncQrqcLigne> PlanActionFncQrqcLigne { get; set; }
        public DbSet<UsersZaps> UsersZaps { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Valeur par défaut pour IsActive (true)
            modelBuilder.Entity<ApplicationUser>()
                .Property(u => u.IsActive)
                .HasDefaultValue(true);

            // Désactivation des suppressions en cascade par défaut pour toutes les relations
            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.NoAction;
            }

            // Configuration des relations ClotureD8
            modelBuilder.Entity<ClotureD8>(entity =>
            {
                entity.HasOne(c => c.ChefEquipe)
                    .WithMany(u => u.ClotureD8)
                    .HasForeignKey(c => c.ChefEquipeId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(c => c.RespZap)
                    .WithMany() // Pas de navigation inverse
                    .HasForeignKey(c => c.RespZapId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(c => c.QualitéProd)
                    .WithMany()
                    .HasForeignKey(c => c.QualitéProdId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(c => c.RespQualite)
                    .WithMany()
                    .HasForeignKey(c => c.RespQualiteId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(c => c.RespProd)
                    .WithMany()
                    .HasForeignKey(c => c.RespProdId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            // Correction relation Qrqc-FNC
            modelBuilder.Entity<Qrqc>()
                .HasOne(q => q.FNC)
                .WithOne(f => f.Qrqc)
                .HasForeignKey<Qrqc>(q => q.FNCId)
                .OnDelete(DeleteBehavior.NoAction);

            // Configuration des relations entre ApplicationUser et Fnc
            modelBuilder.Entity<Fnc>()
                .HasOne(f => f.Transmitter)
                .WithMany()
                .HasForeignKey(f => f.TransmitterID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Fnc>()
                .HasOne(f => f.Processor)
                .WithMany()
                .HasForeignKey(f => f.ProcessorID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Fnc>()
                .Property(f => f.Status);

            modelBuilder.Entity<Fnc>()
                .Property(f => f.TypeDefaut);

            modelBuilder.Entity<Fnc>()
                .Property(f => f.TypeFnc);

            modelBuilder.Entity<Fnc>()
                .Property(f => f.NcImpact);

            // Configuration explicite des relations Fnc <-> Zap
            modelBuilder.Entity<Fnc>()
                .HasOne(f => f.ZapEmettrice)
                .WithMany(z => z.FncsEmettrices)
                .HasForeignKey(f => f.ZapEmettriceId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Fnc>()
                .HasOne(f => f.ZapReceptrice)
                .WithMany(z => z.FncsReceptrices)
                .HasForeignKey(f => f.ZapReceptriceId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Fnc>()
                .Property(f => f.actionImmediate);

            // Configuration des relations pour Equipe
            modelBuilder.Entity<Equipe>()
                .HasOne(e => e.applicationUser)
                .WithMany(u => u.Equipe)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Equipe>()
                .HasOne(e => e.Qrqc)
                .WithMany(q => q.Equipe)
                .HasForeignKey(e => e.QrqcId)
                .OnDelete(DeleteBehavior.NoAction);

            // Configuration UsersZaps (many-to-many ApplicationUser <-> Zap)
            modelBuilder.Entity<UsersZaps>()
                .HasKey(uz => new { uz.UserId, uz.ZapId });

            modelBuilder.Entity<UsersZaps>()
                .HasOne(uz => uz.User)
                .WithMany(u => u.UsersZaps)
                .HasForeignKey(uz => uz.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UsersZaps>()
                .HasOne(uz => uz.Zap)
                .WithMany(z => z.UsersZaps)
                .HasForeignKey(uz => uz.ZapId)
                .OnDelete(DeleteBehavior.NoAction);

            // Configuration pour les relations avec Qrqc
            modelBuilder.Entity<CausesNonDetectionD4>()
                .HasOne(c => c.Qrqc)
                .WithOne(q => q.CausesNonDetectionD4)
                .HasForeignKey<CausesNonDetectionD4>(c => c.QrqcId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CauseOccurenceD4>()
                .HasOne(c => c.Qrqc)
                .WithOne(q => q.CauseOccurenceD4)
                .HasForeignKey<CauseOccurenceD4>(c => c.QrqcId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<SuiviD6>()
                .HasOne(s => s.Qrqc)
                .WithOne(q => q.Suivi)
                .HasForeignKey<SuiviD6>(s => s.QrqcId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ActD7>()
                .HasOne(a => a.Qrqc)
                .WithOne(q => q.Act)
                .HasForeignKey<ActD7>(a => a.QrqcId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PlanActionsCorrectivesD5>()
                .HasOne(p => p.Qrqc)
                .WithOne(q => q.planActionsCorrectives)
                .HasForeignKey<PlanActionsCorrectivesD5>(p => p.QrqcId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuration de la relation 1-à-1 Qrqc <-> Recherche_causes_racinesD4
            modelBuilder.Entity<Recherche_causes_racinesD4>()
                .HasOne(r => r.Qrqc)
                .WithOne(q => q.Recherche_causes_racinesD4)
                .HasForeignKey<Recherche_causes_racinesD4>(r => r.QrqcId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);

            // Assurer unicité de QrqcId lorsqu'il est renseigné (NULL autorisé en doublon)
            modelBuilder.Entity<Recherche_causes_racinesD4>()
                .HasIndex(r => r.QrqcId)
                .IsUnique()
                .HasFilter("[QrqcId] IS NOT NULL");

            // Configuration explicite de la relation 1-à-1 TriActionImmediateGlobale <-> QuantitéTriéeParJour
            modelBuilder.Entity<TriActionImmediateGlobale>()
                .HasOne(t => t.QuantitéTriéeParJour)
                .WithOne(q => q.trieActionImmediateGlobale)
                .HasForeignKey<QuantitéTriéeParJour>(q => q.TriActionImmédiateGlobaleId)
                .OnDelete(DeleteBehavior.NoAction);

            // Configuration relation Fnc <-> TriFnc (1-à-1)
            modelBuilder.Entity<TriFncQrqc>()
                .HasOne(t => t.Fnc)
                .WithOne(f => f.TriFnc)
                .HasForeignKey<TriFncQrqc>(t => t.FncId)
                .OnDelete(DeleteBehavior.NoAction);

            // Configuration relation Fnc <-> PlanActionFnc (1-à-1)
            modelBuilder.Entity<PlanActionFncQrqc>()
                .HasOne(p => p.Fnc)
                .WithOne(f => f.PlanActionFnc)
                .HasForeignKey<PlanActionFncQrqc>(p => p.FncId)
                .OnDelete(DeleteBehavior.NoAction);

            // Configurer le cascade delete pour toutes les entités dépendant de Qrqc
            foreach (var fk in modelBuilder.Model.GetEntityTypes()
                     .SelectMany(e => e.GetForeignKeys()))
            {
                if (fk.PrincipalEntityType.ClrType == typeof(Qrqc))
                {
                    fk.DeleteBehavior = DeleteBehavior.Cascade;
                }
            }
        }
    }
}
