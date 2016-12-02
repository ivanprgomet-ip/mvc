namespace MvcLab.Data.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcLab.Data.MvcLabContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "MvcLab.Data.MvcLabContext";
        }

        protected override void Seed(MvcLab.Data.MvcLabContext context)
        {
            //create some default users
            UserEntity u1 = new UserEntity()
            {
                UserId = Guid.NewGuid(),
                Firstname = "Ivan",
                Lastname = "Prgomet",
                Country = "Sweden",
                City = "Lund",
                Street = "lundstreet 2",
                Email = "ip@gmail.com",
                Phone = "0735709868",
                Username = "ivanprgomet",
                Password = "ivan123",
                DateRegistered = DateTime.Now,
                //Albums = new List<AlbumEntity>(), //initialized in the construcotr of UserEntity
            };
            #region creating album for Ivan
            u1.Albums.Add(new AlbumEntity()
            {
                AlbumId = Guid.NewGuid(),
                DateCreated = DateTime.Now,
                Name = "Coding Events",
                Description = "Photos from some coding events that I have attended",
                //Photos = new List<PhotoEntity>(), //initialized in the construcotr of AlbumEntity
                //Comments = new List<CommentEntity>(), //initialized in the construcotr of AlbumEntity
                UserId = u1.UserId,
            });
            #endregion

            using (MvcLabContext ctx = new MvcLabContext())
            {
                ctx.Users.AddOrUpdate(u1);

                ctx.SaveChanges();
            }

            //UserEntity u2 = new UserEntity()
            //{
            //    UserId = Guid.NewGuid(),
            //    Firstname = "Lea",
            //    Lastname = "Winchester",
            //    Country = "England",
            //    City = "London",
            //    Street = "Grape Street",
            //    Email = "leawinchester@gmail.com",
            //    Phone = "92345873294",
            //    Username = "leawinchester",
            //    Password = "lealea",
            //    DateRegistered = DateTime.Now,

            //    Albums = new List<AlbumEntity>(),
            //};
            //#region creating album for Lea (files added in album folder before startup, later files get added thru mvc UI input type file)
            //u2.Albums.Add(new AlbumEntity()
            //{
            //    AlbumId = Guid.NewGuid(),
            //    DateCreated = DateTime.Now,
            //    Name = "Lea Coding Album",
            //    Description = "No Album Description",
            //    Photos = new List<PhotoEntity>() {
            //        new PhotoEntity()
            //                {
            //                    PhotoId = Guid.NewGuid(),
            //                    Name = "coffe is love",
            //                    FileName = "code2.jpg",
            //                    DateCreated = DateTime.Now,
            //                    Description = "No Photo Description",
            //                    Comments = new List<CommentEntity>(),
            //                },
            //        new PhotoEntity()
            //                {
            //                    PhotoId = Guid.NewGuid(),
            //                    Name = "think before you code",
            //                    FileName = "code4.png",
            //                    DateCreated = DateTime.Now,
            //                    Description = "you should never mix code with alcohol",
            //                    Comments = new List<CommentEntity>(),
            //                },
            //        new PhotoEntity()
            //                {
            //                    PhotoId = Guid.NewGuid(),
            //                    Name = "no place like home",
            //                    FileName = "code5.jpg",
            //                    DateCreated = DateTime.Now,
            //                    Description = "No Photo Description",
            //                    Comments = new List<CommentEntity>(),
            //                },
            //    },
            //    Comments = new List<CommentEntity>(),
            //    User = u2,
            //});
            //#endregion


            //UserEntity u3 = new UserEntity()
            //{
            //    UserId = Guid.NewGuid(),
            //    Firstname = "Scott",
            //    Lastname = "Ferryson",
            //    Country = "Australia",
            //    City = "Sydney",
            //    Street = "Kangaroo Alley 8",
            //    Email = "ImScott@gmail.com",
            //    Phone = "3940857",
            //    Username = "scottferryson",
            //    Password = "scott123",
            //    DateRegistered = DateTime.Now,

            //    Albums = new List<AlbumEntity>(),
            //};

            //add the users to the database



            SetupFolders();
        }

        private void SetupFolders()
        {
            //server mappath doesnt work here, using alternative to get basedir (instead of ~)
            string baseDir = System.AppDomain.CurrentDomain.BaseDirectory;

            string destination = string.Format($"{baseDir}/UsersData/");

            if (!Directory.Exists(destination))
            {
                Directory.CreateDirectory(destination);
            }

            using (MvcLabContext ctx = new MvcLabContext())
            {
                List<UserEntity> userEntitiesFromDB = ctx.Users.ToList();

                foreach (var user in userEntitiesFromDB)
                {
                    string individualUserDir = Path.Combine(destination, user.Username);
                    Directory.CreateDirectory(individualUserDir);

                    foreach (var album in user.Albums)
                    {
                        string IndividualUserAlbumDir = Path.Combine(individualUserDir, album.Name);
                        Directory.CreateDirectory(IndividualUserAlbumDir);
                    }
                }

            }
        }
    }
}
