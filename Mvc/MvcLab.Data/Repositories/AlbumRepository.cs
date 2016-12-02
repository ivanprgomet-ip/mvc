using MvcLab.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MvcLab.Data.Repositories
{
    public class AlbumRepository
    {
        public AlbumEntity Get(int albumId)
        {
            using (MvcApplicationDB _context = new MvcApplicationDB())
            {
                return _context.Albums.FirstOrDefault(a => a.AlbumId == albumId);
            }
        }

        public List<AlbumEntity> GetAll()
        {
            using (MvcApplicationDB _context = new MvcApplicationDB())
            {
                return _context.Albums.ToList();
            }
        }

        public AlbumEntity Add(AlbumEntity newAlbum, int userId)
        {
            using (MvcApplicationDB _context = new MvcApplicationDB())
            {
                //get the owner of the album
                var albumUser = _context.Users.Where(u => u.UserId == userId)
                    .FirstOrDefault();

                //set some properties of the new album
                //newAlbum.AlbumId = Guid.NewGuid();
                newAlbum.DateCreated = DateTime.Now;
                newAlbum.Photos = new List<PhotoEntity>();
                newAlbum.User = albumUser;
                newAlbum.Comments = new List<CommentEntity>();

                //add the album to the users albums
                albumUser.Albums.Add(newAlbum);
                //_context.Albums.Add(newAlbum);

                _context.SaveChanges();

                return newAlbum;
            }

        }
    }
}
