using PhotoExplorer.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhotoExplorer.Web.Repositories
{
    public class AlbumRepository
    {
        public AlbumModel Get(int albumId)
        {
            using (PhotoExplorerContext _context = new PhotoExplorerContext())
            {
                return _context.Albums.FirstOrDefault(a => a.Id == albumId);
            }
        }

        public List<AlbumModel> GetAll()
        {
            using (PhotoExplorerContext _context = new PhotoExplorerContext())
            {
                return _context.Albums.ToList();
            }
        }

        public AlbumModel Add(AlbumModel newAlbum, int userId)
        {
            using (PhotoExplorerContext _context = new PhotoExplorerContext())
            {
                //get the owner of the album
                var albumUser = _context.Users.Where(u => u.Id == userId)
                    .FirstOrDefault();

                //set some properties of the new album
                //newAlbum.AlbumId = Guid.NewGuid();
                newAlbum.DateCreated = DateTime.Now;
                newAlbum.Photos = new List<PhotoModel>();
                newAlbum.User = albumUser;
                newAlbum.Comments = new List<CommentModel>();

                //add the album to the users albums
                albumUser.Albums.Add(newAlbum);
                //_context.Albums.Add(newAlbum);

                _context.SaveChanges();

                return newAlbum;
            }
        }
    }
}
