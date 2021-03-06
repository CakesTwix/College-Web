﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace College_Web.Models
{
    public class AppIdentityDbContext : IdentityDbContext
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options) { }
        public DbSet<UserApp> UserApp { get; set; }
        public DbSet<StudentModel> Student { get; set; }
        public DbSet<StudentGeneralInfo> StudentInfo { get; set; }
    }
}
