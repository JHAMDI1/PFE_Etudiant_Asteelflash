namespace PFE_Etudiant_Asteelflash.Application.Day4.Recherche_causes_racinesD4.Dtos
{
    // DTO de consultation pour la recherche des causes racines (Day4)
    public class RechercheCausesRacinesD4Dto
    {
        public int Id { get; set; }
        public string Action { get; set; }
        public string OD { get; set; }
        public string PiloteID { get; set; }
        public DateOnly DatePrevue { get; set; }
        public DateOnly DateReelle { get; set; }
        public string Evolution { get; set; }
    }
}
