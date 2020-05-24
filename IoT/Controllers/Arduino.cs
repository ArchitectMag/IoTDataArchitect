using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace IoT.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class Arduino : ControllerBase
	{
		private readonly ILogger<Arduino> _logger;

		public Arduino(ILogger<Arduino> logger)
		{
			_logger = logger;
		}

		[HttpGet]
		public async Task DayAndNight(int lightSensorValue)
		{
			Light light = new Light();
			await Task.FromResult(light.LightSensorValue = lightSensorValue);
		}
	}
}
