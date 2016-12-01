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

            using (_context= new MvcLabContext())
            {
                foreach (var photo in _context.Photos.ToList())
                {
                    photos.Add(photo);
                }
            }

            return photos;
        }

    }
}
