using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhotoExplorer.Web.Entities
{
    public class PhotoEntityModel
    {
        public PhotoEntityModel()
        {
            DateCreated = DateTime.Now;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateChanged { get; set; }

        public virtual List<CommentEntityModel> Comments { get; set; }

        public virtual UserEntityModel User { get; set; }//one side - use include where you need this property
        public virtual AlbumEntityModel Album { get; set; }//one side - use include where you need this propety

    }
}