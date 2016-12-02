using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcLab.Data.Models
{
    public class UserEntity
    {
        [Key]
        public int UserId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime DateRegistered { get; set; }

        //navigation property
        public virtual ICollection<AlbumEntity> Albums { get; set; }

        public UserEntity()
        {
            Albums = new List<AlbumEntity>();
        }
    }
}