using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System;

namespace PhotoExplorer.Web.Models
{
    // You can add profile data for the user by adding more properties to your UserModel class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class UserModel : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<UserModel> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        //custom properties for UserModel
        public UserModel()
        {
            Albums = new List<AlbumModel>();
            DateRegistered = DateTime.Now;
        }

        public string Fullname { get; set; }
        public DateTime? DateRegistered { get; set; }

        //slow apps do alot of eager-loading    (loading things right away). 
        //Fast apps do alot of lazy-loading     (only loading things when they are needed)

        //non-virtual property -        lazy load disabled
        //virtual property -            lazy load enabled (for specific navigation property)
        public virtual ICollection<AlbumModel> Albums { get; set; }
    }

    public class PhotoExplorerDbContext : IdentityDbContext<UserModel>
    {
        public PhotoExplorerDbContext(): base("PhotoExplorerConnectionString", throwIfV1Schema: false)
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<PhotoExplorerDbContext>());
        }

        public DbSet<AlbumModel> Albums { get; set; }
        public DbSet<PhotoModel> Photos { get; set; }

        public static PhotoExplorerDbContext Create()
        {
            return new PhotoExplorerDbContext();
        }
    }
}