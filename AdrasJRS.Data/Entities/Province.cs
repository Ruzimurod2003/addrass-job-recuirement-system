using System.ComponentModel.DataAnnotations;

namespace AdrasJRS.Data.Entities;
public class Province
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Bitte geben Sie den Provinznamen ein")]
    [StringLength(50, ErrorMessage = "Der Provinzname darf nicht länger als 50 Zeichen sein.")]
    public string Name { get; set; }
    [Required]
    public string Slug { get; set; }
    public Category Category { get; set; }
    [Display(Name = "Kategorie")]
    public int CategoryId { get; set; }
    public bool? Disable { get; set; }
    public ICollection<Job> Jobs { get; set; }
    public int Popular { get; set; }
}