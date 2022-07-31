using System;
using System.ComponentModel.DataAnnotations;

namespace _2.University_API_Backend.Models.DataModels
{
    public class Chapter: BaseEntity
    {
        public int CourseId { get; set; }
        public virtual Course Course { get; set; } = new Course();

        [Required]
        public string List = string.Empty;
    }
}

