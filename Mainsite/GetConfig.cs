using System;
using System.Configuration;
using System.Web.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mainsite
{
    public class GetConfig
    {
        public static string GetConnectionStringByName(string name)
        {
            string returnValue = null;
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[name];
            if (settings != null)
                returnValue = settings.ConnectionString;
            return returnValue;
        }
     }
}