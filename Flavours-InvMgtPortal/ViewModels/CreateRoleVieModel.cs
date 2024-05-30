using System.ComponentModel.DataAnnotations;

namespace Flavours_InvMgtPortal.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
