using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace _2.University_API_Backend.Models.DataModels
{
    
    public class Course:BaseEntity
    {
        [Required, StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required, StringLength(280)]
        public string ShortDescription { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        public Level Level { get; set; } = Level.Basic;

        [Required]
        [StringLength(50)]
        public ICollection<Category> Categories { get; set; } = new List<Category>();

        [Required]
        public ICollection<Student> Students { get; set; } = new List<Student>();

        [Required]
        public Chapter Chapter { get; set; } = new Chapter();

    }

    public enum Level
    {
        Basic,
        Medium,
        Advanced,
        Expert
    }
}

