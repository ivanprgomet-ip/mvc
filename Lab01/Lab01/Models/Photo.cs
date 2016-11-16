using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab01.Models
{
    public class Photo
    {
        public Guid Id { get; set; }
        public string Path { get; set; }
        public string Description { get; set; }
    }
}