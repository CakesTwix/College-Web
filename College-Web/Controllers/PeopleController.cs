using System.Collections.Generic;
using System.Linq;
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

        // GET api/<PeopleController>/GetUser/UserName
        [HttpGet("GetUser/{name}")]
        public async Task<UserApp> GetUserAsync(string name)
        {
            UserApp appUser = await userManager.FindByNameAsync(name);

            if (appUser == null)
            {
                return null;
            }

            return appUser;
            
        }

        // GET api/<PeopleController>/GetStudentInfo/id
        // id - Айди студента
        [HttpGet("GetStudentInfo/{id}")]
        public async Task<StudentGeneralInfo> GetStudentInfoAsync(string id)
        {
            StudentGeneralInfo student = await db.StudentInfo.FindAsync(id);

            if (student == null)
            {
                return null;
            }

            return student;

        }

        // GET api/<PeopleController>/GetAllStudents/
        // id - Айди студента
        [HttpGet("GetAllStudents")]
        public List<UserApp> GetAllStudentsAsync()
        {
            var student = db.UserApp.ToList();
            return student;
        }

        // POST api/<PeopleController>
        [HttpGet("UpdateStudentInfo")]
        public async Task UpdateStudentInfoAsync([FromQuery] StudentGeneralInfo studentGeneralInfo)
        {
            StudentGeneralInfo student = await db.StudentInfo.FindAsync(studentGeneralInfo.ID);
            if (student != null)
            {
                student.CollageUk = studentGeneralInfo.CollageUk;
                student.CollageEn = studentGeneralInfo.CollageEn;
                student.OwnershipUk = studentGeneralInfo.OwnershipUk;
                student.OwnershipEn = studentGeneralInfo.OwnershipEn;
                student.FacultyUk = studentGeneralInfo.FacultyUk;
                student.FacultyEn = studentGeneralInfo.FacultyEn;
                student.EducationFormNameUk = studentGeneralInfo.EducationFormNameUk;
                student.EducationFormNameEn = studentGeneralInfo.EducationFormNameEn;
                student.StudyLanguageUk = studentGeneralInfo.StudyLanguageUk;
                student.StudyLanguageEn = studentGeneralInfo.StudyLanguageEn;
                student.DegreeUk = studentGeneralInfo.DegreeUk;
                student.DegreeEn = studentGeneralInfo.DegreeEn;
                student.SpecialityUk = studentGeneralInfo.SpecialityUk;
                student.SpecialityEn = studentGeneralInfo.SpecialityEn;
                student.ProfqualificationUk = studentGeneralInfo.ProfqualificationUk;
                student.ProfqualificationEn = studentGeneralInfo.ProfqualificationEn;
                student.FieldofStudyUk = studentGeneralInfo.FieldofStudyUk;
                student.FieldofStudyEn = studentGeneralInfo.FieldofStudyEn;
                student.LevelofQualificationUk = studentGeneralInfo.LevelofQualificationUk;
                student.LevelofQualificationEn = studentGeneralInfo.LevelofQualificationEn;
                student.years = studentGeneralInfo.years;
                student.months = studentGeneralInfo.months;
                student.FormNameUk = studentGeneralInfo.FormNameUk;
                student.FormNameEn = studentGeneralInfo.FormNameEn;
                student.MainUk = studentGeneralInfo.MainUk;
                student.MainEn = studentGeneralInfo.MainEn;
                student.AdditionalUk = studentGeneralInfo.AdditionalUk;
                student.AdditionalEn = studentGeneralInfo.AdditionalEn;
                student.AccessFurtherStudyUk = studentGeneralInfo.AccessFurtherStudyUk;
                student.AccessFurtherStudyEn = studentGeneralInfo.AccessFurtherStudyEn;
                student.ProfessionalStatusUk = studentGeneralInfo.ProfessionalStatusUk;
                student.ProfessionalStatusEn = studentGeneralInfo.ProfessionalStatusEn;
                student.PositionUk = studentGeneralInfo.PositionUk;
                student.PositionEn = studentGeneralInfo.PositionEn;
                student.SignerNameUk = studentGeneralInfo.SignerNameUk;
                student.SignerNameEn = studentGeneralInfo.SignerNameEn;
                student.SutisfyUk = studentGeneralInfo.SutisfyUk;
                student.SutisfyEn = studentGeneralInfo.SutisfyEn;
                student.KnowledgeUk = studentGeneralInfo.KnowledgeUk;
                student.KnowledgeEn = studentGeneralInfo.KnowledgeEn;
                student.UnderstandingUk = studentGeneralInfo.UnderstandingUk;
                student.UnderstandingEn = studentGeneralInfo.UnderstandingEn;
                student.JudgmentsUk = studentGeneralInfo.JudgmentsUk;
                student.JudgmentsEn = studentGeneralInfo.JudgmentsEn;
                db.StudentInfo.Update(student);
                await db.SaveChangesAsync();
            }
        }
    }
}
