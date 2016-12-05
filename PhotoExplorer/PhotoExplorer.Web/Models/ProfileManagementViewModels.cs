using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhotoExplorer.Web.Models
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage ="Specify username for login attempt")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Specify password for login attempt")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public class UserRegisterViewModel
    {
        [Required(ErrorMessage ="You must specify your fullname (Firstname_Lastname)")]
        public string Fullname { get; set; }

        [Required(ErrorMessage ="You must specify your username")]
        public string Username { get; set; }

        [Required(ErrorMessage ="You must specify an Email address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage ="You must specify an password")]
        [MinLength(10,ErrorMessage ="Your password must contain min 10 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}