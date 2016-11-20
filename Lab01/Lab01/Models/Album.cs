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
        public int PhotoCount
        {
            get
            {
                if (Photos == null)
                    return 0;
                else
                    return Photos.Count;
            }
        }
        public DateTime DateCreated { get; set; }

        
    }
}