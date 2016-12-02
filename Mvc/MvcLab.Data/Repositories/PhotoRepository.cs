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
        public List<PhotoEntity> RetrieveAll()
        {
            using (MvcLabContext _context = new MvcLabContext())
            {
                List<PhotoEntity> allPhotosFromDB = _context.Photos.ToList();

                return allPhotosFromDB;
            }

        }

        public void CreatePhoto(PhotoEntity photo)
        {
            //todo: create photo method
        }

        public void DeletePhoto(PhotoEntity photo)
        {
            using (MvcLabContext _context = new MvcLabContext())
            {
                PhotoEntity photoToBeRemoved = _context.Photos
                    .FirstOrDefault(p => p.PhotoId == photo.PhotoId);

                _context.Photos.Remove(photoToBeRemoved);

                _context.SaveChanges();
            }
        }

        public PhotoEntity GetPhoto(Guid id)
        {
            using (MvcLabContext _context = new MvcLabContext())
            {
                return _context.Photos.FirstOrDefault(p => p.PhotoId == id);
            }
        }
    }
}
