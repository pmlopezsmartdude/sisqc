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



namespace Mainsite.Admsistema
{
    public partial class impresoras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
   
        }
        protected void impresorasgrid_indexchanged(object sender, EventArgs e)
        {
            Label_nimp.Text = impresorasGrid.SelectedRow.Cells[1].Text;
            //DropDownList1.SelectedValue = impresorasGrid.SelectedRow.Cells[2].Text;
            //txt_marca.Text = impresorasGrid.SelectedRow.Cells[2].Text;
            lbl_marca.Text = impresorasGrid.SelectedRow.Cells[2].Text;
            txt_ip.Text = impresorasGrid.SelectedRow.Cells[3].Text;
            Lbl_puerto.Text = impresorasGrid.SelectedRow.Cells[4].Text;
            impEditOrder.Show();
        }
        protected void btnClose_Click(object sender, EventArgs e)
        {
            impEditOrder.Hide();
        }
        protected void AskMessage(object sender, EventArgs e)
        {
            ModalPopupExtender2.Show();
        }
        protected void limpiaagrimp(object sender, EventArgs e)
        {
            txtnomimpr.Text = "";
            newimpip.Text = "";
            newimpport.Text = "9100";
        }
        protected void btnagregar(object sender, EventArgs e)
        {
        }
        protected void pruebaimp(object sender, EventArgs e)
        {
            int port = 9100;
            string str = impresorasGrid.SelectedRow.Cells[2].Text;
            switch (str)
            {
                case "bixolon             ":
                    AppModules.impresion.imprimebixolon(txt_ip.Text, port, "Ingles", "Español", "Variedad", "XXL", "R", "CAT 1", "X KG", "AAAAAA", "000001", "00001", "06/01/15", "000000", "88888", "RM", "PROVINCIA", "COMUNA", "88888", "Soc. ficticia solo prueba", "99999", "Packing, Ubicación, Provincia", "9_2", "T123", "14010925551234");
                    break;
                default:
                    break;
            }

        }
        protected void DeleteImpresora(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Label_nimp.Text))
            {
                System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/trazabilidad");
                System.Configuration.ConnectionStringSettings trazabilidadconnstring;
                trazabilidadconnstring = rootWebConfig.ConnectionStrings.ConnectionStrings["trazabilidad"];
                SqlConnection con = new SqlConnection(trazabilidadconnstring.ToString());
                con.Open();
                SqlCommand cmd_impdel = new SqlCommand("delete from impresoras where nombre = '" +Label_nimp.Text+ "'", con);
                try
                {
                    cmd_impdel.ExecuteNonQuery();
                }
                catch (SystemException ex)
                {
                    string error = "";
                    Response.Write("<script languaje=javascript > alert('" + error + ex + "'); </script>");
                }
                finally
                {
                    con.Close();
                }

                //ImpresoraDelete(Label_nimp.Text);
                impresorasGrid.DataBind();
            }

        }
 
     }  
}