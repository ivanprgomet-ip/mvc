using MvcLab.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcLab.Data
{
    class MvcLabContext:DbContext
    {
        DbSet<UserEntity> Users { get; set; }
        DbSet<AlbumEntity> Albums { get; set; }
        DbSet<PhotoEntity> Photos { get; set; }
        DbSet<CommentEntity> Comments { get; set; }
    }
}
