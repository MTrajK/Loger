using Loger.Common.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loger.DAL.Setup
{
    class LogerInitializer : DropCreateDatabaseIfModelChanges<LogerContext>
    {
        /*
         You can insert data into your database tables during the database initialization process. 
         This will be important if you want to provide some test data for your application or to
         provide some default master data for your application.
        */
        protected override void Seed(LogerContext context)
        {

            base.Seed(context);

            // Example start data
            // The seed method won't be called until the context is used (when changes are maked in model).
            // The seed method also won't be called until all connections to the db are not closed

            // from LogerSeed.sql, for all 5 users passwords are " Password1! "
            var baseDir = AppDomain.CurrentDomain.BaseDirectory.Replace("Loger.UI", "Loger.DAL\\Setup");
            context.Database.ExecuteSqlCommand(File.ReadAllText(baseDir+"LogerSeed.sql"));

            /*
            context.Users.Add(new User { Username = "prv", Password = "12345678", Email = "proben", AccountPhotoURL = null, CreatedDate = DateTime.Now });
            context.Users.Add(new User { Username = "vtor", Password = "12345678", Email = "proben", AccountPhotoURL = null, CreatedDate = DateTime.Now });
            context.Users.Add(new User { Username = "tret", Password = "12345678", Email = "proben", AccountPhotoURL = null, CreatedDate = DateTime.Now });
            context.Users.Add(new User { Username = "cetvrt", Password = "12345678", Email = "proben", AccountPhotoURL = null, CreatedDate = DateTime.Now });

            context.SaveChanges();

            context.Follows.Add(new Follow { UserFollowingID = 1, UserFollowedID = 2, CreatedDate = DateTime.Now });
            context.Follows.Add(new Follow { UserFollowingID = 3, UserFollowedID = 4, CreatedDate = DateTime.Now });
            context.Follows.Add(new Follow { UserFollowingID = 4, UserFollowedID = 1, CreatedDate = DateTime.Now });

            context.SaveChanges();

            context.Photos.Add(new Photo { URL = "~/App_Data/slika1.jpg", Title = "prva slika", Description = "Opis na prvata slika", CreatedDate = DateTime.Now, UserID = 1 });
            context.Photos.Add(new Photo { URL = "~/App_Data/slika2.jpg", Title = "vtora slika", Description = "Opis na vtorata slika", CreatedDate = DateTime.Now, UserID = 2 });
            context.Photos.Add(new Photo { URL = "~/App_Data/slika3.jpg", Title = "treta slika", Description = "Opis na tretata slika", CreatedDate = DateTime.Now, UserID = 3 });
            context.Photos.Add(new Photo { URL = "~/App_Data/slika4.jpg", Title = "cetvrta slika", Description = "Opis na cetvrtata slika", CreatedDate = DateTime.Now, UserID = 4 });
            context.Photos.Add(new Photo { URL = "~/App_Data/slika5.jpg", Title = "petta slika", Description = "Opis na pettata slika", CreatedDate = DateTime.Now, UserID = 1 });

            context.SaveChanges();

            context.Likes.Add(new Like { CreatedDate = DateTime.Now, UserID = 1, PhotoID = 2 });
            context.Likes.Add(new Like { CreatedDate = DateTime.Now, UserID = 3, PhotoID = 2 });
            context.Likes.Add(new Like { CreatedDate = DateTime.Now, UserID = 4, PhotoID = 2 });
            context.Likes.Add(new Like { CreatedDate = DateTime.Now, UserID = 2, PhotoID = 1 });
            context.Likes.Add(new Like { CreatedDate = DateTime.Now, UserID = 4, PhotoID = 1 });

            context.SaveChanges();

            context.Comments.Add(new Comment { Content = "Prv komentar na slika", CreatedDate = DateTime.Now, PhotoID = 1, UserID = 2 });
            context.Comments.Add(new Comment { Content = "Vtor komentar na slika", CreatedDate = DateTime.Now, PhotoID = 1, UserID = 3 });
            context.Comments.Add(new Comment { Content = "Tret komentar na slika", CreatedDate = DateTime.Now, PhotoID = 1, UserID = 4 });
            context.Comments.Add(new Comment { Content = "Cetvrt komentar na slika", CreatedDate = DateTime.Now, PhotoID = 1, UserID = 2 });
            context.Comments.Add(new Comment { Content = "Petti komentar na slika", CreatedDate = DateTime.Now, PhotoID = 3, UserID = 2 });

            context.SaveChanges();
            */

        }
    }
}
