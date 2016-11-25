using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCPhotoAlbums.Data.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Please enter your firstname", AllowEmptyStrings = false)]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Please enter your lastname", AllowEmptyStrings = false)]
        public string Lastname { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Required(ErrorMessage ="Please enter a legitimate Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter a username", AllowEmptyStrings = false)]
        public string Username { get; set; }
        [Required(ErrorMessage = "please enter a password", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public DateTime DateRegistered { get; set; }

        public ICollection<AlbumModel> Albums { get; set; }
    }
}