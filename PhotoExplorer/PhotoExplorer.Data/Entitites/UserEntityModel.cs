using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoExplorer.Data.Entities
{
    public class UserEntityModel
    {
        public UserEntityModel()
        {
            DateRegistered = DateTime.Now;
            //Albums = new List<AlbumEntityModel>();
        }

        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime? DateRegistered { get; set; }
        public string Email { get; set; }

        public virtual ICollection<AlbumEntityModel> Albums { get; set; }
        //public virtual ICollection<PhotoEntityModel> Photos { get; set; }
    }
}