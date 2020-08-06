using Core.DataAccess.EntityFramework;

namespace Entities.ViewModels
{
    public class UserLogin : IViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
