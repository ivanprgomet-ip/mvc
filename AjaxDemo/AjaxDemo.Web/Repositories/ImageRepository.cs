using AjaxDemo.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AjaxDemo.Web.Repositories
{
    public class ImageRepository
    {
        private static List<ImageViewModel> Images { get; set; } 

        public ImageRepository()
        {
            Images = new List<ImageViewModel>();

            if (!Images.Any())
            {
                Images = new List<ImageViewModel>()
                {
                    new ImageViewModel()
                    {
                        Id = Guid.NewGuid(),
                        Name = "brela1",
                        Filename="brela1.jpg",
                    },
                    new ImageViewModel()
                    {
                        Id = Guid.NewGuid(),
                        Name = "brela2",
                        Filename="brela2.jpg",
                    },
                };
            }
        }

        public static void Add(ImageViewModel image)
        {
            Images.Add(image);
        }
        public static void Remove(ImageViewModel image)
        {
            Images.Remove(image);
        }
        public static List<ImageViewModel> GetImages()
        {
            return Images;
        }
    }
}