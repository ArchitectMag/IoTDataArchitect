//System
using System.ComponentModel.DataAnnotations;

//Projects
using MyIoT.Core.DataAccess.EntityFramework;

namespace MyIoT.Core.Utilities.Security.UserEntity;

public class Role : IEntity
{
    [Key]
    public int Id { get; set; }
    [MaxLength(64)]
    public string Name { get; set; }
}
