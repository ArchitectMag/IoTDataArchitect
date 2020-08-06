using Core.DataAccess.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace Core.Utilities.Security.UserEntity
{
    public class UserRole : IEntity
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
