using System.ComponentModel.DataAnnotations;

namespace Front.VModel
{
    public class NoteVM
    {
        public int id { get; set; }

        [Display(Name = "Patient ID")]
        public string? patId { get; set; }

        [Display(Name = "Patient Name")]
        public string? patient { get; set; } = null!;

        [Display(Name = "Note")]
        public string? note { get; set; } = null!;
    }
}