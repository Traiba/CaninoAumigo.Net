using Microsoft.AspNetCore.Mvc;
namespace CaninoAumigo_API.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Inicio()
        {
            return new ContentResult
            {
                ContentType = "text/html",
                Content = "<h1>API CaninoAumigo: funcionou!!!!</h1>"
            };
        }
    }
}