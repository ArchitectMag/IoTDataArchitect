//ystem
using System;
using System.ComponentModel.DataAnnotations;

//Projects
using MyIoT.Core.DataAccess.EntityFramework;

namespace MyIoT.Entities.Models;

public class Light:IEntity
{
	[Key]
	public int Id { get; set; }
	public int LightSensorValue { get; set; }
	public DateTime Date { get; set; } = DateTime.Now;
}
