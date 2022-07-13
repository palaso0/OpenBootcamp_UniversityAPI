using System;
using System.ComponentModel.DataAnnotations;

namespace _2.University_API_Backend.Models.DataModels
{
    public class User: BaseEntity
    {
        [Required,StringLength(50)]  //Dato requerido, el string no debe pasar los 50 caracteres
        public string Name { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string LastName { get; set; } = string.Empty;

        [Required, EmailAddress] //Dato requerido de tipo mail
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;


        public User()
        {
        }
    }
}

