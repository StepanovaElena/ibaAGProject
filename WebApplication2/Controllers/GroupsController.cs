using System.Collections.Generic;
using BussinesLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer;
using PresentationLayer.Models;

namespace WebApplication2.Controllers
{
    [Authorize]
    [Route("api/groups")]
    [ApiController]
    public class GroupsController : Controller
    {
        private DataManager _datamanager;
        private ServicesManager _servicesmanager;

        public GroupsController(DataManager dataManager)
        {
            _datamanager = dataManager;
            _servicesmanager = new ServicesManager(dataManager);
        }
        
        // GET: api/groups
        [HttpGet]
        public List<GroupModel> Get()
        {
            return _servicesmanager.Groups.GetAllGroups();
        }

        // GET: api/groups/5
        [HttpGet("{id:int}")]
        public GroupModel Get(int id)
        {
            return _servicesmanager.Groups.GetGroupById(id);
        }

        // GET: api/groups/name
        [HttpGet("{name}")]
        public IActionResult Get(string name)
        {
            var group = _servicesmanager.Groups.GetGroupByName(name);
            if (group.Id != 0)
            {
                return Ok(group);
            }
            return new ObjectResult(new List<GroupModel>());
        }

        // POST: api/groups
        [HttpPost]
        public IActionResult Post([FromBody] GroupModel group)
        {
            if (ModelState.IsValid)
            {
                return Ok(_servicesmanager.Groups.GroupCreateOrUpdate(group));
            }
            return BadRequest(ModelState);
        }

        // PUT: api/groups/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] GroupModel group)
        {
            if (ModelState.IsValid)
            {
                return Ok(_servicesmanager.Groups.GroupCreateOrUpdate(group));
            }
            return BadRequest(ModelState);
        }

        // DELETE: api/groups/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_servicesmanager.Groups.GroupDelete(id) == true)
            { 
                return Ok(id);
            }
            return BadRequest(new { errorText = "This group can't be deleted!" });
            
        }
    }
}
