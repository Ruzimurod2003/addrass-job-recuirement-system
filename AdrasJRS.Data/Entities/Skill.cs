using System.ComponentModel.DataAnnotations;

namespace AdrasJRS.Data.Entities;
public class Skill
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Bitte geben Sie den Skill-Namen ein")]
    [StringLength(50, ErrorMessage = "Der Skill-Name darf nicht länger als 50 Zeichen sein.")]
    public string Name { get; set; }
    [Required]
    public string Slug { get; set; }
    [Display(Name = "Skill-Logo")]
    [Required(ErrorMessage = "Bitte geben Sie das Skill-Logo ein")]
    public string Logo { get; set; }
    public Category Category { get; set; }
    [Display(Name = "Kategorie")]
    public int CategoryId { get; set; }
    public bool? Disable { get; set; }
    public virtual ICollection<Job> Jobs { get; set; }
    public int Popular { get; set; }
}