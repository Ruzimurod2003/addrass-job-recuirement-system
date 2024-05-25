using System.ComponentModel.DataAnnotations;

namespace AdrasJRS.Data.ViewModel;
public class UserRolesViewModel
{
    public Guid RoleId { get; set; }
    [Display(Name = "Role")]
    public string RoleName { get; set; }
    public bool IsSelected { get; set; }
}