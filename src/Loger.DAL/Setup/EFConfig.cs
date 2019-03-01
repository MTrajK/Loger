using Loger.Common.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loger.DAL.Setup
{
    public class EFConfig
    {

        public static string ConnectionString;

        public static void RegisterDatabase(string connectionString)
        {
            ConnectionString = connectionString;
            Database.SetInitializer<LogerContext>(new LogerInitializer());
        }
    }
}
