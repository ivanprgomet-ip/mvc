using PhotoExplorer.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoExplorer.Data.Repositories
{
    public class PhotoRepository
    {
        public List<PhotoEntityModel> RetrieveAll()
        {
            using (PhotoExplorerEntities _context = new PhotoExplorerEntities())
            {
                List<PhotoEntityModel> allPhotosFromDB = _context.Photos.ToList();

                return allPhotosFromDB;
            }

        }

        public void CreatePhoto(PhotoEntityModel photo)
        {
            //todo: create photo method
        }

        public void DeletePhoto(int id)
        {
            //using (PhotoExplorerEntities _context = new PhotoExplorerEntities())
            //{
            //    PhotoEntityModel photoToBeRemoved = _context.Photos
            //        .FirstOrDefault(p => p.Id == photo.Id);

            //    _context.Photos.Remove(photoToBeRemoved);

            //    _context.SaveChanges();
            //}

            using (PhotoExplorerEntities cx = new PhotoExplorerEntities())
            {
                cx.Photos.Remove(cx.Photos.FirstOrDefault(p => p.Id == id));

                cx.SaveChanges();
            }
        }

        public PhotoEntityModel GetPhoto(int id)
        {
            using (PhotoExplorerEntities _context = new PhotoExplorerEntities())
            {
                return _context.Photos.FirstOrDefault(p => p.Id == id);
            }
        }

        public void UpdatePhoto(int id, string photoName, string photoDescription)
        {
            using (PhotoExplorerEntities cx = new PhotoExplorerEntities())
            {
                //retrieve photo and update with new info
                PhotoEntityModel entity = cx.Photos.FirstOrDefault(p => p.Id == id);

                entity.Name = photoName;

                entity.Description = photoDescription;

                entity.DateChanged = DateTime.Now;

                cx.SaveChanges();
            }
        }
    }
}
