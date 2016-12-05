using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PhotoExplorer.Web.Models
{
    public class AlbumViewModel
    {
        public AlbumViewModel()
        {
            Comments = new List<CommentViewModel>();
            Photos = new List<PhotoViewModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual ICollection<CommentViewModel> Comments { get; set; }
        public virtual ICollection<PhotoViewModel> Photos { get; set; }

        public virtual UserViewModel User { get; set; }
        //public int UserModelId { get; set; }
    }
}