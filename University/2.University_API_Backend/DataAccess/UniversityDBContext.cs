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

        //TODO: Add DBSets (tables of our Data base)
        public DbSet<User>? Users { get; set; }
        public DbSet<Curso>? Cursos { get; set; }

    }
}

