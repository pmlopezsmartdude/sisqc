using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace Mainsite.Reporte
{
    public partial class ReporteCCPAC075Prueba1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ReportDocument rptDoc = new ReportDocument();
            CC_PAC_075_prueba1 ds = new CC_PAC_075_prueba1(); // .xsd file name
            DataTable dt = new DataTable();

            // Just set the name of data table
            dt.TableName = "Crystal Report Example";
            dt = getAllOrders(); //This function is located below this function
            ds.Tables[0].Merge(dt);

            // Your .rpt file path will be below
            rptDoc.Load(Server.MapPath("~/Reporte/CC_PAC_075_prueba1rpt.rpt"));

            //set dataset to the report viewer.
            rptDoc.SetDataSource(ds);
            CrystalReportViewer1.ReportSource = rptDoc;

        }

        public DataTable getAllOrders()
        {
            //Connection string replace 'databaseservername' with your db server name
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisqc");
            System.Configuration.ConnectionStringSettings connStringLM;
            connStringLM = rootWebConfig.ConnectionStrings.ConnectionStrings["CONTROLPTConnectionString"];
            SqlConnection Con = new SqlConnection(connStringLM.ToString());

            SqlCommand cmd = new SqlCommand();
            DataSet ds = null;
            SqlDataAdapter adapter;
            //try
            //{
                Con.Open();
                //Stored procedure calling. It is already in sample db.
                cmd.CommandText = "getAllOrders";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Con;
                ds = new DataSet();
                adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds, "Users");
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //}
            //finally
            //{
            //    cmd.Dispose();
            //    if (Con.State != ConnectionState.Closed)
            //        Con.Close();
            //}
            return ds.Tables[0];
        }
    }
}