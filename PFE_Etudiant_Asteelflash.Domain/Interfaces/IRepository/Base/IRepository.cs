namespace PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository.Base
{
    public interface IRepository<TEntity> where TEntity : class
    {
        // Ajoute une nouvelle entit� � la base de donn�es
        Task<TEntity> AddAsync(TEntity entity);

        // R�cup�re une entit� par son identifiant unique
        Task<TEntity> GetByIdAsync(int id);

        // R�cup�re toutes les entit�s de ce type
        Task<IEnumerable<TEntity>> GetAllAsync();

        // Met � jour une entit� existante
        Task Update(TEntity entity);

        // Supprime une entit� de la base de donn�es
        Task Remove(TEntity entity);

        // Sauvegarde les changements dans la base de donn�es et retourne le nombre d'enregistrements affect�s
        Task<int> SaveChangesAsync();
    }
}
