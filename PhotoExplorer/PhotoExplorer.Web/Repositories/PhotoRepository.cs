﻿using PhotoExplorer.Web.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcLab.Web.Repositories
{
    public class PhotoRepository
    {
        public List<PhotoEntityModel> RetrieveAll()
        {
            using (PhotoExplorerContext _context = new PhotoExplorerContext())
            {
                List<PhotoEntityModel> allPhotosFromDB = _context.Photos.ToList();

                return allPhotosFromDB;
            }

        }

        public void CreatePhoto(PhotoEntityModel photo)
        {
            //todo: create photo method
        }

        public void DeletePhoto(PhotoEntityModel photo)
        {
            using (PhotoExplorerContext _context = new PhotoExplorerContext())
            {
                PhotoEntityModel photoToBeRemoved = _context.Photos
                    .FirstOrDefault(p => p.Id == photo.Id);

                _context.Photos.Remove(photoToBeRemoved);

                _context.SaveChanges();
            }
        }

        public PhotoEntityModel GetPhoto(int id)
        {
            using (PhotoExplorerContext _context = new PhotoExplorerContext())
            {
                return _context.Photos.FirstOrDefault(p => p.Id == id);
            }
        }
    }
}
