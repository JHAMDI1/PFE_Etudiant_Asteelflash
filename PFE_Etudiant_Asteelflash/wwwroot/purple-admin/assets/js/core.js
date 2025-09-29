// Core JS pour PurpleAdmin
document.addEventListener('DOMContentLoaded', function() {
  console.log('PurpleAdmin template chargé');
  
  // Gestion des formulaires
  const forms = document.querySelectorAll('.forms-sample');
  forms.forEach(form => {
    form.addEventListener('submit', function(e) {
      // Validation de base - vous pouvez étendre selon vos besoins
      const requiredFields = form.querySelectorAll('[required]');
      let isValid = true;
      
      requiredFields.forEach(field => {
        if (!field.value.trim()) {
          isValid = false;
          // Mettre en évidence le champ si vide
          field.classList.add('is-invalid');
        } else {
          field.classList.remove('is-invalid');
        }
      });
      
      if (!isValid) {
        e.preventDefault();
        console.log('Validation du formulaire échouée');
      }
    });
  });
  
  // Animation de chargement (à activer lors des soumissions)
  const submitButtons = document.querySelectorAll('button[type="submit"]');
  submitButtons.forEach(button => {
    button.addEventListener('click', function() {
      if (this.form.checkValidity()) {
        this.classList.add('loading');
      }
    });
  });
});
