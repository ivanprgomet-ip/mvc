using PhotoExplorer.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoExplorer.Data.Repositories
{
    public class CommentRepository
    {
        public void NewAlbumComment(int albumid, CommentEntityModel newAlbumComment)
        {
            using (PhotoExplorerEntities _context = new PhotoExplorerEntities())
            {
                var albumEntity = _context.Albums.FirstOrDefault(a => a.Id == albumid);

                albumEntity.Comments.Add(newAlbumComment);

                _context.SaveChanges();
            }
        }
    }
}
