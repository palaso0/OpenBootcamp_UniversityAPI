using System;
using System.ComponentModel.DataAnnotations;

namespace _2.University_API_Backend.Models.DataModels
{
    public class Curso : BaseEntity
    {
        [Required]
        public string Nombre { get; set; } = string.Empty;

        [Required, StringLength(280)]
        public string ShortDescription { get; set; } = string.Empty;

        [Required]
        public string LargeDescription { get; set; } = string.Empty;

        [Required]
        public string TargetPublic { get; set; } = string.Empty;

        [Required]
        public string Objetives { get; set; } = string.Empty;

        [Required]
        public string Requirements { get; set; } = string.Empty;

        [Required]
        public LevelEnum Level { get; set; } = 0;

        public Curso()
        {
        }
    }

    public enum LevelEnum
    {
        Basic,
        Intermediate,
        Advanced
    }
}

