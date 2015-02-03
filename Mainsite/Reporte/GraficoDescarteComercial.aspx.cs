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

namespace Mainsite.Reporte
{
    public partial class GraficoDescarteComercial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropPlanta();
                
            }

        }


        private void DropPlanta()
        {
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisqc");
            System.Configuration.ConnectionStringSettings connStringLM;
            connStringLM = rootWebConfig.ConnectionStrings.ConnectionStrings["CONTROLPTConnectionString"];
            SqlConnection con = new SqlConnection(connStringLM.ToString());
            con.Open();
            //linea
            SqlCommand cmd_proc = new SqlCommand("select distinct  cc.planta as plantaid, pl.pladescri as planta from cc_pac_075_v2 as cc inner join planta as pl on cc.planta=pl.placodigo order by plantaid asc", con);
            SqlDataAdapter sda_proc = new SqlDataAdapter(cmd_proc);
            DataSet ds_proc = new DataSet();
            try
            {
                sda_proc.Fill(ds_proc);

                ddl_planta_d.DataSourceID = "";
                ddl_planta_d.DataSource = ds_proc;
                ddl_planta_d.DataBind();
                ddl_planta_d.Items.Add("Todas");
                ddl_planta_d.SelectedIndex = -1;
                ddl_planta_d.Items.FindByText("Todas").Selected = true;
                
                
            }
            catch
            {
                ddl_planta_d.DataSourceID = "";
                ddl_planta_d.DataSource = "";
                ddl_planta_d.DataBind();
            }

            string planta = ddl_planta_d.SelectedValue;
            DropLinea(planta);

            con.Close();
        }
        protected void planta_SelectedIndexChanged(object sender, EventArgs e)
        {
            string planta = ddl_planta_d.SelectedValue;
            DropLinea(planta);
        }

        private void DropLinea(string planta)
        {
            string inicio = "select distinct linea from cc_pac_075_v2 where fecha>'1990-01-01' ";
            string fin = " order by linea";

            string cons_planta = "";
            if (planta != "Todas")
            {
                cons_planta = " and planta='" + planta + "' ";
            }

            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisqc");
            System.Configuration.ConnectionStringSettings connStringLM;
            connStringLM = rootWebConfig.ConnectionStrings.ConnectionStrings["CONTROLPTConnectionString"];
            SqlConnection con = new SqlConnection(connStringLM.ToString());
            con.Open();
            SqlCommand cmd_proc = new SqlCommand(inicio + cons_planta + fin, con);
            SqlDataAdapter sda_proc = new SqlDataAdapter(cmd_proc);
            DataSet ds_proc = new DataSet();
            try
            {
                sda_proc.Fill(ds_proc);

                ddl_linea_d.DataSourceID = "";
                ddl_linea_d.DataSource = ds_proc;
                ddl_linea_d.DataBind();
                ddl_linea_d.Items.Add("Todas");
                ddl_linea_d.SelectedIndex = -1;
                ddl_linea_d.Items.FindByText("Todas").Selected = true;

            }
            catch
            {
                ddl_linea_d.DataSourceID = "";
                ddl_linea_d.DataSource = "";
                ddl_linea_d.DataBind();
            }

            string linea = ddl_linea_d.SelectedValue;
            DropTurno(planta, linea);
            con.Close();
        }
        protected void linea_SelectedIndexChanged(object sender, EventArgs e)
        {
            string linea = ddl_linea_d.SelectedValue;
            string planta = ddl_planta_d.SelectedValue;
            DropTurno(planta, linea);
        }

        private void DropTurno(string planta, string linea)
        {
            string inicio = "select distinct turno from cc_pac_075_v2 where fecha>'1990-01-01' ";
            string fin = " order by turno";

            string cons_planta = "";
            if (planta != "Todas")
            {
                cons_planta = " and planta='" + planta + "' ";
            }

            string cons_linea = "";
            if (linea != "Todas")
            {
                cons_linea = " and linea='" + linea + "' ";
            }


            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisqc");
            System.Configuration.ConnectionStringSettings connStringLM;
            connStringLM = rootWebConfig.ConnectionStrings.ConnectionStrings["CONTROLPTConnectionString"];
            SqlConnection con = new SqlConnection(connStringLM.ToString());
            con.Open();
            SqlCommand cmd_proc = new SqlCommand(inicio + cons_planta + cons_linea + fin, con);
            SqlDataAdapter sda_proc = new SqlDataAdapter(cmd_proc);
            DataSet ds_proc = new DataSet();
            try
            {
                sda_proc.Fill(ds_proc);

                ddl_turno_d.DataSourceID = "";
                ddl_turno_d.DataSource = ds_proc;
                ddl_turno_d.DataBind();
                ddl_turno_d.Items.Add("Todos");
                ddl_turno_d.SelectedIndex = -1;
                ddl_turno_d.Items.FindByText("Todos").Selected = true;

            }
            catch
            {
                ddl_turno_d.DataSourceID = "";
                ddl_turno_d.DataSource = "";
                ddl_turno_d.DataBind();
            }

          
            string turno = ddl_turno_d.SelectedValue;
            DropProceso(planta, linea, turno);

            con.Close();
        }
        protected void turno_SelectedIndexChanged(object sender, EventArgs e)
        {
            string planta = ddl_planta_d.SelectedValue;
            string linea = ddl_linea_d.SelectedValue;
            string turno = ddl_turno_d.SelectedValue;
            DropProceso(planta, linea, turno);
        }

        private void DropProceso(string planta, string linea, string turno)
        {
            string inicio = "select distinct CodProc as proceso from cc_pac_075_v2 where fecha>'1990-01-01' ";
            string fin = " order by CodProc";
           
            string cons_planta = "";
            if (planta != "Todas")
            {
                cons_planta = " and planta='" + planta + "' ";
            }

            string cons_linea = "";
            if (linea != "Todas")
            {
                cons_linea = " and linea='" + linea + "' ";
            }

            string cons_turno = "";
            if (turno != "Todos")
            {
                cons_turno = " and turno='" + turno + "' ";
            }

            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisqc");
            System.Configuration.ConnectionStringSettings connStringLM;
            connStringLM = rootWebConfig.ConnectionStrings.ConnectionStrings["CONTROLPTConnectionString"];
            SqlConnection con = new SqlConnection(connStringLM.ToString());
            con.Open();
            SqlCommand cmd_proc = new SqlCommand(inicio + cons_planta + cons_linea + cons_turno + fin, con);
            SqlDataAdapter sda_proc = new SqlDataAdapter(cmd_proc);
            DataSet ds_proc = new DataSet();
            try
            {
                sda_proc.Fill(ds_proc);

                ddl_proceso_d.DataSourceID = "";
                ddl_proceso_d.DataSource = ds_proc;
                ddl_proceso_d.DataBind();
                ddl_proceso_d.Items.Add("Todos");
                ddl_proceso_d.SelectedIndex = -1;
                ddl_proceso_d.Items.FindByText("Todos").Selected = true;

            }
            catch
            {
                ddl_proceso_d.DataSourceID = "";
                ddl_proceso_d.DataSource = "";
                ddl_proceso_d.DataBind();
            }
         
            string proceso = ddl_proceso_d.SelectedValue;
            DropLote(planta, linea, turno, proceso);

            con.Close();
        }
        protected void proceso_SelectedIndexChanged(object sender, EventArgs e)
        {
            string planta = ddl_planta_d.SelectedValue;
            string linea = ddl_linea_d.SelectedValue;
            string turno = ddl_turno_d.SelectedValue;
            string proceso = ddl_proceso_d.SelectedValue;
            DropLote(planta, linea, turno, proceso);
        }

        private void DropLote(string planta, string linea, string turno, string proceso)
        {
            string inicio = "select distinct lote from CC_PAC_075_V2 where fecha>'1990-01-01' ";
            string fin = " order by lote";
            
            string cons_planta = "";
            if (planta != "Todas")
            {
                cons_planta = " and planta='" + planta + "' ";
            }

            string cons_linea = "";
            if (linea != "Todas")
            {
                cons_linea = " and linea='" + linea + "' ";
            }

            string cons_turno = "";
            if (turno != "Todos")
            {
                cons_turno = " and turno='" + turno + "' ";
            }

            string cons_proceso = "";
            if (proceso != "Todos")
            {
                cons_proceso = " and CodProc='" + proceso + "' ";
            }
            

            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisqc");
            System.Configuration.ConnectionStringSettings connStringLM;
            connStringLM = rootWebConfig.ConnectionStrings.ConnectionStrings["CONTROLPTConnectionString"];
            SqlConnection con = new SqlConnection(connStringLM.ToString());
            con.Open();
            SqlCommand cmd_proc = new SqlCommand(inicio + cons_planta + cons_linea + cons_turno + cons_proceso + fin, con);
            SqlDataAdapter sda_proc = new SqlDataAdapter(cmd_proc);
            DataSet ds_proc = new DataSet();
            try
            {
                sda_proc.Fill(ds_proc);

                ddl_lote_d.DataSourceID = "";
                ddl_lote_d.DataSource = ds_proc;
                ddl_lote_d.DataBind();
                ddl_lote_d.Items.Add("Todos");
                ddl_lote_d.SelectedIndex = -1;
                ddl_lote_d.Items.FindByText("Todos").Selected = true;

            }
            catch
            {
                ddl_lote_d.DataSourceID = "";
                ddl_lote_d.DataSource = "";
                ddl_lote_d.DataBind();
            }

            string lote = ddl_lote_d.SelectedValue;
            DropVariedad(planta, linea, turno, proceso, lote);
            con.Close();
        }
        protected void lote_SelectedIndexChanged(object sender, EventArgs e)
        {
            string planta = ddl_planta_d.SelectedValue;
            string linea = ddl_linea_d.SelectedValue;
            string turno = ddl_turno_d.SelectedValue;
            string proceso = ddl_proceso_d.SelectedValue;
            string lote = ddl_lote_d.SelectedValue;
            DropVariedad(planta, linea, turno, proceso, lote);
        }

        private void DropVariedad(string planta, string linea, string turno, string proceso, string lote)
        {
            string inicio = "select distinct variedad from CC_PAC_075_V2 where fecha>'1990-01-01' ";
            string fin = " order by variedad";

            string cons_planta = "";
            if (planta != "Todas")
            {
                cons_planta = " and planta='" + planta + "' ";
            }

            string cons_linea = "";
            if (linea != "Todas")
            {
                cons_linea = " and linea='" + linea + "' ";
            }

            string cons_turno = "";
            if (turno != "Todos")
            {
                cons_turno = " and turno='" + turno + "' ";
            }

            string cons_proceso = "";
            if (proceso != "Todos")
            {
                cons_proceso = " and codproc='" + proceso + "' ";
            }

            string cons_lote = "";
            if (lote != "Todos")
            {
                cons_lote = " and lote='" + lote + "' ";
            }


            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisqc");
            System.Configuration.ConnectionStringSettings connStringLM;
            connStringLM = rootWebConfig.ConnectionStrings.ConnectionStrings["CONTROLPTConnectionString"];
            SqlConnection con = new SqlConnection(connStringLM.ToString());
            con.Open();
            SqlCommand cmd_proc = new SqlCommand(inicio + cons_planta + cons_linea + cons_turno + cons_proceso + cons_lote + fin, con);
            SqlDataAdapter sda_proc = new SqlDataAdapter(cmd_proc);
            DataSet ds_proc = new DataSet();
            try
            {
                sda_proc.Fill(ds_proc);

                ddl_variedad_d.DataSourceID = "";
                ddl_variedad_d.DataSource = ds_proc;
                ddl_variedad_d.DataBind();
                ddl_variedad_d.Items.Add("Todas");
                ddl_variedad_d.SelectedIndex = -1;
                ddl_variedad_d.Items.FindByText("Todas").Selected = true;

            }
            catch
            {
                ddl_variedad_d.DataSourceID = "";
                ddl_variedad_d.DataSource = "";
                ddl_variedad_d.DataBind();
            }

            string variedad = ddl_variedad_d.SelectedValue;
            DropProductor(planta, linea, turno, proceso, lote, variedad);

            con.Close();
        }
        protected void variedad_SelectedIndexChanged(object sender, EventArgs e)
        {
            string planta = ddl_planta_d.SelectedValue;
            string linea = ddl_linea_d.SelectedValue;
            string turno = ddl_turno_d.SelectedValue;
            string proceso = ddl_proceso_d.SelectedValue;
            string lote = ddl_lote_d.SelectedValue;
            string variedad = ddl_variedad_d.SelectedValue;
            DropProductor(planta, linea, turno, proceso, lote, variedad);
        }

        private void DropProductor(string planta, string linea, string turno, string proceso, string lote, string variedad)
        {
            string inicio = "select distinct productor from CC_PAC_075_V2 where fecha>'1990-01-01' ";
            string fin = " order by productor";

            string cons_planta = "";
            if (planta != "Todas")
            {
                cons_planta = " and planta='" + planta + "' ";
            }

            string cons_linea = "";
            if (linea != "Todas")
            {
                cons_linea = " and linea='" + linea + "' ";
            }

            string cons_turno = "";
            if (turno != "Todos")
            {
                cons_turno = " and turno='" + turno + "' ";
            }

            string cons_proceso = "";
            if (proceso != "Todos")
            {
                cons_proceso = " and codproc='" + proceso + "' ";
            }

            string cons_lote = "";
            if (lote != "Todos")
            {
                cons_lote = " and lote='" + lote + "' ";
            }
            string cons_variedad = "";
            if (variedad != "Todas")
            {
                cons_variedad = " and variedad='" + variedad + "' ";
            }

            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisqc");
            System.Configuration.ConnectionStringSettings connStringLM;
            connStringLM = rootWebConfig.ConnectionStrings.ConnectionStrings["CONTROLPTConnectionString"];
            SqlConnection con = new SqlConnection(connStringLM.ToString());
            con.Open();
            SqlCommand cmd_proc = new SqlCommand(inicio + cons_planta + cons_linea + cons_turno + cons_proceso + cons_lote + cons_variedad + fin, con);
            SqlDataAdapter sda_proc = new SqlDataAdapter(cmd_proc);
            DataSet ds_proc = new DataSet();
            try
            {
                sda_proc.Fill(ds_proc);

                ddl_productor_d.DataSourceID = "";
                ddl_productor_d.DataSource = ds_proc;
                ddl_productor_d.DataBind();
                ddl_productor_d.Items.Add("Todos");
                ddl_productor_d.SelectedIndex = -1;
                ddl_productor_d.Items.FindByText("Todos").Selected = true;

            }
            catch
            {
                ddl_productor_d.DataSourceID = "";
                ddl_productor_d.DataSource = "";
                ddl_productor_d.DataBind();
            }

     
           con.Close();
        }
        protected void productor_SelectedIndexChanged(object sender, EventArgs e)
        {

          
        }


        protected void Click_005(object sender, ImageClickEventArgs e)
        {
            string planta = ddl_planta_d.SelectedValue;
            string linea = ddl_linea_d.SelectedValue;
            string turno = ddl_turno_d.SelectedValue;
            string proceso = ddl_proceso_d.SelectedValue;
            string lote = ddl_lote_d.SelectedValue;
            string variedad = ddl_variedad_d.SelectedValue;
            string productor = ddl_productor_d.SelectedValue;

            string where_cons = " where (fecha>='" + txt_fechainicio.Text + "' and fecha<='" + txt_fechafin.Text + "') ";
            string group_cons = "group by Comd";

            string whe_planta = "";
            string sel_planta = "";
            string gro_planta = "";
            if (planta != "Todas")
            {
                sel_planta = "select pl.pladescri as PLANTA,";
                whe_planta = " and cc.planta='" + planta + "' ";
                gro_planta = ", pl.pladescri";
            }
            if (planta == "Todas")
            {
                sel_planta = "select 'Todas las plantas' as PLANTA,";
                whe_planta = "";
                gro_planta = "";
            }


            string whe_linea = "";
            string sel_linea = "";
            string gro_linea = "";
            if (linea != "Todas")
            {
                sel_linea = " cc.linea AS LINEA, ";
                whe_linea = " and cc.linea='" + linea + "' ";
                gro_linea = ", cc.linea";
            }
            if (linea == "Todas")
            {
                sel_linea = " 'Todas las lineas' AS LINEA, ";
                whe_linea = "";
                gro_linea = "";
            }


            string whe_turno = "";
            string sel_turno = "";
            string gro_turno = "";
            if (turno != "Todos")
            {
                sel_turno = " cc.turno AS TURNO, ";
                whe_turno = " and cc.turno='" + turno + "' ";
                gro_turno = ", cc.turno";
            }
            if (turno == "Todos")
            {
                sel_turno = " 'Todos los turnos' AS TURNO, ";
                whe_turno = "";
                gro_turno = "";
            }


            string whe_proceso = "";
            string sel_proceso = "";
            string gro_proceso = "";
            if (proceso != "Todos")
            {
                sel_proceso = " cc.codproc AS PROCESO, ";
                whe_proceso = " and cc.codproc='" + proceso + "' ";
                gro_proceso = ", cc.codproc";
            }
            if (proceso == "Todos")
            {
                sel_proceso = " 'Todos los procesos' AS PROCESO, ";
                whe_proceso = "";
                gro_proceso = "";
            }


            string whe_lote = "";
            string sel_lote = "";
            string gro_lote = "";
            if (lote != "Todos")
            {
                sel_lote = " cc.lote AS LOTE, ";
                whe_lote = " and cc.lote='" + proceso + "' ";
                gro_lote = ", cc.lote";
            }
            if (lote == "Todos")
            {
                sel_lote = " 'Todos los lotes' AS LOTE, ";
                whe_lote = "";
                gro_lote = "";
            }


            string whe_variedad = "";
            string sel_variedad = "";
            string gro_variedad = "";
            if (variedad != "Todas")
            {
                sel_variedad = " cc.variedad AS VARIEDAD, ";
                whe_variedad = " and cc.variedad='" + variedad + "' ";
                gro_variedad = ", cc.variedad ";
            }
            if (variedad == "Todas")
            {
                sel_variedad = " 'Todas las variedades' AS VARIEDAD, ";
                whe_variedad = "";
                gro_variedad = "";
            }



            string whe_productor = "";
            string sel_productor = "";
            string gro_productor = "";
            if (productor != "Todos")
            {
                sel_productor = " cc.productor AS PRODUCTOR, ";
                whe_productor = " and cc.productor ='" + productor + "' ";
                gro_productor = ", cc.productor";
            }
            if (productor == "Todos")
            {
                sel_productor = " 'Todos los productores' AS PRODUCTOR, ";
                whe_productor = "";
                gro_productor = "";
            }


     

            string consultatotal =sel_planta + sel_turno+ sel_linea+sel_proceso+sel_lote+sel_productor+sel_variedad+ 
                " (avg(txt_exp_est))/100 as [% Exportable Estimado], (avg(txt_exp_desc))/100 as [% Exportable Descartador], "+
                " (avg(txt_desc_2))/100 as [% Descarte CAT 2], (avg(txt_desc_3))/100 as [% Descarte CAT 3], (avg(txt_1desecho))/100 as [CAT 1 %(Desecho)], (avg(txt_2_exp))/100 as [CAT 2 %(Exportable)], "+
                " (avg(txt_3_exp))/100 as [CAT 3 %(Exportable)], (avg(txt_desc_mesa))/100 as [% Exportable Descarte Mesa de Selección], (avg(txt_desc_manual))/100 as [% Exportable Descarte Manual Linea] "+
                " , count(1) as CajasMedidas "+

                " from cc_pac_075_v2 as cc inner join planta as pl on cc.planta=pl.placodigo"+

               ""+where_cons+whe_planta+whe_linea+whe_turno+whe_proceso+whe_lote+whe_variedad+whe_productor+
               " "+ group_cons + gro_planta + gro_linea + gro_turno + gro_proceso + gro_lote + gro_variedad +gro_productor ;

            
            Session["consultapt01"] = consultatotal;
            Response.Redirect("~/Reporte/ResumenDescarteComercial.aspx");

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }




    }
}