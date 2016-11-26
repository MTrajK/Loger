using Loger.Common.Data;
using Loger.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loger.DAL.IDataAccess
{
    public interface IAccountDA
    {
        List<User> GetLoginUsers(Login user);
        List<User> GetUserByEmail(string email);
        List<User> GetUserByUsername(string username);
        User AddNewUser(User user);
    }
}
