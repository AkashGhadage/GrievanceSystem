using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrievanceSystem_Mvc.Repositories
{
    internal class Helper
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        }

      
    }
}
