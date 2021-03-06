﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcLab.Web.Models
{
    public class CommentModel
    {
        public int CommentModelId { get; set; }
        public string Comment { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateChanged { get; set; }

       
        public virtual PhotoModel Photo { get; set; }
        public int? PhotoModelId { get; set; }
        public virtual AlbumModel Album { get; set; }
        public int? AlbumModelId { get; set; }
    }
}