using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoExplorer.Data.Entities
{
    public class AlbumEntityModel
    {
        public AlbumEntityModel()
        {
            Comments = new List<CommentEntityModel>();
            Photos = new List<PhotoEntityModel>();
            DateCreated = DateTime.Now;
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