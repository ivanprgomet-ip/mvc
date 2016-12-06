using PhotoExplorer.Web.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhotoExplorer.Web.Models
{
    //todo: initialize the datetimes and collection properties
    public class PhotoUploadViewModel
    {
        [Required(ErrorMessage ="Please enter name for photo")]
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class PhotoListedViewModel
    {
        public string FileName { get; set; }
    }

    public class PhotoDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public DateTime? DateCreated { get; set; }
        public List<CommentEntityModel> Comments { get; set; }
        public UserEntityModel User { get; set; }
        public AlbumEntityModel Album { get; set; }
    }

    public class AlbumCreateViewModel
    {
        [Required(ErrorMessage = "Please enter name for album")]
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class AlbumListedViewModel
    {
        public string Name { get; set; }
        public DateTime? DateCreated { get; set; }
        public UserEntityModel User { get; set; }
    }

    public class AlbumDetailsViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? DateCreated { get; set; }
        public ICollection<CommentEntityModel> Comments { get; set; }
        public ICollection<PhotoEntityModel> Photos { get; set; }
        public UserEntityModel User { get; set; }
    }
    public class UserSimplifiedViewModel
    {
        public int Id { get; set; }//needed in the views when we send ids into controller action...
        public string Username { get; set; }
        public DateTime? DateRegistered { get; set; }

        public UserSimplifiedViewModel()
        {
            DateRegistered = DateTime.Now;
        }
    }
    public class UserDetailsViewModel
    {
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime? DateRegistered { get; set; }
        public ICollection<AlbumEntityModel> Albums { get; set; }

        public UserDetailsViewModel()
        {
            Albums = new List<AlbumEntityModel>();
            DateRegistered = DateTime.Now;
        }
    }
}