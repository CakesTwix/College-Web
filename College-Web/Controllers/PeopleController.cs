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
        private AppIdentityDbContext db;

        public PeopleController(UserManager<UserApp> usrMgr, AppIdentityDbContext db)
        {
            userManager = usrMgr;
            this.db = db;
        }

        // GET api/<PeopleController>/User/UserName
        [HttpGet("User/{name}")]
        public async Task<UserApp> GetUserAsync(string name)
        {
            UserApp appUser = await userManager.FindByNameAsync(name);

            if (appUser == null)
            {
                return null;
            }

            return appUser;
            
        }

        // GET api/<PeopleController>/Student/id
        // id - Айди студента
        [HttpGet("Student/{id}")]
        public async Task<StudentGeneralInfo> GetStudentInfoAsync(string id)
        {
            StudentGeneralInfo student = await db.StudentInfo.FindAsync(id);

            if (student == null)
            {
                return null;
            }

            return student;

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
