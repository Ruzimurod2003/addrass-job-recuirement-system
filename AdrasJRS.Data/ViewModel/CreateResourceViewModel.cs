using System.ComponentModel.DataAnnotations;

namespace AdrasJRS.Data.ViewModel;
public class CreateResourceViewModel
{
    [Required(ErrorMessage = "Please enter resource key")]
    public string Key { get; set; }
    [Required(ErrorMessage = "Please enter resource value in English")]
    public string Value_EN { get; set; }
    [Required(ErrorMessage = "Please enter resource value in Russian")]
    public string Value_RU { get; set; }
    [Required(ErrorMessage = "Please enter resource value in Uzbek")]
    public string Value_UZ { get; set; }
    [Required(ErrorMessage = "Please enter resource value in German")]
    public string Value_DE { get; set; }
}