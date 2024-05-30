using System.ComponentModel.DataAnnotations;

namespace AdrasJRS.Data.Entities;
public class CV
{
    public int Id { get; set; }
    [Display(Name = "Zertifikat")]
    [Required(ErrorMessage = "Bitte geben Sie Ihr Zertifikat ein")]
    [StringLength(100, ErrorMessage = "Ihr Zertifikat darf nicht länger als 100 Zeichen sein.")]
    public string Certificate { get; set; }
    [Display(Name = "Wesentlich")]
    [Required(ErrorMessage = "Bitte geben Sie Ihren Studiengang ein")]
    [StringLength(100, ErrorMessage = "Ihr Hauptfach darf nicht länger als 50 Zeichen sein.")]
    public string Major { get; set; }
    public DateTime ApplyDate { get; set; }
    [Display(Name = "Abschluss an der")]
    [Required(ErrorMessage = "Bitte geben Sie Ihren Abschluss ein")]
    [StringLength(100, ErrorMessage = "Ihr Ort darf nicht länger als 50 Zeichen sein.")]
    public string GraduatedAt { get; set; }
    [Display(Name = "Ihr Notendurchschnitt")]
    [Required(ErrorMessage = "Bitte geben Sie Ihren Notendurchschnitt ein")]
    [Range(0, 4, ErrorMessage = "Bitte geben Sie einen gültigen Notendurchschnitt (0–4) ein.")]
    public float GPA { get; set; }
    public Job Job { get; set; }
    [Display(Name = "Arbeit")]
    public int JobId { get; set; }
    [Display(Name = "Beschreibung")]
    [Required(ErrorMessage = "Bitte geben Sie Ihre Beschreibung ein")]
    public string Description { get; set; }
    [Display(Name = "Einführen")]
    [Required(ErrorMessage = "Bitte geben Sie Ihre Einführung ein")]
    public string Introduce { get; set; }
    public AppUser AppUser { get; set; }
    public Guid AppUserId { set; get; }
    public int Status { get; set; } // = 0 denied // = 1 waiting // = 2 accepted // = 3 already feedback // = -1 cancel
    [Display(Name = "Ihr Lebenslauf-Bild")]
    public string UrlImage { get; set; } //CV image
    [Display(Name = "Dein Telefon")]
    [Required(ErrorMessage = "Bitte geben Sie Ihre Telefonnummer ein")]
    [StringLength(20, ErrorMessage = "Bitte geben Sie eine gültige Telefonnummer ein.", MinimumLength = 9)]
    public string Phone { get; set; }
    [Display(Name = "Deine E-Mail")]
    [Required(ErrorMessage = "Bitte geben Sie ihre E-Mail-Adresse ein")]
    [StringLength(50, ErrorMessage = "Ihre E-Mail darf nicht länger als 50 Zeichen sein.")]
    public string Email { get; set; }

    //Feedback
    [Display(Name = "Adresse")]
    public string EmployerAddress { get; set; }
    [Display(Name = "Dein Telefon")]
    [StringLength(20, ErrorMessage = "Bitte geben Sie eine gültige Telefonnummer ein.", MinimumLength = 9)]
    public string EmployerPhone { get; set; }
    [Display(Name = "Kommentar")]
    public string Comment { get; set; }
    [Display(Name = "Bewertungen")]
    [Range(0, 10, ErrorMessage = "Bitte geben Sie eine gültige Bewertung (0-10) ein.")]
    public byte? EmployerRating { get; set; }
    public DateTime? CommentOn { get; set; }
    [Display(Name = "Stadt")]
    [StringLength(30, ErrorMessage = "Die Stadt darf nicht länger als 30 Zeichen sein.")]
    public string City { get; set; }
    [Display(Name = "Email")]
    [StringLength(50, ErrorMessage = "Die E-Mail darf nicht länger als 50 Zeichen sein.")]
    public string EmployerEmail { get; set; }
}