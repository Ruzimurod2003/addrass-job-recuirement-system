using System.ComponentModel.DataAnnotations;

namespace AdrasJRS.Data.ViewModel;
public class UpdateSkillViewModel
{
    [Required(ErrorMessage = "Please enter skill name")]
    [StringLength(50, ErrorMessage = "The skill name cannot be more than 50 characters.")]
    public string Name { get; set; }
}