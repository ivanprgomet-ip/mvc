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
        public void NewAlbumComment(int albumid, CommentEntity newAlbumComment)
        {
            using (MvcApplicationDB _context = new MvcApplicationDB())
            {
                var albumEntity = _context.Albums.FirstOrDefault(a => a.AlbumId == albumid);

                albumEntity.Comments.Add(newAlbumComment);

                _context.SaveChanges();
            }
        }
    }
}
