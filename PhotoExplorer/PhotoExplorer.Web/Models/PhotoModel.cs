using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhotoExplorer.Web.Models
{
    public class PhotoModel
    {
        public PhotoModel()
        {
            Comments = new List<CommentModel>();
        }

        public int Id { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateChanged { get; set; }
        public string UploadedBy { get; set; }

        //navigation property
        public virtual List<CommentModel> Comments { get; set; }

        public virtual UserModel User { get; set; }
        //public int UserModelId { get; set; }
        public virtual AlbumModel Album { get; set; }
        //public int AlbumModelId { get; set; }

    }
}