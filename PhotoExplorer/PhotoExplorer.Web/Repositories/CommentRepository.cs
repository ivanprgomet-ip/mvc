using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoExplorer.Web.Models;

namespace PhotoExplorer.Web.Repositories
{
    public class CommentRepository
    {
        public void NewAlbumComment(int albumid, CommentModel newAlbumComment)
        {
            using (PhotoExplorerDbContext _context = new PhotoExplorerDbContext())
            {
                var albumEntity = _context.Albums.FirstOrDefault(a => a.Id == albumid);

                albumEntity.Comments.Add(newAlbumComment);

                _context.SaveChanges();
            }
        }
    }
}
