using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PhotoExplorer.Web.Entities
{
    public class AlbumEntityModel
    {
        public AlbumEntityModel()
        {
            Comments = new List<CommentEntityModel>();
            Photos = new List<PhotoEntityModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual ICollection<CommentEntityModel> Comments { get; set; }
        public virtual ICollection<PhotoEntityModel> Photos { get; set; }

        public virtual UserEntityModel User { get; set; }
    }
}