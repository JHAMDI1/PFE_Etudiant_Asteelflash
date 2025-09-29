using PFE_Etudiant_Asteelflash.Domain.Enums;

namespace PFE_Etudiant_Asteelflash.Domain.Entities
{
    public class Zap
    {
        public int Id { get; set; }
        public zapName Name { get; set; }
        public int nbre_de_lignes { get; set; }

        public ICollection<UsersZaps> UsersZaps { get; set; } = new List<UsersZaps>();
        // FNC où cette ZAP est émettrice
        public ICollection<Fnc> FncsEmettrices { get; set; } = new List<Fnc>();

        // FNC où cette ZAP est receptrice
        public ICollection<Fnc> FncsReceptrices { get; set; } = new List<Fnc>();
    }
}
