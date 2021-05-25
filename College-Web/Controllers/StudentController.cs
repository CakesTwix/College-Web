﻿using College_Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
            var student = new List<StudentModel>();

            // Retrieve all the Users
            foreach (var user in userManager.Users)
            {
                // If the user is in this role, add the username to
                // Users property of EditRoleViewModel. This model
                // object is then passed to the view for display
                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    student.Add(new StudentModel
                    {
                        ID = user.Id,
                        Name = user.UserName,
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
            db.UserApp.Update(student);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> EditStudent(string? id)
        {
            if (id != null)
            {
                StudentModel user = await db.Student.FindAsync(id);
                if (user != null)
                    return View(user);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> EditStudent(StudentModel user)
        {
            StudentModel student = await db.Student.FindAsync(user.ID);
            student.UserName = user.UserName;
            student.Name = user.Name;
            student.Surname = user.Surname;
            student.Middle_Name = user.Middle_Name;
            student.Hours = user.Hours;
            student.Assessment = user.Assessment;
            student.Assessment_EKTC = user.Assessment_EKTC;
            student.Note = user.Note;
            db.Student.Update(student);
            await db.SaveChangesAsync();

            return Redirect("/Student");
        }
        public async Task<IActionResult> EditGeneralInfo(string? id)
        {
            if (id != null)
            {
                StudentGeneralInfo user = await db.StudentInfo.FindAsync(id);
                if (user != null)
                    return View(user);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> EditGeneralInfo(StudentGeneralInfo user)
        {
            StudentGeneralInfo student = await db.StudentInfo.FindAsync(user.ID);
            // TODO:
            // Доделать эту штуку
            student.CollageEn = user.CollageEn;
            db.StudentInfo.Update(student);
            await db.SaveChangesAsync();

            return Redirect("/Student");
        }
    }
}
