﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcLab.Web.Models
{
    public class PhotoModel
    {
        public Guid PhotoId { get; set; }
        public string Name { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateChanged { get; set; }
        public string UploadedBy { get; set; }

        public virtual List<CommentModel> Comments { get; set; }

        public virtual UserModel User { get; set; }
        public Guid UserId { get; set; }
        public virtual AlbumModel Album { get; set; }
        public Guid AlbumId { get; set; }
    }
}