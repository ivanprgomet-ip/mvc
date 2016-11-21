using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPhotoAlbums.Models
{
    public class PhotoModel
    {
        public Guid Id { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateChanged { get; set; }
        public string UploadedBy { get; set; }

        public UserModel User { get; set; }
        public AlbumModel Album { get; set; }
    }
}