using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcLab.Web.Models
{
    public class AlbumModel
    {
        public int AlbumId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual ICollection<CommentModel> Comments { get; set; }
        public virtual ICollection<PhotoModel> Photos { get; set; }

        public virtual UserModel User { get; set; }
        public int? UserId { get; set; }
    }
}