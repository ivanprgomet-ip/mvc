using System.IO;
using System.Collections.Generic;

namespace Lab01.Models
{
    public class GalleryModel
    {
        public string GalleryName { get; set; }
        public string GalleryOwner { get; set; }
        public List<string> ImagePaths { get; set; }
    }
}