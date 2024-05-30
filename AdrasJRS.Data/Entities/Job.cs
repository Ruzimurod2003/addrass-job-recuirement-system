using System.ComponentModel.DataAnnotations;

namespace AdrasJRS.Data.Entities;
public class Job
{
    public int Id { get; set; }
    [Display(Name = "Name")]
    [Required(ErrorMessage = "Bitte geben Sie den Produktnamen ein.")]
    [StringLength(100, ErrorMessage = "Der Auftragsname darf nicht länger als 100 Zeichen sein.")]
    public string Name { get; set; }
    [Required]
    public string Slug { get; set; }
    public Category Category { get; set; }
    [Display(Name = "Kategorie")]
    public int? CategoryId { get; set; }
    public Title Title { get; set; }
    [Display(Name = "Titel")]
    public int TitleId { get; set; }
    [Display(Name = "Beschreibung")]
    public string Description { get; set; }
    [Display(Name = "Einführen")]
    public string Introduce { get; set; }
    [Display(Name = "Objektziel")]
    public string ObjectTarget { get; set; }
    [Display(Name = "Arbeitserfahrung")]
    public string Experience { get; set; }
    [Display(Name = "Erstellungsdatum")]
    public DateTime? CreateDate { get; set; }
    public int Popular { get; set; }
    public Province Province { get; set; }
    [Display(Name = "Provinz")]
    public int ProvinceId { get; set; }
    public Time Time { get; set; }
    [Display(Name = "Arbeitstyp")]
    public int TimeId { get; set; }
    [Display(Name = "Mindestgehalt")]
    [Range(0, int.MaxValue, ErrorMessage = "Bitte geben Sie ein gültiges Gehalt ein.")]
    public int? MinSalary { get; set; }
    [Display(Name = "Max salary")]
    [Range(1, int.MaxValue, ErrorMessage = "Bitte geben Sie ein gültiges Gehalt ein.")]
    //[SalaryRange("MinSalary")] //Salary Range Validation Attribute
    public int? MaxSalary { get; set; }
    public AppUser AppUser { get; set; }
    [Display(Name = "Arbeitgeberin")]
    public Guid AppUserId { get; set; }
    public virtual ICollection<Skill> Skills { get; set; }
    public ICollection<CV> CVs { get; set; }
}