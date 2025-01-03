using System.ComponentModel.DataAnnotations;

namespace Front.VModel
{
    public class NoteVM
    {
        public string id { get; set; }

        [Display(Name = "Patient ID")]
        public int patId { get; set; }

        [Display(Name = "Patient Name")]
        public string patient { get; set; }

        [Display(Name = "Note")]
        public string note { get; set; }
    }
}