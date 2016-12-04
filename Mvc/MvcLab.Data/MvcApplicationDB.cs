using MvcLab.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcLab.Data
{
    public class MvcApplicationDB : DbContext
    {
        public MvcApplicationDB() : base("name=MvcApplicationCS")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<MvcApplicationDB>());
            //Lazy loading means delaying the loading of related data, until you specifically request for it
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<AlbumEntity> Albums { get; set; }
        public DbSet<PhotoEntity> Photos { get; set; }
        public DbSet<CommentEntity> Comments { get; set; }


        //private void Seed()
        //{
        //    PhotoEntity p1 = new PhotoEntity()
        //    {
        //        Name = "event1",
        //        FileName = "event1.jpg",
        //        DateCreated = DateTime.Now,
        //        Description = "no description",
        //    };
        //    PhotoEntity p2 = new PhotoEntity()
        //    {
        //        Name = "event2",
        //        FileName = "event2.jpg",
        //        DateCreated = DateTime.Now,
        //        Description = "no description",
        //    };

        //    AlbumEntity a1 = new AlbumEntity()
        //    {
        //        Name = "my coding events",
        //        Description = "coding events that i have attended",
        //        DateCreated = DateTime.Now,
        //        Comments = new List<CommentEntity>(),
        //        Photos = new List<PhotoEntity>() { p1, p2 },
        //    };

        //    UserEntity u1 = new UserEntity()
        //    {
        //        Firstname = "ivan",
        //        Lastname = "prgomet",
        //        Country = "sweden",
        //        City = "lund",
        //        DateRegistered = DateTime.Now,
        //        Email = "ivanprgomet_ip@hotmail.com",
        //        Street = "lundstreet 3",
        //        Phone = "9423587495",
        //        Username = "ivanprgomet",
        //        Password = "ivan123",
        //        Albums = new List<AlbumEntity>() { a1 },
        //    };

        //    SetupFolders();

        //    Users.Add(u1);

        //    SaveChanges();
        //}

        //private void SetupFolders()
        //{

        //    //server mappath doesnt work here, using alternative to get basedir (instead of ~)
        //    string baseDir = System.AppDomain.CurrentDomain.BaseDirectory;

        //    string destination = string.Format($"{baseDir}/UsersData/");

        //    if (!Directory.Exists(destination))
        //    {
        //        Directory.CreateDirectory(destination);
        //    }

        //    //using (var ctx = new MvcApplicationDB())
        //    //{
        //        List<UserEntity> userEntitiesFromDB = Users.ToList();

        //        foreach (var user in userEntitiesFromDB)
        //        {
        //            string individualUserDir = Path.Combine(destination, user.Username);
        //            Directory.CreateDirectory(individualUserDir);

        //            foreach (var album in user.Albums)
        //            {
        //                string IndividualUserAlbumDir = Path.Combine(individualUserDir, album.Name);
        //                Directory.CreateDirectory(IndividualUserAlbumDir);
        //            }
        //        //}


        //    }
        //}
    }
}
