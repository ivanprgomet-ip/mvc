using PhotoExplorer.Web.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhotoExplorer.Web.Repositories
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
    }
}
