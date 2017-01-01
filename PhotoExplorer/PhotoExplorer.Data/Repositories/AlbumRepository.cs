using PhotoExplorer.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace PhotoExplorer.Data.Repositories
{
    public class AlbumRepository
    {
        public AlbumEntityModel Get(int albumId)
        {
            using (PhotoExplorerEntities _context = new PhotoExplorerEntities())
            {
                return _context.Albums.FirstOrDefault(a => a.Id == albumId);
            }
        }

        public List<AlbumEntityModel> GetAll()
        {
            using (PhotoExplorerEntities _context = new PhotoExplorerEntities())
            {
                return _context.Albums.ToList();
            }
        }

        public AlbumEntityModel Add(AlbumEntityModel newAlbum, int userId)
        {
            using (PhotoExplorerEntities _context = new PhotoExplorerEntities())
            {
                //get the owner of the album
                var albumUser = _context.Users.Where(u => u.Id == userId)
                    .FirstOrDefault();

                //set some properties of the new album
                //newAlbum.AlbumId = Guid.NewGuid();
                newAlbum.DateCreated = DateTime.Now;
                newAlbum.Photos = new List<PhotoEntityModel>();
                newAlbum.User = albumUser;
                newAlbum.Comments = new List<CommentEntityModel>();

                //add the album to the users albums
                albumUser.Albums.Add(newAlbum);
                //_context.Albums.Add(newAlbum);

                _context.SaveChanges();

                return newAlbum;
            }
        }

        public AlbumEntityModel GetAlbum(int id)
        {
            using (PhotoExplorerEntities cx = new PhotoExplorerEntities())
            {
                /*
                    the error with the disposed thingy is because i missed including the user (lazy loading)
                    which caused the app to crash, because when i try to access user properties later on, the user
                    for an album is not loaded, and the connection is closed by then
                */
                AlbumEntityModel entity = cx.Albums
                    .Where(a=>a.Id==id)
                    .Include(a => a.Photos)
                    .Include(a => a.Comments)
                    .Include(a=>a.User)
                    .FirstOrDefault();

                return entity;
            }


            //using (PhotoExplorerEntities _context = new PhotoExplorerEntities())
            //{
            //    UserEntityModel user = _context.Users
            //        .Where(u => u.Id == IserModelId)
            //        .Include(u => u.Albums
            //            .Select(p => p.Photos
            //            .Select(c => c.Comments))) //neccessary to include the albums 
            //        .FirstOrDefault();
            //    return user;
            //}
        }
    }
}
