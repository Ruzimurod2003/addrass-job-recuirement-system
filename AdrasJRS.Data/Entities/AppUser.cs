using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AdrasJRS.Data.Entities;
public class AppUser : IdentityUser<Guid>
{
    //User
    [Display(Name = "Vollständiger Name")]
    [StringLength(100, ErrorMessage = "Der vollständige Name darf nicht länger als 100 Zeichen sein.")]
    public string FullName { get; set; }
    [Display(Name = "Telefon")]
    [StringLength(20, ErrorMessage = "Bitte geben Sie eine gültige Telefonnummer ein.", MinimumLength = 9)]
    public string Phone { get; set; }
    [Display(Name = "Adresse")]
    public string Address { get; set; }
    [Display(Name = "Alter")]
    [Range(0, 100, ErrorMessage = "Bitte geben Sie ein gültiges Alter ein.")]
    public int? Age { get; set; }
    [Display(Name = "Erstellungsdatum")]
    public DateTime? CreateDate { get; set; }
    [Display(Name = "Logo")]
    public string UrlAvatar { get; set; }
    //Employer
    [Display(Name = "Kontakt")]
    public string Contact { get; set; }
    [Display(Name = "Firmenüberblick")]
    public string Description { get; set; }
    [Display(Name = "Webseite")]
    [StringLength(50, ErrorMessage = "Die Website darf nicht mehr als 50 Zeichen umfassen.")]
    public string WebsiteURL { get; set; }
    [Display(Name = "Standort")]
    public string Location { get; set; }
    public ICollection<Job> Jobs { get; set; }
    public int? Status { set; get; } // 0 = denied, 1 = waiting, 2 = confirmed, -1 = admin, null = default
    [Required]
    public string Slug { get; set; }
    public Province Province { get; set; }
    [Display(Name = "Provinz")]
    public int? ProvinceId { get; set; }
    public bool? Disable { get; set; }
    [Display(Name = "Firmengröße")]
    public string CompanySize { get; set; }
    [Display(Name = "Arbeitstage")]
    public string WorkingDays { get; set; }
    public Country Country { get; set; }
    [Display(Name = "Land")]
    public int? CountryId { get; set; }
    [Display(Name = "Inhalt")]
    public string Content { get; set; }
    public int Popular { get; set; }
}