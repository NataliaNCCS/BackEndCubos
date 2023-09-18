using BackEndCubos.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackEndCubos.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PersonController : Controller
    {
        private readonly IApplicationServicePerson applicationServicePerson;
        public PersonController(IApplicationServicePerson applicationServicePerson)
        {
            this.applicationServicePerson = applicationServicePerson;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Teste()
        {
            return Ok();
        }

    }
}
