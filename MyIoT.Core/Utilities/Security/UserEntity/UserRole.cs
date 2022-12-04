//System
using System.ComponentModel.DataAnnotations;

//Projects
using MyIoT.Core.DataAccess.EntityFramework;

namespace MyIoT.Core.Utilities.Security.UserEntity;

public class UserRole : IEntity
{
    [Key]
    public int Id { get; set; }
    public int UserId { get; set; }
    public int RoleId { get; set; }
}
