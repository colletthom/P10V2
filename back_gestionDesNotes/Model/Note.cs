namespace back_gestionDesNotes.Model
{
    public class Note
    {
        public int Id { get; set; }
        public int patId { get; set; }
        public string? patient { get; set; }
        public string? note { get; set; }
    }
}
