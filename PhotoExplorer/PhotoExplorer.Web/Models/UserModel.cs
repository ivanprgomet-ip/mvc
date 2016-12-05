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

        //slow apps do alot of eager-loading    (loading things right away). 
        //Fast apps do alot of lazy-loading     (only loading things when they are needed)

        //non-virtual property -        lazy load disabled
        //virtual property -            lazy load enabled (for specific navigation property)
        public virtual ICollection<AlbumModel> Albums { get; set; }
    }
}