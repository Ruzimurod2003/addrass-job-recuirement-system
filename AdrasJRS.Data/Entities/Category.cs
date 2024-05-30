using System.ComponentModel.DataAnnotations;

namespace AdrasJRS.Data.Entities;
public class Category
{
    public int Id { get; set; }
    [Display(Name = "Name")]
    [Required(ErrorMessage = "Bitte geben Sie den Kategorienamen ein")]
    [StringLength(100, ErrorMessage = "Der Kategoriename darf nicht länger als 100 Zeichen sein.")]
    public string Name { get; set; }
    [Display(Name = "Beschreibung")]
    [StringLength(256, ErrorMessage = "Die Beschreibung darf nicht länger als 256 Zeichen sein.")]
    public string Description { get; set; }
    [Required]
    public string Slug { get; set; }
    public bool? Disable { get; set; }
    public ICollection<Skill> Skills { get; set; }
    public ICollection<Title> Titles { get; set; }
    public ICollection<Province> Provinces { get; set; }
    public ICollection<AppUser> AppUsers { get; set; }
}