using Microsoft.AspNetCore.Mvc;
using Prometheus;
using PrometheusDemo.CustomMetrics;

namespace PrometheusDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomNumberController : ControllerBase
    {
        private static readonly Random _random = new();

        [HttpGet]
        public IActionResult Get()
        {
            var timer = RandomNumberMetrics.RandomNumberDuration.NewTimer();
            
            var number = GenerateRandomNumber();
            
            timer.ObserveDuration();

            return Ok(number);
        }

        private static int GenerateRandomNumber()
        {
            int number = _random.Next(1, 11);

            PerformNumberCheck(number);

            RandomNumberMetrics.DigitCount.Inc();

            return number;
        }

        private static void PerformNumberCheck(int number)
        {
            if (number % 2 == 0)
            {
                RandomNumberMetrics.EvenNumberCount.Inc();
            }
            else
            {
                if (number == 7)
                {
                    RandomNumberMetrics.SevenDigitCount.Inc();
                }
                RandomNumberMetrics.OddNumberCount.Inc();
            }
        }
    }
}
