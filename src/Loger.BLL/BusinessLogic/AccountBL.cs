using Loger.BLL.IBusinessLogic;
using Loger.Common.Data;
using Loger.Common.ViewModels;
using Loger.DAL.IDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Loger.BLL.BusinessLogic
{
    public class AccountBL : IAccountBL
    {

        private IAccountDA _accountDA;

        public AccountBL(IAccountDA accountDA)
        {
            _accountDA = accountDA;
        }

        public Tuple<string, int> CheckUser(Login user)
        {
            // Converting (encrypt) user plain text password into hashed
            byte[] data = Encoding.ASCII.GetBytes(user.Password);
            data = new SHA256Managed().ComputeHash(data);
            user.Password = Encoding.ASCII.GetString(data);

            List<User> usersInfo = _accountDA.GetLoginUsers(user);

            if (usersInfo.Count == 1)
            {
                return new Tuple<string, int>("success", usersInfo.ElementAt(0).ID);
            } else
            {
                return new Tuple<string, int>("fail", -1);
            }

        }

        public Tuple<string, int> RegisterUser(Register user)
        {
            // Converting (encrypt) user plain text password into hashed
            byte[] data = Encoding.ASCII.GetBytes(user.Password);
            data = new SHA256Managed().ComputeHash(data);
            user.Password = Encoding.ASCII.GetString(data);

            List<User> usersByEmail = _accountDA.GetUserByEmail(user.Email);
            if (usersByEmail.Count != 0)
            {
                return new Tuple<string, int>("email exist", -1);
            }

            List<User> usersByUsername = _accountDA.GetUserByUsername(user.Username);
            if (usersByUsername.Count != 0)
            {
                return new Tuple<string, int>("username exist", -1);
            }

            User newUser = new User
            {
                Email = user.Email,
                Username = user.Username,
                Password = user.Password,
                AccountPhotoURL = @"/Images/user.jpg",
                CreatedDate = DateTime.Now
            };
            User addedUser = _accountDA.AddNewUser(newUser);
            
            if (addedUser != null)
            {
                return new Tuple<string, int>("success", addedUser.ID);
            } else
            {
                return new Tuple<string, int>("fail", -1);
            }
        }

    }
}
