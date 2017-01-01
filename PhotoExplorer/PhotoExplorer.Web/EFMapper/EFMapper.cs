using PhotoExplorer.Data.Entities;
using PhotoExplorer.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoExplorer.Web.EFMapper
{
    public class EFMapper
    {
        public static UserDetailsViewModel EntityToModel(UserEntityModel entity)
        {
            UserDetailsViewModel model = new UserDetailsViewModel()
            {
                Id = entity.Id,
                Username = entity.Username,
                Fullname = entity.Fullname,
                Albums = entity.Albums,
                DateRegistered = entity.DateRegistered,
                Email = entity.Email,
            };

            return model;
        }
    }
}