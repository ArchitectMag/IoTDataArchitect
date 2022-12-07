//ystem
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//Projects
using MyIoT.Core.DataAccess.EntityFramework;

namespace MyIoT.Entities.Models;

[Table("Lights")]
public class Light:IEntity
{
	[Key]
	public int Id { get; set; }
	public int LightSensorValue { get; set; }
	public DateTime Date { get; set; } = DateTime.Now;
}
