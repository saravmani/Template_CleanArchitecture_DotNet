using System;
using Microsoft.EntityFrameworkCore;
using Scorpion.SchoolManagement.Student.Domain.DBEntity;


namespace Scorpion.SchoolManagement.Student.Persister
{
    public class StudentManagerContext : DbContext
    {
        public DbSet<StudentDetails> StudentDetails { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=StudentManagement.db");
    }
}
