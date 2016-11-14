using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab01.Models
{
    public class UserModel
    {
        public string UserName { get; set; }
        public DateTime UserBirth { get; set; }
        public string UserCity { get; set; }
        public UserModel(string username, string usercity, DateTime userbirth)
        {
            this.UserName = username;
            this.UserCity = usercity;
            this.UserBirth = userbirth;
        }
    }
}