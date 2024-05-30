using System.ComponentModel.DataAnnotations;

namespace AdrasJRS.Data.Entities;
public class Title
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Bitte geben Sie den Titelnamen ein")]
    [StringLength(100, ErrorMessage = "Der Titelname darf nicht länger als 100 Zeichen sein.")]
    public string Name { get; set; }
    public Category Category { get; set; }
    [Display(Name = "Kategorie")]
    public int CategoryId { get; set; }
    public bool? Disable { get; set; }
    [Required]
    public string Slug { get; set; }
    public ICollection<Job> Jobs { get; set; }
    public int Popular { get; set; }
}