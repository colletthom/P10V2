namespace Front.VModel
{
    public class PatientVM
    {
        public int Id { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public DateTime DateNaissance { get; set; }
        public char Genre { get; set; }
        public string? AdressePostale { get; set; }
        public string? Telephone { get; set; }
    }
}
