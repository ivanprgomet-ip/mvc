using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhotoExplorer.Web.Models
{
    public class UserModel
    {
        public UserModel()
        {
            Albums = new List<AlbumModel>();
        }

        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime? DateRegistered { get; set; }

        public virtual ICollection<AlbumModel> Albums { get; set; }
    }
}