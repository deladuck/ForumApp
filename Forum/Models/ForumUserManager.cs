using Forum.App_Start;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Models {
    public class ForumUserManager : UserManager<ApplicationUser>{

        public ForumUserManager(IUserStore<ApplicationUser> store) : base(store) {

        }

        public static ForumUserManager Create(IdentityFactoryOptions<ForumUserManager> options, IOwinContext context) {
            UserIdentityContext db = context.Get<UserIdentityContext>();
            ForumUserManager manager = new ForumUserManager(new UserStore<ApplicationUser>(db));

            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null) {
                manager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("Forum_Protection_Provider"));
            }

            manager.EmailService = new EmailService();
            return manager;
        }

    }
}