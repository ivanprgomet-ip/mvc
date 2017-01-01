using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Data.Entity;
using PhotoExplorer.Data.Entities;

namespace PhotoExplorer.Data.Repositories
{
    public class UserRepository
    {
        public void Add(UserEntityModel userToBeRegistered)
        {
            using (PhotoExplorerEntities _context = new PhotoExplorerEntities())
            {
                _context.Users.Add(userToBeRegistered);

                _context.SaveChanges();
            }
        }

        public UserEntityModel GetUser(int IserModelId)
        {
            using (PhotoExplorerEntities _context = new PhotoExplorerEntities())
            {
                UserEntityModel user = _context.Users
                    .Where(u => u.Id == IserModelId)
                    .Include(u => u.Albums
                        .Select(p => p.Photos
                        .Select(c => c.Comments))) //neccessary to include the albums 
                    .FirstOrDefault();
                return user;
            }
        }

        public UserEntityModel RetrieveLoggedInUser(string username, string password)
        {
            using (PhotoExplorerEntities _context = new PhotoExplorerEntities())
            {
                return _context.Users
                    .FirstOrDefault(u => u.Username == username &&
                    u.Password == password);
            }

        }

        public List<UserEntityModel> RetrieveAllUsers()
        {
            List<UserEntityModel> entities = new List<UserEntityModel>();

            using (PhotoExplorerEntities cx = new PhotoExplorerEntities())
            {
                entities = cx.Users
                    .Include(u => u.Albums
                        .Select(a => a.Photos))
                    .ToList();
            }

            return entities;
        }

        public void CreateAlbum(int userid, string albumName, string albumDescription)
        {
            using (PhotoExplorerEntities cx = new PhotoExplorerEntities())
            {
                AlbumEntityModel newEntityAlbum = new AlbumEntityModel()
                {
                    Name = albumName,
                    Description = albumDescription,
                };

                var userEntity = cx.Users.FirstOrDefault(u => u.Id == userid);

                userEntity.Albums.Add(newEntityAlbum);

                cx.SaveChanges();
            }
        }
    }
}