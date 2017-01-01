using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhotoExplorer.Data.Entities;
using PhotoExplorer.Web.Models;

namespace PhotoExplorer.Web.helpers
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