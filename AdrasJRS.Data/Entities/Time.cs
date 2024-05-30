using System.ComponentModel.DataAnnotations;

namespace AdrasJRS.Data.Entities;
public class Time
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Bitte geben Sie den Typnamen ein")]
    [StringLength(20, ErrorMessage = "Der Typname darf nicht länger als 20 Zeichen sein.")]
    public string Name { get; set; }
    [Required]
    public string Slug { get; set; }
    public bool? Disable { get; set; }
    public ICollection<Job> Jobs { get; set; }
}