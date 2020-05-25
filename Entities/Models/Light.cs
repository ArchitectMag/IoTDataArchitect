using Core.DataAccess.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
	public class Light:IEntity
	{
		[Key]
		public int Id { get; set; }
		public int LightSensorValue { get; set; }
		public DateTime Date { get; set; } = DateTime.Now;
	}
}
