using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Security;
using System.Security.Cryptography;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Mainsite.AppModules
{
    public class ImpresorasDatos
    {
        public static object verificaip(string ip)
        {
            if (!String.IsNullOrEmpty(ip))
            {
                System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisqc");
                System.Configuration.ConnectionStringSettings trazabilidadconnstring;
                trazabilidadconnstring = rootWebConfig.ConnectionStrings.ConnectionStrings["trazabilidad"];
                SqlConnection con = new SqlConnection(trazabilidadconnstring.ToString());
                con.Open();
                
            }
            return 0;
        }

    }
}