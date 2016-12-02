using MvcLab.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcLab.Data
{
    class MvcApplicationDB:DbContext
    {
        public MvcApplicationDB() : base("name=MvcApplicationCS")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<MvcApplicationDB>());
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<AlbumEntity> Albums{ get; set; }
        public DbSet<PhotoEntity> Photos{ get; set; }
        public DbSet<CommentEntity> Comments{ get; set; }

    }
}
