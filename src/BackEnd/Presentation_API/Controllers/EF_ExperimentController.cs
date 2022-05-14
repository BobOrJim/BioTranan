using Infrastructure.EF_experiment;
using Microsoft.AspNetCore.Mvc;

namespace Presentation_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EF_ExperimentController : ControllerBase
    {
        private readonly GradesDbContext _gradesDbContext;

        public EF_ExperimentController(GradesDbContext gradesDbContext)
        {
            _gradesDbContext = gradesDbContext;
        }

 
        [HttpGet(Name = "GetWeatherForecast")]
        public string Get()
        {
            RunStuff runStuff = new(_gradesDbContext);
            runStuff.Run2();
            return "Run()X i RunStuff har körts";
        }
    }
}