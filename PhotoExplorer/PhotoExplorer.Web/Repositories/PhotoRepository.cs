using PhotoExplorer.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcLab.Web.Repositories
{
    public class PhotoRepository
    {
        public List<PhotoViewModel> RetrieveAll()
        {
            using (PhotoExplorerContext _context = new PhotoExplorerContext())
            {
                List<PhotoViewModel> allPhotosFromDB = _context.Photos.ToList();

                return allPhotosFromDB;
            }

        }

        public void CreatePhoto(PhotoViewModel photo)
        {
            //todo: create photo method
        }

        public void DeletePhoto(PhotoViewModel photo)
        {
            using (PhotoExplorerContext _context = new PhotoExplorerContext())
            {
                PhotoViewModel photoToBeRemoved = _context.Photos
                    .FirstOrDefault(p => p.Id == photo.Id);

                _context.Photos.Remove(photoToBeRemoved);

                _context.SaveChanges();
            }
        }

        public PhotoViewModel GetPhoto(int id)
        {
            using (PhotoExplorerContext _context = new PhotoExplorerContext())
            {
                return _context.Photos.FirstOrDefault(p => p.Id == id);
            }
        }
    }
}
