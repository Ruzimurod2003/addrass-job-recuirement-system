using System.ComponentModel.DataAnnotations;

namespace AdrasJRS.Data.ViewModel;
public class CreateCultureViewModel
{
    [Required(ErrorMessage = "Please enter culture name")]
    [StringLength(100, ErrorMessage = "The culture name cannot be more than 100 characters.")]
    public string Name { get; set; }
}