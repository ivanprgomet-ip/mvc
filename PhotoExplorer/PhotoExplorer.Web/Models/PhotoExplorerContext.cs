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
        
        public DbSet<UserViewModel> Users { get; set; }
        public DbSet<AlbumViewModel> Albums { get; set; }
        public DbSet<PhotoViewModel> Photos { get; set; }
        public DbSet<CommentViewModel> Comments { get; set; }
    }
}