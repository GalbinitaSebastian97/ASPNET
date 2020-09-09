using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAutoService.Models
{
    public class LoginModel
    {
        [Required]
        public string username;
        [Required]
        public string password;



    }
}
