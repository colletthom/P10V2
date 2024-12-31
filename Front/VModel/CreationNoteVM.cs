using System.ComponentModel.DataAnnotations;

namespace Front.VModel;

public class CreationNoteVM
{
    public int? patId { get; set; }

    public string? patient { get; set; }

    public string? note { get; set; }
}
