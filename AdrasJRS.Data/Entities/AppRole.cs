using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AdrasJRS.Data.Entities;
public class AppRole : IdentityRole<Guid>
{
    [Display(Name = "Beschreibung")]
    [StringLength(256, ErrorMessage = "Die Beschreibung darf nicht länger als 256 Zeichen sein.")]
    public string Description { get; set; }
}