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
            using (MvcApplicationDB _context = new MvcApplicationDB())
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
            using (MvcApplicationDB _context = new MvcApplicationDB())
            {
                PhotoEntity photoToBeRemoved = _context.Photos
                    .FirstOrDefault(p => p.PhotoEntityId == photo.PhotoEntityId);

                _context.Photos.Remove(photoToBeRemoved);

                _context.SaveChanges();
            }
        }

        public PhotoEntity GetPhoto(int id)
        {
            using (MvcApplicationDB _context = new MvcApplicationDB())
            {
                return _context.Photos.FirstOrDefault(p => p.PhotoEntityId == id);
            }
        }
    }
}
