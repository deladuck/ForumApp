using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Models {
    public class UserIdentityContext : IdentityDbContext<ApplicationUser> {
        public UserIdentityContext() : base("ForumContext") { }

        public static UserIdentityContext Create() {
            return new UserIdentityContext();
        }
    }
}