using MvcLab.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MvcLab.Data.Repositories
{
    public class AlbumRepository
    {
        private MvcLabContext _context;

        public AlbumEntity Get(Guid albumId)
        {
            using (_context = new MvcLabContext())
            {
                return _context.Albums.FirstOrDefault(a => a.Id == albumId);
            }
        }


        public List<AlbumEntity> GetAll()
        {
            List<AlbumEntity> albums = new List<AlbumEntity>();

            using (_context = new MvcLabContext())
            {
                albums = _context.Albums.ToList();
            }

            return albums;
        }

        public AlbumEntity Add(AlbumEntity newAlbum, Guid userId)
        {
            using (_context = new MvcLabContext())
            {
                //get the owner of the album
                var albumUser = _context.Users.Where(u => u.Id == userId).FirstOrDefault();

                //set some properties of the new album
                newAlbum.Id = Guid.NewGuid();
                newAlbum.DateCreated = DateTime.Now;
                newAlbum.Photos = new List<PhotoEntity>();
                newAlbum.User = albumUser;
                newAlbum.Comments = new List<CommentEntity>();

                //add the album to the users albums
                albumUser.Albums.Add(newAlbum);
                //_context.Albums.Add(newAlbum);

                _context.SaveChanges();
            }

            return newAlbum;
        }

    }
}
