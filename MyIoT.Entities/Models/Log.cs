//System
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//Projects
using MyIoT.Core.DataAccess.EntityFramework;

namespace MyIoT.Entities.Models;

[Table("Logs")]
public class Log:IEntity
{
    [Key]
    public int Id { get; set; }
    [MaxLength(Int32.MaxValue)]
    public string Detail { get; set; }
    [MaxLength(64)]
    public string Audit { get; set; }
    public DateOnly CreateDate { get; set; }
}

