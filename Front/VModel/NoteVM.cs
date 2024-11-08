namespace Front.VModel
{
    public class NoteVM
    {
        public int id { get; set; }
        public string? patId { get; set; }
        public string? patient { get; set; } = null!;
        public string? note { get; set; } = null!;
    }
}