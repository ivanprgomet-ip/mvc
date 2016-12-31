using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PhotoExplorer.Data.Entities
{
    public class PhotoExplorerEntities:DbContext
    {
        public PhotoExplorerEntities()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<PhotoExplorerEntities>());
        }
        
        public DbSet<UserEntityModel> Users { get; set; }
        public DbSet<AlbumEntityModel> Albums { get; set; }
        public DbSet<PhotoEntityModel> Photos { get; set; }
        public DbSet<CommentEntityModel> Comments { get; set; }
    }
}