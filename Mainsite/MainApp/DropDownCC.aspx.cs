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
    public partial class DropDownCC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                DropPlanta();
                Session["PlantaName"] = DropPlanta_d.Text;
                string planta = Convert.ToString(DropPlanta_d.SelectedValue);

                filtra_botones(planta);
     
 
            }



        }

        private void DropPlanta()
        {
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisconpt");
            System.Configuration.ConnectionStringSettings connStringmain;
            connStringmain = rootWebConfig.ConnectionStrings.ConnectionStrings["CONTROLPTConnectionString"];
            SqlConnection con = new SqlConnection(connStringmain.ToString());
            con.Open();
            string DDL_planta = "SELECT [pladescri] FROM [planta] ";

            SqlCommand cmd_linea = new SqlCommand(DDL_planta, con);
            SqlDataAdapter sda_linea = new SqlDataAdapter(cmd_linea);
            DataSet ds_linea = new DataSet();
            sda_linea.Fill(ds_linea);
            DropPlanta_d.DataSourceID = "";
            DropPlanta_d.DataSource = ds_linea;
            DropPlanta_d.DataBind();

            con.Close();


        }
        protected void btnEdit_Click(object sender, ImageClickEventArgs e)
        {
            
        }

        protected void planta_SelectedIndexChanged(object sender, EventArgs e)
        {

            Session["PlantaName"] = DropPlanta_d.Text;
            string planta = Convert.ToString(DropPlanta_d.SelectedValue);

            filtra_botones(planta);

        }

        private void filtra_botones(string planta)
        {
            if (planta == "Planta Mostazal" || planta == "Planta Molina")
            {
                link_ing005.Visible = true;
                link_ing003.Visible = true;
                link_ing075.Visible = true;
                link_ing005_manual.Visible = false;
                link_ing003_manual.Visible = false;

            }
            else
            {
                link_ing005.Visible = false;
                link_ing005_manual.Visible = true;
                link_ing003_manual.Visible = true;
                link_ing003.Visible = false;
                link_ing075.Visible = false;
              
            }
        }




    }
}