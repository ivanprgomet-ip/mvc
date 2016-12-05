﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhotoExplorer.Web.Entities
{
    public class UserEntityModel
    {
        public UserEntityModel()
        {
            Albums = new List<AlbumEntityModel>();
        }

        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime? DateRegistered { get; set; }
        public string Email { get; set; }

        //slow apps do alot of eager-loading    (loading things right away). 
        //Fast apps do alot of lazy-loading     (only loading things when they are needed)

        //non-virtual property -        lazy load disabled
        //virtual property -            lazy load enabled (for specific navigation property)
        public virtual ICollection<AlbumEntityModel> Albums { get; set; }
    }
}