using PhotoExplorer.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PhotoExplorer.Web.Models
{
    public class PhotoExplorerContext:DbContext
    {
        public PhotoExplorerContext()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<PhotoExplorerContext>());
        }
        
        public DbSet<UserModel> Users { get; set; }
        public DbSet<AlbumModel> Albums { get; set; }
        public DbSet<PhotoModel> Photos { get; set; }
        public DbSet<CommentModel> Comments { get; set; }
    }
}