using System.ComponentModel.DataAnnotations;

namespace AdrasJRS.Data.Entities;
public class Blog
{
    public int Id { get; set; }
    public string Slug { get; set; }
    [Display(Name = "Autorin")]
    [StringLength(50, ErrorMessage = "Der Autor darf nicht mehr als 100 Zeichen umfassen.")]
    [Required(ErrorMessage = "Bitte geben Sie den Namen des Autors ein.")]
    public string Author { get; set; }
    [Display(Name = "Titel")]
    [StringLength(100, ErrorMessage = "Der Titel darf nicht länger als 100 Zeichen sein.")]
    [Required(ErrorMessage = "Bitte geben Sie den Titel des Blogs ein.")]
    public string Title { get; set; }
    [Display(Name = "Inhalt")]
    [Required(ErrorMessage = "Bitte geben Sie den Inhalt des Blogs ein.")]
    public string Content { get; set; }
    [Display(Name = "Bild")]
    [Required(ErrorMessage = "Bitte geben Sie ein Bild des Blogs ein")]
    public string Image { get; set; }
    public Guid? AppUserId { set; get; }
    public AppUser AppUser { get; set; }
    public DateTime CreateDate { set; get; }
    [Display(Name = "Blogübersicht")]
    public string Description { get; set; }
    public int Popular { get; set; }
}