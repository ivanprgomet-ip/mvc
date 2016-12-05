using PhotoExplorer.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PhotoExplorer.Web.Entities
{
    public class PhotoExplorerContext:DbContext
    {
        public PhotoExplorerContext()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<PhotoExplorerContext>());
        }
        
        public DbSet<UserEntityModel> Users { get; set; }
        public DbSet<AlbumEntityModel> Albums { get; set; }
        public DbSet<PhotoEntityModel> Photos { get; set; }
        public DbSet<CommentEntityModel> Comments { get; set; }
    }
}