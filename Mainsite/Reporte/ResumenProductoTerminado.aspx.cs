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
using Mainsite.xsd;

namespace Mainsite.Reporte
{
    public partial class ResumenProductoTerminado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ReportDocument rptDoc = new ReportDocument();
            ProductoTerminado ds = new ProductoTerminado(); // .xsd file name
            DataTable dt = new DataTable();

            // Just set the name of data table
            dt.TableName = "Crystal Report Example";
            dt = ObtenerProductoTerminado(); //This function is located below this function
            ds.Tables[0].Merge(dt);

            // Your .rpt file path will be below
            rptDoc.Load(Server.MapPath("../RPT/ProductoTerminadoReporte.rpt"));

            //set dataset to the report viewer.
            rptDoc.SetDataSource(ds);
            CrystalReportViewer1.ReportSource = rptDoc;
        }

        public DataTable ObtenerProductoTerminado()
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
            cmd.CommandText = "ReporteProductoTerminado";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = Con;
            ds = new DataSet();
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds, "Users");
          
            return ds.Tables[0];
        }
    }
}