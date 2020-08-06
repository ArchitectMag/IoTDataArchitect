using Core.DataAccess.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace Core.Utilities.Security.UserEntity
{
    public class Role : IEntity
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(64)]
        public string Name { get; set; }
    }
}
