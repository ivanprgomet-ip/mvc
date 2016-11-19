using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab01.Models
{
    public class Album
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Photo> Photos { get; set; }
    }
}