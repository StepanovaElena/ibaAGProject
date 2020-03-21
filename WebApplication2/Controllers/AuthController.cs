using BussinesLayer;
using DataLayer.Entity;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private DataManager _datamanager;
        private ServicesManager _servicesmanager;

        public AuthController(DataManager dataManager)
        {
            _datamanager = dataManager;
            _servicesmanager = new ServicesManager(dataManager);
        }

        [HttpPost("token")]
        public IActionResult Token([FromBody] Users user)
        {
            var identity = _servicesmanager.Auth.GetIdentity(user.Email, user.Password);

            if (identity == null)
            {
                return BadRequest(new { errorText = "Invalid username or password." });
            }

            return Json(_servicesmanager.Auth.GetToken(identity));
        }        
    }
}