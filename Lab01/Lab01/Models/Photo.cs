using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab01.Models
{
    public class Photo
    {
        public Guid ImageId { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
    }
}