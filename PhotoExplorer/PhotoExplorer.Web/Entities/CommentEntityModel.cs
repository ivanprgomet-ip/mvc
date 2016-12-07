using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhotoExplorer.Web.Entities
{
    public class CommentEntityModel
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateChanged { get; set; }
        public virtual UserEntityModel User { get; set; }

        public virtual PhotoEntityModel Photo { get; set; }
        public virtual AlbumEntityModel Album { get; set; }

        public CommentEntityModel()
        {
            //initializing this makes us avoid the: The ObjectContext instance has been disposed and can no longer be used for operations that require a connection.
            //when we make a comment, go out of details page , and come back into the photo details where we made the comment
            User = new UserEntityModel();
        }
    }
}