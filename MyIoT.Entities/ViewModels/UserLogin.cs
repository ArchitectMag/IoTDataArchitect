using MyIoT.Core.DataAccess.EntityFramework;

namespace MyIoT.Entities.ViewModels;

public class UserLogin : IViewModel
{
    public string Email { get; set; }
    public string Password { get; set; }
}
