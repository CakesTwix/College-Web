using System.Collections.Generic;
using System.Threading.Tasks;
using College_Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace College_Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private UserManager<UserApp> userManager;

        public PeopleController(UserManager<UserApp> usrMgr)
        {
            userManager = usrMgr;
        }

        // GET: api/<PeopleController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PeopleController>/UserName
        [HttpGet("{name}")]
        public async Task<UserApp> GetAsync(string name)
        {
            UserApp appUser = await userManager.FindByNameAsync(name);

            if (appUser == null)
            {
                return null;
            }

            return appUser;
            
        }

        // POST api/<PeopleController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PeopleController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PeopleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
