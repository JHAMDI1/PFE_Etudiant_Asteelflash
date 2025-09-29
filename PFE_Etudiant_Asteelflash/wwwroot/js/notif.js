/* ------------------------------------------------------------
   notif.js
   Gestion des notifications en temps réel côté client.

   Principales responsabilités :
   • Établir une connexion SignalR avec le hub /notifHub.
   • Recevoir l'événement "ReceiveNotification" et :
       - afficher un toast Toastr
       - mettre à jour le badge non-lu
       - injecter la notification dans le dropdown.
   • Charger les notifications existantes au chargement de la page.
   • Marquer une notification comme lue via l'API REST.
   • Rafraîchir périodiquement le compteur.

   Fonctions clés :
   - initializeSignalR() : construit la connexion SignalR.
   - startConnection()    : lance la connexion (avec retry).
   - showToast()          : affiche un toast Toastr.
   - updateNotificationBadge() : interroge l'API pour le compteur.
   - addNotificationToDropdown() : ajoute un élément dans le menu.
   - loadNotifications()  : récupère toutes les notifications.
   - markAsRead(id)       : appelle l'endpoint POST /read.
   ------------------------------------------------------------ */
// Notification handler using SignalR
(function () {
    // References to DOM elements
    const notifBadge = document.getElementById('notif-badge');
    const notifDropdown = document.getElementById('notif-dropdown');
    
    // Vérifie si la bibliothèque signalR est disponible
    let connection = null;
    let signalRInitialized = false;
    
    // Configuration des gestionnaires d'événements SignalR
    function setupSignalRHandlers() {
        // Connection status management
        connection.onreconnecting(error => {
            console.warn('Reconnecting to notification hub...', error);
        });

        connection.onreconnected(connectionId => {
            console.info('Reconnected to notification hub', connectionId);
        });

        // Handler for receiving notifications
        connection.on("ReceiveNotification", notification => {
            console.log("Notification received:", notification);
            showToast(notification);
            updateNotificationBadge();
            addNotificationToDropdown(notification);
        });
    }
    
    // Initialise SignalR s'il est disponible
    function initializeSignalR() {
        if (typeof signalR !== 'undefined') {
            console.log("SignalR library is loaded, initializing connection");
            try {
                // Initialize SignalR connection
                connection = new signalR.HubConnectionBuilder()
                    .withUrl("/notifHub")
                    .withAutomaticReconnect()
                    .build();
                    
                setupSignalRHandlers();
                signalRInitialized = true;
                return true;
            } catch (error) {
                console.error("Error initializing SignalR:", error);
                return false;
            }
        } else {
            console.warn("SignalR library not loaded yet, will retry");
            return false;
        }
    }

    // Start the connection
    async function startConnection() {
        // Vérifie d'abord si SignalR est disponible
        if (!signalRInitialized) {
            if (!initializeSignalR()) {
                console.log("Trying to load SignalR, will retry in 2 seconds");
                setTimeout(startConnection, 2000);
                return;
            }
        }

        try {
            await connection.start();
            console.log("Connected to notification hub");
            // Load existing notifications
            loadNotifications();
        } catch (err) {
            console.error("Error connecting to hub:", err);
            // Retry connection after 5 seconds
            setTimeout(startConnection, 5000);
        }
    }

    // Show a toast notification
    function showToast(notification) {
        if (typeof toastr !== 'undefined') {
            const link = notification.Link || notification.link || '#';
            const message = notification.Message || notification.message || '';
            const type = notification.Type || notification.type || 'Notification';

            toastr.options = {
                closeButton: true,
                progressBar: true,
                positionClass: "toast-top-right",
                timeOut: 5000
            };
            
            toastr.info(
                `<a href="${link}" class="text-decoration-none">${message}</a>`,
                type
            );
        } else {
            console.warn('Toastr not loaded, notification not shown as toast');
        }
    }

    // Update the notification badge counter
    function updateNotificationBadge() {
        fetch('/api/notifications')
            .then(response => response.json())
            .then(data => {
                const unreadCount = data.filter(n => n.IsRead !== undefined ? !n.IsRead : !n.isRead).length;
                if (notifBadge) {
                    notifBadge.textContent = unreadCount;
                    notifBadge.style.display = unreadCount > 0 ? 'inline-block' : 'none';
                }
            })
            .catch(error => console.error('Error fetching notifications:', error));
    }

    // Add a notification to the dropdown menu
    function addNotificationToDropdown(notification) {
        if (!notifDropdown) return;

        const link = notification.Link || notification.link || '#';
        const message = notification.Message || notification.message || '';
        const createdAtRaw = notification.CreatedAt || notification.createdAt;
        const id = notification.Id || notification.id;

        const item = document.createElement('a');
        item.href = link;
        item.className = 'dropdown-item d-flex align-items-center py-2';
        item.dataset.id = id;

        // Format date to be more readable
        const date = createdAtRaw ? new Date(createdAtRaw) : new Date();
        const formattedDate = date.toLocaleString();

        item.innerHTML = `
            <div class="mr-3">
                <div class="icon-circle bg-primary">
                    <i class="fas fa-bell text-white"></i>
                </div>
            </div>
            <div>
                <div class="small text-gray-500">${formattedDate}</div>
                <span>${message}</span>
            </div>
        `;

        notifDropdown.prepend(item);
        
        // Add click handler to mark as read
        item.addEventListener('click', function() {
            markAsRead(id);
        });
    }

    // Load existing notifications
    function loadNotifications() {
        fetch('/api/notifications')
            .then(response => response.json())
            .then(data => {
                // Clear existing notifications in dropdown
                if (notifDropdown) {
                    notifDropdown.innerHTML = '';
                }
                
                // Add notifications to dropdown
                data.forEach(notification => {
                    addNotificationToDropdown(notification);
                });
                
                // Update badge count
                const unreadCount = data.filter(n => n.IsRead !== undefined ? !n.IsRead : !n.isRead).length;
                if (notifBadge) {
                    notifBadge.textContent = unreadCount;
                    notifBadge.style.display = unreadCount > 0 ? 'inline-block' : 'none';
                }
            })
            .catch(error => console.error('Error loading notifications:', error));
    }

    // Mark a notification as read
    function markAsRead(id) {
        fetch(`/api/notifications/${id}/read`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(() => {
            updateNotificationBadge();
        })
        .catch(error => console.error('Error marking notification as read:', error));
    }

    // Initialize when document is ready
    document.addEventListener('DOMContentLoaded', () => {
        console.log("DOM is ready, initializing notification system");
        
        // Vérifie si la bibliothèque SignalR est déjà chargée
        if (typeof signalR === 'undefined') {
            console.log("SignalR not loaded yet, loading it dynamically");
            // Charger dynamiquement le script SignalR si nécessaire
            const signalRScript = document.createElement('script');
            signalRScript.src = '/lib/microsoft/signalr/dist/browser/signalr.js';
            signalRScript.onload = function() {
                console.log("SignalR loaded successfully");
                initializeSignalR();
                startConnection();
            };
            signalRScript.onerror = function() {
                console.error("Failed to load SignalR library");
                // Quand même charger les notifications existantes
                loadNotifications();
            };
            document.head.appendChild(signalRScript);
        } else {
            console.log("SignalR already loaded");
            initializeSignalR();
            startConnection();
        }
        
        // Charger les notifications existantes immédiatement
        loadNotifications();
        
        // Periodically refresh badge every 60 seconds (optional)
        setInterval(updateNotificationBadge, 60000);
    });
})();
