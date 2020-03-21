using System;
using System.Collections.Generic;
using System.Linq;
using BussinesLayer;
using DataLayer.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer;
using PresentationLayer.Models;

namespace WebApplication2.Controllers
{
    [Authorize]
    [Route("api/users")]
    [ApiController]
    public class UsersController : Controller
    {
        private DataManager _datamanager;
        private ServicesManager _servicesmanager;

        public UsersController(DataManager dataManager)
        {
            _datamanager = dataManager;
            _servicesmanager = new ServicesManager(dataManager);
        }

        // GET: api/users
        [HttpGet]
        public List<UserModel> Get()
        {
            return _servicesmanager.Users.GetAllUsers();
        }

        // GET: api/users/5
        [HttpGet("{id:int}")]
        public UserModel Get(int id)
        {
            return _servicesmanager.Users.GetUserById(id);
        }

        // GET: api/users/email
        [HttpGet("{email}")]
        public IActionResult Get(string email)
        {
         var user = _servicesmanager.Users.GetUserByEmail(email);
            if (user.Email != null)
            {
                return Ok(user);
            }
            return new ObjectResult(new List<UserModel>());
        }

        // POST: api/users
        [HttpPost]
        public IActionResult Post([FromBody] UserModel user)
        {
            if (ModelState.IsValid)
            {
                return Ok(_servicesmanager.Users.UserCreateOrUpdate(user));
            }
            return BadRequest(ModelState);
        }

        // PUT: api/users/5
        [HttpPut("{id:int}")]
        public IActionResult Put([FromBody] UserModel user)
        {
            if (ModelState.IsValid)
            {
                return Ok(_servicesmanager.Users.UserCreateOrUpdate(user));
            }
            return BadRequest(ModelState);
        }

        // DELETE: api/users/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_servicesmanager.Users.UserDelete(id) == true)
            {
                return Ok(id);
            }
            return BadRequest(new { errorText = "This User can't be deleted!" });

        }
    }
}
