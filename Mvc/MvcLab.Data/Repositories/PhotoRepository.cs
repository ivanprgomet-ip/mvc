using MvcLab.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcLab.Data.Repositories
{
    public class PhotoRepository
    {
        MvcLabContext _context;

        public List<PhotoEntity> RetrieveAll()
        {
            List<PhotoEntity> photos = new List<PhotoEntity>();

            using (_context = new MvcLabContext())
            {
                foreach (var photo in _context.Photos.ToList())
                {
                    photos.Add(photo);
                }
            }

            return photos;
        }

        public void CreatePhoto(PhotoEntity photo)
        {
            //todo: point of this method?
            photo.DateCreated = DateTime.Now;
            photo.Id = Guid.NewGuid();
        }

        public void DeletePhoto(PhotoEntity photo)
        {
            using (_context = new MvcLabContext())
            {
                var photoToBeRemoved = _context.Photos.FirstOrDefault(p => p.Id == photo.Id);

                _context.Photos.Remove(photoToBeRemoved);

                _context.SaveChanges();
            }
        }

        public PhotoEntity GetPhoto(Guid id)
        {
            using (_context = new MvcLabContext())
            {
                return _context.Photos.FirstOrDefault(p => p.Id == id);
            }
        }
    }
}
