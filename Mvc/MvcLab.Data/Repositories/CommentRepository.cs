using MvcLab.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcLab.Data.Repositories
{
    public class CommentRepository
    {
        MvcLabContext _context;
        public void NewAlbumComment(Guid albumid, CommentEntity newAlbumComment)
        {
            using (_context = new MvcLabContext())
            {
                var albumEntity = _context.Albums.FirstOrDefault(a => a.Id == albumid);

                albumEntity.Comments.Add(newAlbumComment);

                _context.SaveChanges();
            }
        }
    }
}
