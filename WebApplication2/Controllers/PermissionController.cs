using System.Collections.Generic;
using BussinesLayer;
using DataLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/permissions")]
    public class PermissionController : Controller
    {
        private DataManager _datamanager;

        public PermissionController(DataManager dataManager)
        {
            _datamanager = dataManager;
        }
        
        // GET: api/permissions
        [HttpGet]
        public IEnumerable<Permissions> Get()
        {
            return _datamanager.Permissions.GetAllPermissions();
        }
    }
}