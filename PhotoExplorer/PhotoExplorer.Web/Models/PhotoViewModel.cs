using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhotoExplorer.Web.Models
{
    public class PhotoViewModel
    {
        public PhotoViewModel()
        {
            Comments = new List<CommentViewModel>();
        }

        public int Id { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateChanged { get; set; }
        public string UploadedBy { get; set; }

        //navigation property
        public virtual List<CommentViewModel> Comments { get; set; }

        public virtual UserViewModel User { get; set; }
        //public int UserModelId { get; set; }
        public virtual AlbumViewModel Album { get; set; }
        //public int AlbumModelId { get; set; }

    }
}