using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Student_Record_Management_System.Models;

namespace StudentRecordManagementSystem.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=RUBAIYAT\\SQLEXPRESS;Database=StudentDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }


    }
}
