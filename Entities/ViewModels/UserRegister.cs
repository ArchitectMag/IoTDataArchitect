using Core.DataAccess.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace Entities.ViewModels
{
    public class UserRegister : IViewModel
    {
        [MaxLength(64)]
        public string FirstName { get; set; }
        [MaxLength(64)]
        public string LastName { get; set; }
        [MaxLength(256)]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
