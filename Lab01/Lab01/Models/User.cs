using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab01.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        [Required(ErrorMessage ="Please enter a username",AllowEmptyStrings =false)]
        public string Username { get; set; }
        [Required(ErrorMessage ="please enter a password",AllowEmptyStrings =false)]
        public string Password { get; set; }
        public DateTime DateRegistered { get; set; }
    }
}