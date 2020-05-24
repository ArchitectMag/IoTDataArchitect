using System;

namespace Entities.Models
{
	public class Light
	{
		public DateTime Date { get; set; } = DateTime.Now;

		public int LightSensorValue { get; set; }
	}
}
