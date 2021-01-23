using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Airhub.Models
{
    public class Account
    {
        public int Id { get; set; }

        [Required, MinLength(6)]
        [Display(Name = "Nazwa użytkownika")]
        public string UserName { get; set; }

        [Required, MinLength(6)]
        [Display(Name = "Hasło")]
        public int Password { get; set; }

        public User User { get; set; }
    }
}
