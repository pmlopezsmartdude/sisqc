using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;

namespace Mainsite.MainApp
{
    public partial class menuadmusr : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TreeViewAdmUsr.Visible = false;
            string[] roles = Roles.GetRolesForUser();
           
            foreach (string r in roles)
            {
                if (r == "Administrador")
                {
                    TreeViewAdmUsr.Visible = true;

                    break;
                }
                else
                {
                    if (r == "usuario")
                    {
                        TreeViewAdmUsr.Visible = false;
                        break;
                    }

                }

            }
        }
    }
}