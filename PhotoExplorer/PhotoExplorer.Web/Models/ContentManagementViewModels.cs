using PhotoExplorer.Web.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhotoExplorer.Web.Models
{
    /// <summary>
    /// todo: dont use any entities in these classes. that means you 
    /// must map values
    /// </summary>
    public class UploadPhotoViewModel
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
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? DateCreated { get; set; }
        public List<CommentEntityModel> Comments { get; set; }
        public UserEntityModel User { get; set; }
        public AlbumEntityModel Album { get; set; }
    }

    public class CreateAlbumViewModel
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
    public class ListUsersAlbumsViewModel
    {
        public ICollection<AlbumEntityModel> Albums { get; set; }//all users albums

        public ListUsersAlbumsViewModel()
        {
            Albums = new List<AlbumEntityModel>();
        }
    }
}