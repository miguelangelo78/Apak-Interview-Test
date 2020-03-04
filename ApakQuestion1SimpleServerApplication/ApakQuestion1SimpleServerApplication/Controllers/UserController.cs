using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApakQuestion1SimpleServerApplication.Models;
using ApakQuestion1SimpleServerApplication.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApakQuestion1SimpleServerApplication.Controllers
{
    [Route("v1/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService UserService;
        private readonly IUserLookup UserLookup;

        public UserController(IUserService UserService, IUserLookup UserLookup)
        {
            this.UserService = UserService;
            this.UserLookup = UserLookup;
        }
    
        [HttpGet("{id}")]
        public ActionResult<UserRequestInfo> GetUser(int id)
        {
            User user = UserService.GetUser(id);

            if(user == null)
            {
                return NotFound();
            }

            return user.UserRequestInfo;
        }

        [HttpPost]
        public ActionResult<User> SaveUser(User user)
        {
            return UserService.SaveUser(user);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            UserService.DeleteUser(id);
            return Ok();
        }

        [HttpGet("{id}/lookup")]
        public ActionResult<string> LookupUser(int id)
        {
            string location = UserLookup.GetLocation(id);

            if(location == null)
            {
                return NotFound();
            }
            
            return location;
        }
    }
}