//System
using System.ComponentModel.DataAnnotations;

//Projects
using MyIoT.Core.DataAccess.EntityFramework;

namespace MyIoT.Core.Utilities.Security.UserEntity;

public class User : IEntity
{
    [Key]
    public int Id { get; set; }
    [MaxLength(64)]
    public string FistName { get; set; }
    [MaxLength(64)]
    public string LastName { get; set; }
    [MaxLength(256)]
    public string Email { get; set; }
    [MaxLength(512)]
    public byte[] PasswordSalt { get; set; }
    [MaxLength(512)]
    public byte[] PasswordHash { get; set; }
    public string RefreshToken { get; set; }
    public DateTime? RefreshTokenEndDate { get; set; }
    public bool Status { get; set; }
}
