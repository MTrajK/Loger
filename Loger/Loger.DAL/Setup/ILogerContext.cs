using Loger.Common.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loger.DAL.Setup
{
    public interface ILogerContext
    {
        DbSet<User> GetUsers();
        DbSet<Photo> GetPhotos();
        DbSet<Like> GetLikes();
        DbSet<Comment> GetComments();
        DbSet<Follow> GetFollows();
        int Save();
    }
}
