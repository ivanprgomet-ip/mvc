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
        public void NewAlbumComment(Guid albumid, CommentEntity newAlbumComment)
        {
            using (MvcLabContext _context = new MvcLabContext())
            {
                var albumEntity = _context.Albums.FirstOrDefault(a => a.AlbumId == albumid);

                albumEntity.Comments.Add(newAlbumComment);

                _context.SaveChanges();
            }
        }
    }
}
