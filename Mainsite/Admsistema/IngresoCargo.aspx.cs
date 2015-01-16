using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mainsite.Admsistema
{
    public partial class IngresoCargo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void AceptarCargo(object sender, EventArgs e)
        {

            Response.Redirect("~/Admsistema/IngresoEmpleados.aspx");
        }

    }
}