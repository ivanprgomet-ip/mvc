using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PhotoExplorer.Web.Models
{
    public class AlbumModel
    {
        public AlbumModel()
        {
            Comments = new List<CommentModel>();
            Photos = new List<PhotoModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual ICollection<CommentModel> Comments { get; set; }
        public virtual ICollection<PhotoModel> Photos { get; set; }

        public virtual UserModel User { get; set; }
        //public int UserModelId { get; set; }
    }
}