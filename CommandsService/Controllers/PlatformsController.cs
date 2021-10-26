using Microsoft.AspNetCore.Mvc;

namespace CommandsServices.Controllers {

    [Route("api/c/[controller]")]
    [ApiController]
    public class PlatformsController: ControllerBase
    {
        public PlatformsController()
        {
            
        }

        [HttpPost]
        public ActionResult TestInboundConnection()
        {
            Console.WriteLine("--> Inbound POST # Command Service");
            return Ok("Test platform controller ok");
        }
    }
}
