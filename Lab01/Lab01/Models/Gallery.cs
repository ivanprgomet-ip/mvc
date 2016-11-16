using System.IO;
using System.Collections.Generic;
using System;

namespace Lab01.Models
{
    public class Gallery
    {
        public Guid GalleryId { get; set; }
        public string GalleryName { get; set; }
        public string GalleryOwner { get; set; }
        public List<Photo> Images { get; set; }

        public Gallery(string galleryName, string galleryOwner)
        {
            this.GalleryName = galleryName;
            this.GalleryOwner = galleryOwner;
            Images = new List<Photo>();
        }
    }
}