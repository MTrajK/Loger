using Loger.Common.Data;
using Loger.Common.ViewModels;
using Loger.DAL.IDataAccess;
using Loger.DAL.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loger.DAL.DataAccess
{
    public class AccountDA : IAccountDA
    {

        private ILogerContext _dbContext;

        public AccountDA(ILogerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<User> GetLoginUsers(Login user)
        {
            List<User> users = _dbContext.GetUsers().Where(u => u.Email == user.Email && u.Password == user.Password).ToList();
            return users;
        }

        public List<User> GetUserByEmail(string email)
        {
            List<User> users = _dbContext.GetUsers().Where(u => u.Email == email).ToList();
            return users;
        }

        public List<User> GetUserByUsername(string username)
        {
            List<User> users = _dbContext.GetUsers().Where(u => u.Username == username).ToList();
            return users;
        }

        public User AddNewUser(User user)
        {
            User newUser = _dbContext.GetUsers().Add(user);
            _dbContext.Save();
            return newUser;
        }

    }
}
