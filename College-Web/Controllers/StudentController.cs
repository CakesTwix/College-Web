using College_Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace College_Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly UserManager<UserApp> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private AppIdentityDbContext db;
        public StudentController(RoleManager<IdentityRole> roleManager, UserManager<UserApp> userManager, AppIdentityDbContext db)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.db = db;
        }

        // GET: StudentController
        public async Task<IActionResult> Index()
        {
            var role = await roleManager.FindByNameAsync("Student");
            var student = new List<UserApp>();

            // Retrieve all the Users
            foreach (var user in userManager.Users)
            {
                // If the user is in this role, add the username to
                // Users property of EditRoleViewModel. This model
                // object is then passed to the view for display
                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    student.Add(new UserApp
                    {
                        Id = user.Id,
                        Name = user.Name,
                        First_Name = user.First_Name,
                        Surname = user.Surname,
                        Middle_Name = user.Middle_Name,
                    });
                }
            }
            ViewBag.Student = student;
            return View();
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(string? id)
        {
            if (id != null)
            {
                UserApp user = (UserApp)await db.Users.FirstOrDefaultAsync(p => p.Id == id);
                if (user != null)
                    return View(user);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string? id)
        {
            if (id != null)
            {
                UserApp user = (UserApp)await db.Users.FirstOrDefaultAsync(p => p.Id == id);
                if (user != null)
                {
                    db.Users.Remove(user);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }
        public async Task<IActionResult> Edit(string? id)
        {
            if (id != null)
            {
                UserApp user = await db.UserApp.FindAsync(id);
                if (user != null)
                    return View(user);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UserApp user)
        {
            var student = await db.UserApp.FirstOrDefaultAsync(u => u.Id == user.Id);
            student.UserName = user.UserName;
            student.First_Name = user.First_Name;
            student.Surname = user.Surname;
            student.Middle_Name = user.Middle_Name;
            db.UserApp.Update(student);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> EditStudent(string? id)
        {
            if (id != null)
            {
                List<StudentModel> user = new List<StudentModel>();
                user = db.Student.Where(u => u.userApp.Id == id).ToList();
                if (user != null)
                {
                    ViewBag.Student = user;
                    return View();
                }
                else
                {
                    var userApp = await db.UserApp.FirstOrDefaultAsync(u => u.Id == id);
                    StudentModel student = new StudentModel();
                    student.ID = id;
                    await db.Student.AddAsync(student);
                    await db.SaveChangesAsync();
                    return View(student);
                }
            }
            return NotFound();
        }
        public async Task<IActionResult> EditStudentModel(string? id)
        {
            if (id != null)
            {
                StudentModel user = await db.Student.FindAsync(id);
                if (user != null)
                {
                    return View(user);
                }
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> EditStudentModel(StudentModel user)
        {
            StudentModel student = await db.Student.FindAsync(user.ID);
            student.Subject = user.Subject;
            student.Teacher = user.Teacher;
            student.Hours = user.Hours;
            student.Assessment = user.Assessment;
            student.Assessment_EKTC = user.Assessment_EKTC;
            student.Note = user.Note;
            student.Credits = user.Credits;
            db.Student.Update(student);
            await db.SaveChangesAsync();

            return Redirect("/Student");
        }

        [HttpPost]
        public async Task<IActionResult> AddStudentModel(StudentModel user)
        {
            await db.Student.AddAsync(user);
            await db.SaveChangesAsync();

            return Redirect("/");
        }
        public async Task<IActionResult> EditGeneralInfo(string? id)
        {
            if (id != null)
            {
                StudentGeneralInfo user = await db.StudentInfo.FindAsync(id);
                if (user != null)
                    return View(user);
                else
                {
                    StudentGeneralInfo student = new StudentGeneralInfo();
                    student.ID = id;
                    await db.StudentInfo.AddAsync(student);
                    await db.SaveChangesAsync();
                    return View(student);
                }
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> EditGeneralInfo(StudentGeneralInfo user)
        {
            StudentGeneralInfo student = await db.StudentInfo.FindAsync(user.ID);
            student.CollageUk = user.CollageUk;
            student.CollageEn = user.CollageEn;
            student.OwnershipUk = user.OwnershipUk;
            student.OwnershipEn = user.OwnershipEn;
            student.FacultyUk = user.FacultyUk;
            student.FacultyEn = user.FacultyEn;
            student.EducationFormNameUk = user.EducationFormNameUk;
            student.EducationFormNameEn = user.EducationFormNameEn;
            student.StudyLanguageUk = user.StudyLanguageUk;
            student.StudyLanguageEn = user.StudyLanguageEn;
            student.DegreeUk = user.DegreeUk;
            student.DegreeEn = user.DegreeEn;
            student.SpecialityUk = user.SpecialityUk;
            student.SpecialityEn = user.SpecialityEn;
            student.ProfqualificationUk = user.ProfqualificationUk;
            student.ProfqualificationEn = user.ProfqualificationEn;
            student.FieldofStudyUk = user.FieldofStudyUk;
            student.FieldofStudyEn = user.FieldofStudyEn;
            student.LevelofQualificationUk = user.LevelofQualificationUk;
            student.LevelofQualificationEn = user.LevelofQualificationEn;
            student.years = user.years;
            student.months = user.months;
            student.FormNameUk = user.FormNameUk;
            student.FormNameEn = user.FormNameEn;
            student.MainUk = user.MainUk;
            student.MainEn = user.MainEn;
            student.AdditionalUk = user.AdditionalUk;
            student.AdditionalEn = user.AdditionalEn;
            student.AccessFurtherStudyUk = user.AccessFurtherStudyUk;
            student.AccessFurtherStudyEn = user.AccessFurtherStudyEn;
            student.ProfessionalStatusUk = user.ProfessionalStatusUk;
            student.ProfessionalStatusEn = user.ProfessionalStatusEn;
            student.PositionUk = user.PositionUk;
            student.PositionEn = user.PositionEn;
            student.SignerNameUk = user.SignerNameUk;
            student.SignerNameEn = user.SignerNameEn;
            student.SutisfyUk = user.SutisfyUk;
            student.SutisfyEn = user.SutisfyEn;
            student.KnowledgeUk = user.KnowledgeUk;
            student.KnowledgeEn = user.KnowledgeEn;
            student.UnderstandingUk = user.UnderstandingUk;
            student.UnderstandingEn = user.UnderstandingEn;
            student.JudgmentsUk = user.JudgmentsUk;
            student.JudgmentsEn = user.JudgmentsEn;
            db.StudentInfo.Update(student);
            await db.SaveChangesAsync();

            return Redirect("/Student");
        }
    }
}
