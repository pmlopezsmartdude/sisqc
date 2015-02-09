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
    public partial class GraficoProductoTerminado : System.Web.UI.Page
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
            SqlCommand cmd_proc = new SqlCommand("select distinct cl.placodigo as plantaid, pl.pladescri as planta from controlpt as cl inner join planta as pl on cl.placodigo=pl.placodigo order by plantaid asc", con);
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
            string inicio = "select distinct lincodigo as linea from controlpt where cptfechor>'2000-01-01' ";
            string fin = " order by lincodigo";

            string cons_planta = "";
            if (planta != "Todas")
            {
                cons_planta = " and placodigo='" + planta + "' ";
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
            string inicio = "select distinct turcodigo as turno from controlpt where cptfechor>'2000-01-01' ";
            string fin = " order by turcodigo";

            string cons_planta = "";
            if (planta != "Todas")
            {
                cons_planta = " and placodigo='" + planta + "' ";
            }

            string cons_linea = "";
            if (linea != "Todas")
            {
                cons_linea = " and lincodigo='" + linea + "' ";
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
            string inicio = "select distinct cptproces as proceso from controlpt where cptfechor>'2000-01-01' ";
            string fin = " order by cptproces";
           
            string cons_planta = "";
            if (planta != "Todas")
            {
                cons_planta = " and placodigo='" + planta + "' ";
            }

            string cons_linea = "";
            if (linea != "Todas")
            {
                cons_linea = " and lincodigo='" + linea + "' ";
            }

            string cons_turno = "";
            if (turno != "Todos")
            {
                cons_turno = " and turcodigo='" + turno + "' ";
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
            string inicio = "select distinct cptnulote as lote from controlpt where cptfechor>'2000-01-01' ";
            string fin = " order by cptnulote";
            
            string cons_planta = "";
            if (planta != "Todas")
            {
                cons_planta = " and placodigo='" + planta + "' ";
            }

            string cons_linea = "";
            if (linea != "Todas")
            {
                cons_linea = " and lincodigo='" + linea + "' ";
            }

            string cons_turno = "";
            if (turno != "Todos")
            {
                cons_turno = " and turcodigo='" + turno + "' ";
            }

            string cons_proceso = "";
            if (proceso != "Todos")
            {
                cons_proceso = " and cptproces='" + proceso + "' ";
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
            string inicio = "select distinct cptvarcod as variedad_id, cptvardes as variedad from controlpt where cptfechor>'2000-01-01' ";
            string fin = " order by variedad";

            string cons_planta = "";
            if (planta != "Todas")
            {
                cons_planta = " and placodigo='" + planta + "' ";
            }

            string cons_linea = "";
            if (linea != "Todas")
            {
                cons_linea = " and lincodigo='" + linea + "' ";
            }

            string cons_turno = "";
            if (turno != "Todos")
            {
                cons_turno = " and turcodigo='" + turno + "' ";
            }

            string cons_proceso = "";
            if (proceso != "Todos")
            {
                cons_proceso = " and cptproces='" + proceso + "' ";
            }

            string cons_lote = "";
            if (lote != "Todos")
            {
                cons_lote = " and cptnulote='" + lote + "' ";
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
            string inicio = "select distinct cptrutprr as productor_id, cptnompre as productor from controlpt where cptfechor>'2000-01-01' ";
            string fin = " order by cptnompre";

            string cons_planta = "";
            if (planta != "Todas")
            {
                cons_planta = " and placodigo='" + planta + "' ";
            }

            string cons_linea = "";
            if (linea != "Todas")
            {
                cons_linea = " and lincodigo='" + linea + "' ";
            }

            string cons_turno = "";
            if (turno != "Todos")
            {
                cons_turno = " and turcodigo='" + turno + "' ";
            }

            string cons_proceso = "";
            if (proceso != "Todos")
            {
                cons_proceso = " and cptproces='" + proceso + "' ";
            }

            string cons_lote = "";
            if (lote != "Todos")
            {
                cons_lote = " and cptnulote='" + lote + "' ";
            }
            string cons_variedad = "";
            if (variedad != "Todas")
            {
                cons_variedad = " and cptvarcod='" + variedad + "' ";
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

     
            string productor = ddl_productor_d.SelectedValue;
            DropAcept(planta, linea, turno, proceso, lote, variedad, productor);

            con.Close();
        }
        protected void productor_SelectedIndexChanged(object sender, EventArgs e)
        {
            string planta = ddl_planta_d.SelectedValue;
            string linea = ddl_linea_d.SelectedValue;
            string turno = ddl_turno_d.SelectedValue;
            string proceso = ddl_proceso_d.SelectedValue;
            string lote = ddl_lote_d.SelectedValue;
            string variedad = ddl_variedad_d.SelectedValue;
            string productor = ddl_productor_d.SelectedValue;
            DropAcept(planta, linea, turno, proceso, lote, variedad, productor);
        }

        private void DropAcept(string planta, string linea, string turno, string proceso, string lote, string variedad, string productor)
        {
            string inicio = "select distinct AceptRecha as tipo from controlpt where cptfechor>'2000-01-01' ";
            string fin = " order by AceptRecha desc";

            string cons_planta = "";
            if (planta != "Todas")
            {
                cons_planta = " and placodigo='" + planta + "' ";
            }

            string cons_linea = "";
            if (linea != "Todas")
            {
                cons_linea = " and lincodigo='" + linea + "' ";
            }

            string cons_turno = "";
            if (turno != "Todos")
            {
                cons_turno = " and turcodigo='" + turno + "' ";
            }

            string cons_proceso = "";
            if (proceso != "Todos")
            {
                cons_proceso = " and cptproces='" + proceso + "' ";
            }

            string cons_lote = "";
            if (lote != "Todos")
            {
                cons_lote = " and cptnulote='" + lote + "' ";
            }
            string cons_variedad = "";
            if (variedad != "Todas")
            {
                cons_variedad = " and cptvarcod='" + variedad + "' ";
            }
            string cons_productor = "";
            if (productor != "Todos")
            {
                cons_productor = " and cptrutprr='" + productor + "' ";
            }

            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisqc");
            System.Configuration.ConnectionStringSettings connStringLM;
            connStringLM = rootWebConfig.ConnectionStrings.ConnectionStrings["CONTROLPTConnectionString"];
            SqlConnection con = new SqlConnection(connStringLM.ToString());
            con.Open();
            SqlCommand cmd_proc = new SqlCommand(inicio + cons_planta + cons_linea + cons_turno + cons_proceso + cons_lote + cons_variedad + cons_productor + fin, con);
            SqlDataAdapter sda_proc = new SqlDataAdapter(cmd_proc);
            DataSet ds_proc = new DataSet();
            try
            {
                sda_proc.Fill(ds_proc);

                ddl_acep_d.DataSourceID = "";
                ddl_acep_d.DataSource = ds_proc;
                ddl_acep_d.DataBind();
                ddl_acep_d.Items.Add("Todos");
                ddl_acep_d.SelectedIndex = -1;
                ddl_acep_d.Items.FindByText("Todos").Selected = true;

            }
            catch
            {
                ddl_acep_d.DataSourceID = "";
                ddl_acep_d.DataSource = "";
                ddl_acep_d.DataBind();
            }



            con.Close();
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
            string acept = ddl_acep_d.SelectedValue;

            string where_cons = "where (cptfechor>='" + txt_fechainicio.Text + "' and cptfechor<='" + txt_fechafin.Text + "') ";
            string group_cons = "group by  solsolub";

            string whe_planta = "";
            string sel_planta = "";
            string gro_planta = "";
            if (planta != "Todas")
            {
                sel_planta = "select pl.pladescri as PLANTA,";
                whe_planta = " and cl.placodigo='" + planta + "' ";
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
                sel_linea = " CL.LINCODIGO AS LINEA, ";
                whe_linea = " and cl.lincodigo='" + linea + "' ";
                gro_linea = ", cl.lincodigo";
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
                sel_turno = " CL.turcodigo AS TURNO, ";
                whe_turno = " and cl.turcodigo='" + turno + "' ";
                gro_turno = ", cl.turcodigo";
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
                sel_proceso = " CL.cptproces AS PROCESO, ";
                whe_proceso = " and cl.cptproces='" + proceso + "' ";
                gro_proceso = ", cl.cptproces";
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
                sel_lote = " CL.cptnulote AS LOTE, ";
                whe_lote = " and cl.cptnulote='" + proceso + "' ";
                gro_lote = ", cl.cptnulote";
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
                sel_variedad = " CL.cptvarcod AS VARIEDAD_ID, CL.cptvardes AS VARIEDAD_NOMBRE, ";
                whe_variedad = " and cl.cptvarcod='" + variedad + "' ";
                gro_variedad = ", cl.cptvarcod,cl.cptvardes";
            }
            if (variedad == "Todas")
            {
                sel_variedad = " ' ' AS VARIEDAD_ID, 'Todas las variedades' AS VARIEDAD_NOMBRE, ";
                whe_variedad = "";
                gro_variedad = "";
            }



            string whe_productor = "";
            string sel_productor = "";
            string gro_productor = "";
            if (productor != "Todos")
            {
                sel_productor = " CL.CPTRUTPRR AS PRODUCREAL_ID, CL.CPTNOMPRE AS PRODUCTOREAL_NOMBRE, ";
                whe_productor = " and cl.CPTRUTPRR='" + productor + "' ";
                gro_productor = ", cl.CPTNOMPRE,cl.CPTRUTPRR";
            }
            if (productor == "Todos")
            {
                sel_productor = " ' ' AS PRODUCREAL_ID, 'Todos los productores' AS PRODUCTOREAL_NOMBRE, ";
                whe_productor = "";
                gro_productor = "";
            }


            string whe_acept = "";
            string sel_acept = "";
            string gro_acept = "";
            if (acept != "Todos")
            {
                sel_acept = " CL.ACEPTRECHA AS ACEPTRECHA, ";
                whe_acept = " and cl.ACEPTRECHA='" + acept + "' ";
                gro_acept = ", cl.ACEPTRECHA";
            }
            if (acept == "Todos")
            {
                sel_acept = " 'Aceptadas y Rechazadas' AS ACEPTRECHA, ";
                whe_acept = "";
                gro_acept = "";
            }

            string consultatotal = sel_planta + sel_turno + " 'fecha' AS FECHA, " + sel_linea + sel_proceso + sel_lote + sel_productor + "" +
                " '1' AS PRODUCTORETIQUETADO_ID, '1' AS PRODUCTORETIQUETADO_NOMBRE, " + sel_variedad + " '1' AS MARCA_ID, '1' AS MARCA_NOMBRE, " +
                " " + sel_acept + "convert(int,COUNT(1)) AS CANT_CAJAS, " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defprecal=0 then 0 else 1 end)>0,((sum(cl.defprecal))/(sum(case when cl.defprecal=0 then 0 else 1 end))),0))) as [PRE CALIBRE], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defdanotr=0 then 0 else 1 end)>0,((sum(cl.defdanotr))/(sum(case when cl.defdanotr=0 then 0 else 1 end))),0))) as [DAÑO TRIPS], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defescama=0 then 0 else 1 end)>0,((sum(cl.defescama))/(sum(case when cl.defescama=0 then 0 else 1 end))),0))) as [ESCAMA], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.deffrutode=0 then 0 else 1 end)>0,((sum(cl.deffrutode))/(sum(case when cl.deffrutode=0 then 0 else 1 end))),0))) as [FRUTOS DEFORMES], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.deffrutodo=0 then 0 else 1 end)>0,((sum(cl.deffrutodo))/(sum(case when cl.deffrutodo=0 then 0 else 1 end))),0))) as [FRUTOS DOBLES], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defguatab=0 then 0 else 1 end)>0,((sum(cl.defguatab))/(sum(case when cl.defguatab=0 then 0 else 1 end))),0))) as [GUATA BLANCA], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defherida=0 then 0 else 1 end)>0,((sum(cl.defherida))/(sum(case when cl.defherida=0 then 0 else 1 end))),0))) as [HERIDAS], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defmancha=0 then 0 else 1 end)>0,((sum(cl.defmancha))/(sum(case when cl.defmancha=0 then 0 else 1 end))),0))) as [MANCHAS], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defmedial=0 then 0 else 1 end)>0,((sum(cl.defmedial))/(sum(case when cl.defmedial=0 then 0 else 1 end))),0))) as [MEDIA LUNA], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defpiella=0 then 0 else 1 end)>0,((sum(cl.defpiella))/(sum(case when cl.defpiella=0 then 0 else 1 end))),0))) as [PIEL DE LAGARTO], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defrusset=0 then 0 else 1 end)>0,((sum(cl.defrusset))/(sum(case when cl.defrusset=0 then 0 else 1 end))),0))) as [RUSSET], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defsutura=0 then 0 else 1 end)>0,((sum(cl.defsutura))/(sum(case when cl.defsutura=0 then 0 else 1 end))),0))) as [SUTURAS], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.deffaltoc=0 then 0 else 1 end)>0,((sum(cl.deffaltoc))/(sum(case when cl.deffaltoc=0 then 0 else 1 end))),0))) as [FALTO COLOR], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.deframole=0 then 0 else 1 end)>0,((sum(cl.deframole))/(sum(case when cl.deframole=0 then 0 else 1 end))),0))) as [RAMOLEO], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defsinped=0 then 0 else 1 end)>0,((sum(cl.defsinped))/(sum(case when cl.defsinped=0 then 0 else 1 end))),0))) as [SIN PEDICELO]," +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defadhesi=0 then 0 else 1 end)>0,((sum(cl.defadhesi))/(sum(case when cl.defadhesi=0 then 0 else 1 end))),0))) as [ADHESION], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defdesfru=0 then 0 else 1 end)>0,((sum(cl.defdesfru))/(sum(case when cl.defdesfru=0 then 0 else 1 end))),0))) as [DESHID FRUTOS], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defdesped=0 then 0 else 1 end)>0,((sum(cl.defdesped))/(sum(case when cl.defdesped=0 then 0 else 1 end))),0))) as [DESHID PEDICELAR], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defblando=0 then 0 else 1 end)>0,((sum(cl.defblando))/(sum(case when cl.defblando=0 then 0 else 1 end))),0))) as [BLANDOS], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defherabi=0 then 0 else 1 end)>0,((sum(cl.defherabi))/(sum(case when cl.defherabi=0 then 0 else 1 end))),0))) as [HERIDA ABIERTA], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defmachuc=0 then 0 else 1 end)>0,((sum(cl.defmachuc))/(sum(case when cl.defmachuc=0 then 0 else 1 end))),0))) as [MACHUCON], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defpartid=0 then 0 else 1 end)>0,((sum(cl.defpartid))/(sum(case when cl.defpartid=0 then 0 else 1 end))),0))) as [PARTIDURAS], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defparagu=0 then 0 else 1 end)>0,((sum(cl.defparagu))/(sum(case when cl.defparagu=0 then 0 else 1 end))),0))) as [PARTIDURAS POR AGUA], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defparcic=0 then 0 else 1 end)>0,((sum(cl.defparcic))/(sum(case when cl.defparcic=0 then 0 else 1 end))),0))) as [PARTIDURAS CICATRIZADAS], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defpittin=0 then 0 else 1 end)>0,((sum(cl.defpittin))/(sum(case when cl.defpittin=0 then 0 else 1 end))),0))) as [PITTING], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defpudric=0 then 0 else 1 end)>0,((sum(cl.defpudric))/(sum(case when cl.defpudric=0 then 0 else 1 end))),0))) as [PUDRICION], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defmanpar=0 then 0 else 1 end)>0,((sum(cl.defmanpar))/(sum(case when cl.defmanpar=0 then 0 else 1 end))),0))) as [MANCHAS PARDAS], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defdanopa=0 then 0 else 1 end)>0,((sum(cl.defdanopa))/(sum(case when cl.defdanopa=0 then 0 else 1 end))),0))) as [DAÑO PAJARO], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defdesgar=0 then 0 else 1 end)>0,((sum(cl.defdesgar))/(sum(case when cl.defdesgar=0 then 0 else 1 end))),0))) as [DESGARROS], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defcorsie=0 then 0 else 1 end)>0,((sum(cl.defcorsie))/(sum(case when cl.defcorsie=0 then 0 else 1 end))),0))) as [CORTES SIERRA], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defsutura_exp=0 then 0 else 1 end)>0,((sum(cl.defsutura_exp))/(sum(case when cl.defsutura_exp=0 then 0 else 1 end))),0))) as [SUTURA EXPUESTA]" +
           " from controlpt as cl INNER JOIN planta AS  PL ON CL.placodigo=PL.placodigo " + where_cons + whe_planta + whe_linea + whe_turno + whe_proceso + whe_lote + whe_variedad + whe_productor + whe_acept +
           " " + group_cons + gro_planta + gro_linea + gro_turno + gro_proceso + gro_lote + gro_variedad + gro_productor + gro_acept;

            Session["consultapt01"] = consultatotal;
            Response.Redirect("~/Reporte/ResumenProductoTerminado.aspx");

        }

        protected void Click_005_v2(object sender, ImageClickEventArgs e)
        {
            string planta = ddl_planta_d.SelectedValue;
            string linea = ddl_linea_d.SelectedValue;
            string turno = ddl_turno_d.SelectedValue;
            string proceso = ddl_proceso_d.SelectedValue;
            string lote = ddl_lote_d.SelectedValue;
            string variedad = ddl_variedad_d.SelectedValue;
            string productor = ddl_productor_d.SelectedValue;
            string acept = ddl_acep_d.SelectedValue;

            string where_cons = "where (cptfechor>='" + txt_fechainicio.Text + "' and cptfechor<='" + txt_fechafin.Text + "') ";
            string group_cons = "group by  cptcalibr";

            string whe_planta = "";
            string sel_planta = "";
            string gro_planta = "";
            if (planta != "Todas")
            {
                sel_planta = "select pl.pladescri as PLANTA,";
                whe_planta = " and cl.placodigo='" + planta + "' ";
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
                sel_linea = " CL.LINCODIGO AS LINEA, ";
                whe_linea = " and cl.lincodigo='" + linea + "' ";
                gro_linea = ", cl.lincodigo";
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
                sel_turno = " CL.turcodigo AS TURNO, ";
                whe_turno = " and cl.turcodigo='" + turno + "' ";
                gro_turno = ", cl.turcodigo";
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
                sel_proceso = " CL.cptproces AS PROCESO, ";
                whe_proceso = " and cl.cptproces='" + proceso + "' ";
                gro_proceso = ", cl.cptproces";
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
                sel_lote = " CL.cptnulote AS LOTE, ";
                whe_lote = " and cl.cptnulote='" + proceso + "' ";
                gro_lote = ", cl.cptnulote";
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
                sel_variedad = " CL.cptvarcod AS VARIEDAD_ID, CL.cptvardes AS VARIEDAD_NOMBRE, ";
                whe_variedad = " and cl.cptvarcod='" + variedad + "' ";
                gro_variedad = ", cl.cptvarcod, CL.cptvardes";
            }
            if (variedad == "Todas")
            {
                sel_variedad = " ' ' AS VARIEDAD_ID, 'Todas las variedades' AS VARIEDAD_NOMBRE, ";
                whe_variedad = "";
                gro_variedad = "";
            }



            string whe_productor = "";
            string sel_productor = "";
            string gro_productor = "";
            if (productor != "Todos")
            {
                sel_productor = " CL.CPTRUTPRR AS PRODUCREAL_ID, CL.CPTNOMPRE AS PRODUCTOREAL_NOMBRE, ";
                whe_productor = " and cl.CPTRUTPRR='" + productor + "' ";
                gro_productor = ", cl.CPTRUTPRR, CL.CPTNOMPRE";
            }
            if (productor == "Todos")
            {
                sel_productor = " ' ' AS PRODUCREAL_ID, 'Todos los productores' AS PRODUCTOREAL_NOMBRE, ";
                whe_productor = "";
                gro_productor = "";
            }


            string whe_acept = "";
            string sel_acept = "";
            string gro_acept = "";
            if (acept != "Todos")
            {
                sel_acept = " CL.ACEPTRECHA AS ACEPTRECHA, ";
                whe_acept = " and cl.ACEPTRECHA='" + acept + "' ";
                gro_acept = ", cl.ACEPTRECHA";
            }
            if (acept == "Todos")
            {
                sel_acept = " 'Aceptadas y Rechazadas' AS ACEPTRECHA, ";
                whe_acept = "";
                gro_acept = "";
            }

            string consultatotal = sel_planta + sel_turno + " 'fecha' AS FECHA, " + sel_linea + sel_proceso + sel_lote + sel_productor + "" +
                " '1' AS PRODUCTORETIQUETADO_ID, '1' AS PRODUCTORETIQUETADO_NOMBRE, " + sel_variedad + " '1' AS MARCA_ID, '1' AS MARCA_NOMBRE, " +
                " " + sel_acept + "" +
                " cptcalibr AS CPTCALIBRE , " +
" CONVERT(decimal(18,2),(iif(sum(case when ((f1+f2+f3+f4+f5)/5 )=0 then 0 else 1 end)>0,((sum(((f1+f2+f3+f4+f5)/5 )))/(sum(case when ((f1+f2+f3+f4+f5)/5 )=0 then 0 else 1 end))),0))) as PROMEDIO," +
" count(1) as CASOS" +
            " from controlpt as cl INNER JOIN planta AS  PL ON CL.placodigo=PL.placodigo " + where_cons + whe_planta + whe_linea + whe_turno + whe_proceso + whe_lote + whe_variedad + whe_productor + whe_acept +
               " " + group_cons + gro_planta + gro_linea + gro_turno + gro_proceso + gro_lote + gro_variedad + gro_productor + gro_acept;




            Session["consultapt2"] = consultatotal;
            Response.Redirect("~/Reporte/ResumenProductoTerminadoSS.aspx");

        }

        protected void Click_005_prueba(object sender, ImageClickEventArgs e)
        {
            string planta = ddl_planta_d.SelectedValue;
            string linea = ddl_linea_d.SelectedValue;
            string turno = ddl_turno_d.SelectedValue;
            string proceso = ddl_proceso_d.SelectedValue;
            string lote = ddl_lote_d.SelectedValue;
            string variedad = ddl_variedad_d.SelectedValue;
            string productor = ddl_productor_d.SelectedValue;
            string acept = ddl_acep_d.SelectedValue;

            string where_cons = "where (cptfechor>='" + txt_fechainicio.Text + "' and cptfechor<='" + txt_fechafin.Text + "') ";
            string group_cons = "group by  solsolub";
            string group_cons2 = "group by  cptcalibr";

            string whe_planta = "";
            string sel_planta = "";
            string gro_planta = "";
            if (planta != "Todas")
            {
                sel_planta = "select pl.pladescri as PLANTA,";
                whe_planta = " and cl.placodigo='" + planta + "' ";
                gro_planta = ", pl.pladescri";
            }
            if (planta == "Todas")
            {
                sel_planta = "select 'Todas las plantas' as PLANTA,";
                whe_planta = "";
                gro_planta = "";
            }

            string whe_planta2 = "";
            string sel_planta2 = "";
            string gro_planta2 = "";
            if (planta != "Todas")
            {
                sel_planta2 = "select pl.pladescri as PLANTA_2,";
                whe_planta2 = " and cl.placodigo='" + planta + "' ";
                gro_planta2 = ", pl.pladescri";
            }
            if (planta == "Todas")
            {
                sel_planta2 = "select 'Todas las plantas' as PLANTA_2,";
                whe_planta2 = "";
                gro_planta2 = "";
            }







            string whe_linea = "";
            string sel_linea = "";
            string gro_linea = "";
            if (linea != "Todas")
            {
                sel_linea = " CL.LINCODIGO AS LINEA, ";
                whe_linea = " and cl.lincodigo='" + linea + "' ";
                gro_linea = ", cl.lincodigo";
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
                sel_turno = " CL.turcodigo AS TURNO, ";
                whe_turno = " and cl.turcodigo='" + turno + "' ";
                gro_turno = ", cl.turcodigo";
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
                sel_proceso = " CL.cptproces AS PROCESO, ";
                whe_proceso = " and cl.cptproces='" + proceso + "' ";
                gro_proceso = ", cl.cptproces";
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
                sel_lote = " CL.cptnulote AS LOTE, ";
                whe_lote = " and cl.cptnulote='" + proceso + "' ";
                gro_lote = ", cl.cptnulote";
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
                sel_variedad = " CL.cptvarcod AS VARIEDAD_ID, CL.cptvardes AS VARIEDAD_NOMBRE, ";
                whe_variedad = " and cl.cptvarcod='" + variedad + "' ";
                gro_variedad = ", cl.cptvarcod,cl.cptvardes";
            }
            if (variedad == "Todas")
            {
                sel_variedad = " ' ' AS VARIEDAD_ID, 'Todas las variedades' AS VARIEDAD_NOMBRE, ";
                whe_variedad = "";
                gro_variedad = "";
            }



            string whe_productor = "";
            string sel_productor = "";
            string gro_productor = "";
            if (productor != "Todos")
            {
                sel_productor = " CL.CPTRUTPRR AS PRODUCREAL_ID, CL.CPTNOMPRE AS PRODUCTOREAL_NOMBRE, ";
                whe_productor = " and cl.CPTRUTPRR='" + productor + "' ";
                gro_productor = ", cl.CPTNOMPRE,cl.CPTRUTPRR";
            }
            if (productor == "Todos")
            {
                sel_productor = " ' ' AS PRODUCREAL_ID, 'Todos los productores' AS PRODUCTOREAL_NOMBRE, ";
                whe_productor = "";
                gro_productor = "";
            }


            string whe_acept = "";
            string sel_acept = "";
            string gro_acept = "";
            if (acept != "Todos")
            {
                sel_acept = " CL.ACEPTRECHA AS ACEPTRECHA, ";
                whe_acept = " and cl.ACEPTRECHA='" + acept + "' ";
                gro_acept = ", cl.ACEPTRECHA";
            }
            if (acept == "Todos")
            {
                sel_acept = " 'Aceptadas y Rechazadas' AS ACEPTRECHA, ";
                whe_acept = "";
                gro_acept = "";
            }

            string consultatotal = sel_planta + sel_turno + " 'fecha' AS FECHA, " + sel_linea + sel_proceso + sel_lote + sel_productor + "" +
                " '1' AS PRODUCTORETIQUETADO_ID, '1' AS PRODUCTORETIQUETADO_NOMBRE, " + sel_variedad + " '1' AS MARCA_ID, '1' AS MARCA_NOMBRE, " +
                " " + sel_acept + "convert(int,COUNT(1)) AS CANT_CAJAS, " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defprecal=0 then 0 else 1 end)>0,((sum(cl.defprecal))*1.00/(sum(case when cl.defprecal=0 then 0 else 1 end))),0))) as [PRE CALIBRE], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defdanotr=0 then 0 else 1 end)>0,((sum(cl.defdanotr))*1.00/(sum(case when cl.defdanotr=0 then 0 else 1 end))),0))) as [DAÑO TRIPS], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defescama=0 then 0 else 1 end)>0,((sum(cl.defescama))*1.00/(sum(case when cl.defescama=0 then 0 else 1 end))),0))) as [ESCAMA], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.deffrutode=0 then 0 else 1 end)>0,((sum(cl.deffrutode))*1.00/(sum(case when cl.deffrutode=0 then 0 else 1 end))),0))) as [FRUTOS DEFORMES], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.deffrutodo=0 then 0 else 1 end)>0,((sum(cl.deffrutodo))*1.00/(sum(case when cl.deffrutodo=0 then 0 else 1 end))),0))) as [FRUTOS DOBLES], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defguatab=0 then 0 else 1 end)>0,((sum(cl.defguatab))*1.00/(sum(case when cl.defguatab=0 then 0 else 1 end))),0))) as [GUATA BLANCA], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defherida=0 then 0 else 1 end)>0,((sum(cl.defherida))*1.00/(sum(case when cl.defherida=0 then 0 else 1 end))),0))) as [HERIDAS], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defmancha=0 then 0 else 1 end)>0,((sum(cl.defmancha))*1.00/(sum(case when cl.defmancha=0 then 0 else 1 end))),0))) as [MANCHAS], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defmedial=0 then 0 else 1 end)>0,((sum(cl.defmedial))*1.00/(sum(case when cl.defmedial=0 then 0 else 1 end))),0))) as [MEDIA LUNA], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defpiella=0 then 0 else 1 end)>0,((sum(cl.defpiella))*1.00/(sum(case when cl.defpiella=0 then 0 else 1 end))),0))) as [PIEL DE LAGARTO], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defrusset=0 then 0 else 1 end)>0,((sum(cl.defrusset))*1.00/(sum(case when cl.defrusset=0 then 0 else 1 end))),0))) as [RUSSET], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defsutura=0 then 0 else 1 end)>0,((sum(cl.defsutura))*1.00/(sum(case when cl.defsutura=0 then 0 else 1 end))),0))) as [SUTURAS], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.deffaltoc=0 then 0 else 1 end)>0,((sum(cl.deffaltoc))*1.00/(sum(case when cl.deffaltoc=0 then 0 else 1 end))),0))) as [FALTO COLOR], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.deframole=0 then 0 else 1 end)>0,((sum(cl.deframole))*1.00/(sum(case when cl.deframole=0 then 0 else 1 end))),0))) as [RAMOLEO], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defsinped=0 then 0 else 1 end)>0,((sum(cl.defsinped))*1.00/(sum(case when cl.defsinped=0 then 0 else 1 end))),0))) as [SIN PEDICELO]," +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defadhesi=0 then 0 else 1 end)>0,((sum(cl.defadhesi))*1.00/(sum(case when cl.defadhesi=0 then 0 else 1 end))),0))) as [ADHESION], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defdesfru=0 then 0 else 1 end)>0,((sum(cl.defdesfru))*1.00/(sum(case when cl.defdesfru=0 then 0 else 1 end))),0))) as [DESHID FRUTOS], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defdesped=0 then 0 else 1 end)>0,((sum(cl.defdesped))*1.00/(sum(case when cl.defdesped=0 then 0 else 1 end))),0))) as [DESHID PEDICELAR], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defblando=0 then 0 else 1 end)>0,((sum(cl.defblando))*1.00/(sum(case when cl.defblando=0 then 0 else 1 end))),0))) as [BLANDOS], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defherabi=0 then 0 else 1 end)>0,((sum(cl.defherabi))*1.00/(sum(case when cl.defherabi=0 then 0 else 1 end))),0))) as [HERIDA ABIERTA], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defmachuc=0 then 0 else 1 end)>0,((sum(cl.defmachuc))*1.00/(sum(case when cl.defmachuc=0 then 0 else 1 end))),0))) as [MACHUCON], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defpartid=0 then 0 else 1 end)>0,((sum(cl.defpartid))*1.00/(sum(case when cl.defpartid=0 then 0 else 1 end))),0))) as [PARTIDURAS], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defparagu=0 then 0 else 1 end)>0,((sum(cl.defparagu))*1.00/(sum(case when cl.defparagu=0 then 0 else 1 end))),0))) as [PARTIDURAS POR AGUA], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defparcic=0 then 0 else 1 end)>0,((sum(cl.defparcic))*1.00/(sum(case when cl.defparcic=0 then 0 else 1 end))),0))) as [PARTIDURAS CICATRIZADAS], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defpittin=0 then 0 else 1 end)>0,((sum(cl.defpittin))*1.00/(sum(case when cl.defpittin=0 then 0 else 1 end))),0))) as [PITTING], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defpudric=0 then 0 else 1 end)>0,((sum(cl.defpudric))*1.00/(sum(case when cl.defpudric=0 then 0 else 1 end))),0))) as [PUDRICION], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defmanpar=0 then 0 else 1 end)>0,((sum(cl.defmanpar))*1.00/(sum(case when cl.defmanpar=0 then 0 else 1 end))),0))) as [MANCHAS PARDAS], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defdanopa=0 then 0 else 1 end)>0,((sum(cl.defdanopa))*1.00/(sum(case when cl.defdanopa=0 then 0 else 1 end))),0))) as [DAÑO PAJARO], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defdesgar=0 then 0 else 1 end)>0,((sum(cl.defdesgar))*1.00/(sum(case when cl.defdesgar=0 then 0 else 1 end))),0))) as [DESGARROS], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defcorsie=0 then 0 else 1 end)>0,((sum(cl.defcorsie))*1.00/(sum(case when cl.defcorsie=0 then 0 else 1 end))),0))) as [CORTES SIERRA], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defsutura_exp=0 then 0 else 1 end)>0,((sum(cl.defsutura_exp))*1.00/(sum(case when cl.defsutura_exp=0 then 0 else 1 end))),0))) as [SUTURA EXPUESTA]" +
           " from controlpt as cl INNER JOIN planta AS  PL ON CL.placodigo=PL.placodigo " + where_cons + whe_planta + whe_linea + whe_turno + whe_proceso + whe_lote + whe_variedad + whe_productor + whe_acept +
           " " + group_cons + gro_planta + gro_linea + gro_turno + gro_proceso + gro_lote + gro_variedad + gro_productor + gro_acept;


            string consultatotal_2 = sel_planta2 + " cptcalibr AS CPTCALIBRE , " +
" CONVERT(decimal(18,2),(iif(sum(case when ((f1+f2+f3+f4+f5)/5 )=0 then 0 else 1 end)>0,((sum(((f1+f2+f3+f4+f5)/5 )))/(sum(case when ((f1+f2+f3+f4+f5)/5 )=0 then 0 else 1 end))),0))) as PROMEDIO," +
" count(1) as CASOS" +
           " from controlpt as cl INNER JOIN planta AS  PL ON CL.placodigo=PL.placodigo " + where_cons + whe_planta2 + whe_linea + whe_turno + whe_proceso + whe_lote + whe_variedad + whe_productor + whe_acept +
              " " + group_cons2 + gro_planta2 + gro_linea + gro_turno + gro_proceso + gro_lote + gro_variedad + gro_productor + gro_acept;


            string final = "select * from (" + consultatotal + ") as cl left join (" + consultatotal_2 + ") as pl on cl.PLANTA=pl.PLANTA_2";

            Session["final"] = final;
            Response.Redirect("~/Reporte/ResumenProductoTerminado_juntos.aspx");

        }
      

        private void crea1consulta()
        {
            string planta = ddl_planta_d.SelectedValue;
            string linea = ddl_linea_d.SelectedValue;
            string turno = ddl_turno_d.SelectedValue;
            string proceso = ddl_proceso_d.SelectedValue;
            string lote = ddl_lote_d.SelectedValue;
            string variedad = ddl_variedad_d.SelectedValue;
            string productor = ddl_productor_d.SelectedValue;
            string acept = ddl_acep_d.SelectedValue;

            string where_cons = "where (cptfechor>='" + txt_fechainicio.Text + "' and cptfechor<='" + txt_fechafin.Text + "') ";
            string group_cons = "group by  solsolub";

            string whe_planta = "";
            string sel_planta = "";
            string gro_planta = "";
            if (planta != "Todas")
            {
                sel_planta = "select pl.pladescri as PLANTA,";
                whe_planta = " and cl.placodigo='" + planta + "' ";
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
                sel_linea = " CL.LINCODIGO AS LINEA, ";
                whe_linea = " and cl.lincodigo='" + linea + "' ";
                gro_linea = ", cl.lincodigo";
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
                sel_turno = " CL.turcodigo AS TURNO, ";
                whe_turno = " and cl.turcodigo='" + turno + "' ";
                gro_turno = ", cl.turcodigo";
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
                sel_proceso = " CL.cptproces AS PROCESO, ";
                whe_proceso = " and cl.cptproces='" + proceso + "' ";
                gro_proceso = ", cl.cptproces";
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
                sel_lote = " CL.cptnulote AS LOTE, ";
                whe_lote = " and cl.cptnulote='" + proceso + "' ";
                gro_lote = ", cl.cptnulote";
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
                sel_variedad = " CL.cptvarcod AS VARIEDAD_ID, CL.cptvardes AS VARIEDAD_NOMBRE, ";
                whe_variedad = " and cl.cptvarcod='" + variedad + "' ";
                gro_variedad = ", cl.cptvarcod,cl.cptvardes";
            }
            if (variedad == "Todas")
            {
                sel_variedad = " ' ' AS VARIEDAD_ID, 'Todas las variedades' AS VARIEDAD_NOMBRE, ";
                whe_variedad = "";
                gro_variedad = "";
            }



            string whe_productor = "";
            string sel_productor = "";
            string gro_productor = "";
            if (productor != "Todos")
            {
                sel_productor = " CL.CPTRUTPRR AS PRODUCREAL_ID, CL.CPTNOMPRE AS PRODUCTOREAL_NOMBRE, ";
                whe_productor = " and cl.CPTRUTPRR='" + productor + "' ";
                gro_productor = ", cl.CPTNOMPRE,cl.CPTRUTPRR";
            }
            if (productor == "Todos")
            {
                sel_productor = " ' ' AS PRODUCREAL_ID, 'Todos los productores' AS PRODUCTOREAL_NOMBRE, ";
                whe_productor = "";
                gro_productor = "";
            }


            string whe_acept = "";
            string sel_acept = "";
            string gro_acept = "";
            if (acept != "Todos")
            {
                sel_acept = " CL.ACEPTRECHA AS ACEPTRECHA, ";
                whe_acept = " and cl.ACEPTRECHA='" + acept + "' ";
                gro_acept = ", cl.ACEPTRECHA";
            }
            if (acept == "Todos")
            {
                sel_acept = " 'Aceptadas y Rechazadas' AS ACEPTRECHA, ";
                whe_acept = "";
                gro_acept = "";
            }

            string consultatotal = sel_planta + sel_turno + " 'fecha' AS FECHA, " + sel_linea + sel_proceso + sel_lote + sel_productor + "" +
                " '1' AS PRODUCTORETIQUETADO_ID, '1' AS PRODUCTORETIQUETADO_NOMBRE, " + sel_variedad + " '1' AS MARCA_ID, '1' AS MARCA_NOMBRE, " +
                " " + sel_acept + "convert(int,COUNT(1)) AS CANT_CAJAS, " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defprecal=0 then 0 else 1 end)>0,((sum(cl.defprecal))/(sum(case when cl.defprecal=0 then 0 else 1 end))),0))) as [PRE CALIBRE], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defdanotr=0 then 0 else 1 end)>0,((sum(cl.defdanotr))/(sum(case when cl.defdanotr=0 then 0 else 1 end))),0))) as [DAÑO TRIPS], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defescama=0 then 0 else 1 end)>0,((sum(cl.defescama))/(sum(case when cl.defescama=0 then 0 else 1 end))),0))) as [ESCAMA], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.deffrutode=0 then 0 else 1 end)>0,((sum(cl.deffrutode))/(sum(case when cl.deffrutode=0 then 0 else 1 end))),0))) as [FRUTOS DEFORMES], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.deffrutodo=0 then 0 else 1 end)>0,((sum(cl.deffrutodo))/(sum(case when cl.deffrutodo=0 then 0 else 1 end))),0))) as [FRUTOS DOBLES], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defguatab=0 then 0 else 1 end)>0,((sum(cl.defguatab))/(sum(case when cl.defguatab=0 then 0 else 1 end))),0))) as [GUATA BLANCA], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defherida=0 then 0 else 1 end)>0,((sum(cl.defherida))/(sum(case when cl.defherida=0 then 0 else 1 end))),0))) as [HERIDAS], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defmancha=0 then 0 else 1 end)>0,((sum(cl.defmancha))/(sum(case when cl.defmancha=0 then 0 else 1 end))),0))) as [MANCHAS], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defmedial=0 then 0 else 1 end)>0,((sum(cl.defmedial))/(sum(case when cl.defmedial=0 then 0 else 1 end))),0))) as [MEDIA LUNA], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defpiella=0 then 0 else 1 end)>0,((sum(cl.defpiella))/(sum(case when cl.defpiella=0 then 0 else 1 end))),0))) as [PIEL DE LAGARTO], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defrusset=0 then 0 else 1 end)>0,((sum(cl.defrusset))/(sum(case when cl.defrusset=0 then 0 else 1 end))),0))) as [RUSSET], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defsutura=0 then 0 else 1 end)>0,((sum(cl.defsutura))/(sum(case when cl.defsutura=0 then 0 else 1 end))),0))) as [SUTURAS], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.deffaltoc=0 then 0 else 1 end)>0,((sum(cl.deffaltoc))/(sum(case when cl.deffaltoc=0 then 0 else 1 end))),0))) as [FALTO COLOR], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.deframole=0 then 0 else 1 end)>0,((sum(cl.deframole))/(sum(case when cl.deframole=0 then 0 else 1 end))),0))) as [RAMOLEO], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defsinped=0 then 0 else 1 end)>0,((sum(cl.defsinped))/(sum(case when cl.defsinped=0 then 0 else 1 end))),0))) as [SIN PEDICELO]," +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defadhesi=0 then 0 else 1 end)>0,((sum(cl.defadhesi))/(sum(case when cl.defadhesi=0 then 0 else 1 end))),0))) as [ADHESION], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defdesfru=0 then 0 else 1 end)>0,((sum(cl.defdesfru))/(sum(case when cl.defdesfru=0 then 0 else 1 end))),0))) as [DESHID FRUTOS], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defdesped=0 then 0 else 1 end)>0,((sum(cl.defdesped))/(sum(case when cl.defdesped=0 then 0 else 1 end))),0))) as [DESHID PEDICELAR], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defblando=0 then 0 else 1 end)>0,((sum(cl.defblando))/(sum(case when cl.defblando=0 then 0 else 1 end))),0))) as [BLANDOS], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defherabi=0 then 0 else 1 end)>0,((sum(cl.defherabi))/(sum(case when cl.defherabi=0 then 0 else 1 end))),0))) as [HERIDA ABIERTA], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defmachuc=0 then 0 else 1 end)>0,((sum(cl.defmachuc))/(sum(case when cl.defmachuc=0 then 0 else 1 end))),0))) as [MACHUCON], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defpartid=0 then 0 else 1 end)>0,((sum(cl.defpartid))/(sum(case when cl.defpartid=0 then 0 else 1 end))),0))) as [PARTIDURAS], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defparagu=0 then 0 else 1 end)>0,((sum(cl.defparagu))/(sum(case when cl.defparagu=0 then 0 else 1 end))),0))) as [PARTIDURAS POR AGUA], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defparcic=0 then 0 else 1 end)>0,((sum(cl.defparcic))/(sum(case when cl.defparcic=0 then 0 else 1 end))),0))) as [PARTIDURAS CICATRIZADAS], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defpittin=0 then 0 else 1 end)>0,((sum(cl.defpittin))/(sum(case when cl.defpittin=0 then 0 else 1 end))),0))) as [PITTING], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defpudric=0 then 0 else 1 end)>0,((sum(cl.defpudric))/(sum(case when cl.defpudric=0 then 0 else 1 end))),0))) as [PUDRICION], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defmanpar=0 then 0 else 1 end)>0,((sum(cl.defmanpar))/(sum(case when cl.defmanpar=0 then 0 else 1 end))),0))) as [MANCHAS PARDAS], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defdanopa=0 then 0 else 1 end)>0,((sum(cl.defdanopa))/(sum(case when cl.defdanopa=0 then 0 else 1 end))),0))) as [DAÑO PAJARO], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defdesgar=0 then 0 else 1 end)>0,((sum(cl.defdesgar))/(sum(case when cl.defdesgar=0 then 0 else 1 end))),0))) as [DESGARROS], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defcorsie=0 then 0 else 1 end)>0,((sum(cl.defcorsie))/(sum(case when cl.defcorsie=0 then 0 else 1 end))),0))) as [CORTES SIERRA], " +
           " CONVERT(decimal(18,2),(iif(sum(case when cl.defsutura_exp=0 then 0 else 1 end)>0,((sum(cl.defsutura_exp))/(sum(case when cl.defsutura_exp=0 then 0 else 1 end))),0))) as [SUTURA EXPUESTA]" +
           " from controlpt as cl INNER JOIN planta AS  PL ON CL.placodigo=PL.placodigo " + where_cons + whe_planta + whe_linea + whe_turno + whe_proceso + whe_lote + whe_variedad + whe_productor + whe_acept +
           " " + group_cons + gro_planta + gro_linea + gro_turno + gro_proceso + gro_lote + gro_variedad + gro_productor + gro_acept;

            Session["consultapt01"] = consultatotal;
            
        }

        private void crea2consulta()
        {
            string planta = ddl_planta_d.SelectedValue;
            string linea = ddl_linea_d.SelectedValue;
            string turno = ddl_turno_d.SelectedValue;
            string proceso = ddl_proceso_d.SelectedValue;
            string lote = ddl_lote_d.SelectedValue;
            string variedad = ddl_variedad_d.SelectedValue;
            string productor = ddl_productor_d.SelectedValue;
            string acept = ddl_acep_d.SelectedValue;

            string where_cons = "where (cptfechor>='" + txt_fechainicio.Text + "' and cptfechor<='" + txt_fechafin.Text + "') ";
            string group_cons = "group by  cptcalibr";

            string whe_planta = "";
            string sel_planta = "";
            string gro_planta = "";
            if (planta != "Todas")
            {
                sel_planta = "select pl.pladescri as PLANTA,";
                whe_planta = " and cl.placodigo='" + planta + "' ";
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
                sel_linea = " CL.LINCODIGO AS LINEA, ";
                whe_linea = " and cl.lincodigo='" + linea + "' ";
                gro_linea = ", cl.lincodigo";
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
                sel_turno = " CL.turcodigo AS TURNO, ";
                whe_turno = " and cl.turcodigo='" + turno + "' ";
                gro_turno = ", cl.turcodigo";
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
                sel_proceso = " CL.cptproces AS PROCESO, ";
                whe_proceso = " and cl.cptproces='" + proceso + "' ";
                gro_proceso = ", cl.cptproces";
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
                sel_lote = " CL.cptnulote AS LOTE, ";
                whe_lote = " and cl.cptnulote='" + proceso + "' ";
                gro_lote = ", cl.cptnulote";
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
                sel_variedad = " CL.cptvarcod AS VARIEDAD_ID, CL.cptvardes AS VARIEDAD_NOMBRE, ";
                whe_variedad = " and cl.cptvarcod='" + variedad + "' ";
                gro_variedad = ", cl.cptvarcod, CL.cptvardes";
            }
            if (variedad == "Todas")
            {
                sel_variedad = " ' ' AS VARIEDAD_ID, 'Todas las variedades' AS VARIEDAD_NOMBRE, ";
                whe_variedad = "";
                gro_variedad = "";
            }



            string whe_productor = "";
            string sel_productor = "";
            string gro_productor = "";
            if (productor != "Todos")
            {
                sel_productor = " CL.CPTRUTPRR AS PRODUCREAL_ID, CL.CPTNOMPRE AS PRODUCTOREAL_NOMBRE, ";
                whe_productor = " and cl.CPTRUTPRR='" + productor + "' ";
                gro_productor = ", cl.CPTRUTPRR, CL.CPTNOMPRE";
            }
            if (productor == "Todos")
            {
                sel_productor = " ' ' AS PRODUCREAL_ID, 'Todos los productores' AS PRODUCTOREAL_NOMBRE, ";
                whe_productor = "";
                gro_productor = "";
            }


            string whe_acept = "";
            string sel_acept = "";
            string gro_acept = "";
            if (acept != "Todos")
            {
                sel_acept = " CL.ACEPTRECHA AS ACEPTRECHA, ";
                whe_acept = " and cl.ACEPTRECHA='" + acept + "' ";
                gro_acept = ", cl.ACEPTRECHA";
            }
            if (acept == "Todos")
            {
                sel_acept = " 'Aceptadas y Rechazadas' AS ACEPTRECHA, ";
                whe_acept = "";
                gro_acept = "";
            }

            string consultatotal = sel_planta + sel_turno + " 'fecha' AS FECHA, " + sel_linea + sel_proceso + sel_lote + sel_productor + "" +
                " '1' AS PRODUCTORETIQUETADO_ID, '1' AS PRODUCTORETIQUETADO_NOMBRE, " + sel_variedad + " '1' AS MARCA_ID, '1' AS MARCA_NOMBRE, " +
                " " + sel_acept + "" +
                " cptcalibr AS CPTCALIBRE , " +
" CONVERT(decimal(18,2),(iif(sum(case when ((f1+f2+f3+f4+f5)/5 )=0 then 0 else 1 end)>0,((sum(((f1+f2+f3+f4+f5)/5 )))/(sum(case when ((f1+f2+f3+f4+f5)/5 )=0 then 0 else 1 end))),0))) as PROMEDIO," +
" count(1) as CASOS" +
            " from controlpt as cl INNER JOIN planta AS  PL ON CL.placodigo=PL.placodigo " + where_cons + whe_planta + whe_linea + whe_turno + whe_proceso + whe_lote + whe_variedad + whe_productor + whe_acept +
               " " + group_cons + gro_planta + gro_linea + gro_turno + gro_proceso + gro_lote + gro_variedad + gro_productor + gro_acept;




            Session["consultapt2"] = consultatotal;
           // Response.Redirect("~/Reporte/ResumenProductoTerminadoSS.aspx");

        }
        
        
        
    }
}