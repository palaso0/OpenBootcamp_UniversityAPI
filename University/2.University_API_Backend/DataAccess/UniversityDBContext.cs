using System;
using _2.University_API_Backend.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace _2.University_API_Backend.DataAccess
{
    public class UniversityDBContext: DbContext
    {
        public UniversityDBContext(DbContextOptions<UniversityDBContext> options): base(options)
        {

        }

        // Add DBSets (tables of our Data base)
        public DbSet<User>? Users { get; set; }
        public DbSet<Curso>? Cursos { get; set; }
        public DbSet<Course>? Courses { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Student>? Students { get; set; }
        public DbSet<Chapter>? Chapters{ get; set; }
    }
}

