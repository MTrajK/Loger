using Loger.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loger.BLL.IBusinessLogic
{
    public interface IAccountBL
    {
        Tuple<string, int> CheckUser(Login user);
        Tuple<string, int> RegisterUser(Register user);
    }
}
