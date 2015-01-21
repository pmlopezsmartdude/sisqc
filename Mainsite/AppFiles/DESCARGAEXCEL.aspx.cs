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

namespace Mainsite.AppFiles
{
    public partial class DESCARGAEXCEL : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DDL_linea();
                DDL_turno();
            }

        }

        private void DDL_linea()
        {
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisqc");
            System.Configuration.ConnectionStringSettings connStringLM;
            connStringLM = rootWebConfig.ConnectionStrings.ConnectionStrings["CONTROLPTConnectionString"];
            SqlConnection con = new SqlConnection(connStringLM.ToString());
            con.Open();
            //linea
            SqlCommand cmd_proc = new SqlCommand("SELECT DISTINCT linea FROM CC_PAC_075_V2 UNION SELECT DISTINCT LINCODIGO FROM CONTROLPT UNION SELECT DISTINCT CTRL_LIN FROM CC_PAC_003", con);
            SqlDataAdapter sda_proc = new SqlDataAdapter(cmd_proc);
            DataSet ds_proc = new DataSet();
            sda_proc.Fill(ds_proc);

            drop_linea_d.DataSourceID = "";
            drop_linea_d.DataSource = ds_proc;
            drop_linea_d.DataBind();
            drop_linea_d.Items.Add("Todas");
            drop_linea_d.SelectedIndex = -1;
            drop_linea_d.Items.FindByText("Todas").Selected = true;
            

            con.Close();
        }
        private void DDL_turno()
        {
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisqc");
            System.Configuration.ConnectionStringSettings connStringLM;
            connStringLM = rootWebConfig.ConnectionStrings.ConnectionStrings["CONTROLPTConnectionString"];
            SqlConnection con = new SqlConnection(connStringLM.ToString());
            con.Open();
            //linea
            SqlCommand cmd_proc = new SqlCommand("SELECT DISTINCT Turno FROM CC_PAC_075_V2 UNION SELECT DISTINCT turcodigo FROM CONTROLPT UNION SELECT DISTINCT Ctrl_Turno FROM CC_PAC_003", con);
            SqlDataAdapter sda_proc = new SqlDataAdapter(cmd_proc);
            DataSet ds_proc = new DataSet();
            sda_proc.Fill(ds_proc);

            drop_turno_d.DataSourceID = "";
            drop_turno_d.DataSource = ds_proc;
            drop_turno_d.DataBind();
            drop_turno_d.Items.Add("Todos");
            drop_turno_d.SelectedIndex = -1;
            drop_turno_d.Items.FindByText("Todos").Selected = true;

            con.Close();
        }

        protected void Click_003(object sender, ImageClickEventArgs e)
        {
            string turno = drop_turno_d.SelectedValue;
            string linea = drop_linea_d.SelectedValue;
            string inicio = txt_fechainicio.Text;
            string fin = txt_fechafin.Text;
            string where = "";

            if (turno == "Todos" && linea=="Todas")
            {
                where = "where (SUBSTRING(ctrl_fechora,1,10))>='" + inicio + "' and (SUBSTRING(ctrl_fechora,1,10))<='" + fin + "'";
            }

            if (turno != "Todos" && linea == "Todas")
            {
                where = "where ((SUBSTRING(ctrl_fechora,1,10))>='" + inicio + "' and (SUBSTRING(ctrl_fechora,1,10))<='" + fin + "') and Ctrl_Turno = '" + turno + "'";
            }

            if (linea != "Todas" && turno == "Todos")
            {
                where = "where ((SUBSTRING(ctrl_fechora,1,10))>='" + inicio + "' and (SUBSTRING(ctrl_fechora,1,10))<='" + fin + "') and Ctrl_Lin = '" + linea + "'";
            }

            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisqc");
            System.Configuration.ConnectionStringSettings connStringmain;
            connStringmain = rootWebConfig.ConnectionStrings.ConnectionStrings["CONTROLPTConnectionString"];
            string PlantaNombre = Session["PlantaName"].ToString();
            SqlConnection con = new SqlConnection(connStringmain.ToString());
            string sql = " SELECT [Ctrl_id]  as ID" +
            "  ,[Ctrl_CodProc] as [PROCESO]" +
            " ,[Ctrl_CodPlan] as [PLANTA]" +
            " ,[Ctrl_Lin] as [LINEA]" +
            " ,[Ctrl_Usuario] as [USUARIO]" +
            " ,[Ctrl_Turno] as [TURNO]" +
            " ,[Ctrl_Lote] as [LOTE]" +
            " ,[Ctrl_FecHora] as [FECHA/HORA]" +
            " ,[Productor] as [PRODUCTOR]" +
            " ,[Variedad] as [VARIEDAD]" +
            " ,[txt_precalibre] as [PRECALIBRE]" +
            " ,[txt_trips] as [DAÑO DE TRIPS]" +
            " ,[txt_escama] as [ESCAMA]" +
            " ,[txt_frudeformes] as [FRUTOS DEFORMES]" +
            " ,[txt_dobles] as [FRUTOS DOBLES]" +
            " ,[txt_guatablanca] as [GUATA BLANCA]" +
            " ,[txt_heri_cica] as [HERIDAS CICATRIZADAS]" +
            " ,[txt_manchas] as [MANCHAS]" +
            " ,[txt_medluna] as [MEDIA LUNA]" +
            " ,[txt_lagarto] as [PIEL DE LAGARTO]" +
            " ,[txt_russet] as [RUSSET]" +
            " ,[txt_sutura] as [SUTURA]" +
            " ,[txt_faltocolor] as [FALTO COLOR]" +
            " ,[txt_ramaleo] as [RAMALEO]" +
            " ,[txt_pedicelo] as [SIN PEDICELO]" +
            " ,[txt_adhesion] as [ADHESION]" +
            " ,[txt_deshid_frutos] as [DESHIDRATACIÓN DE FRUTOS]" +
            " ,[txt_deshid_ped] as [DESHIDRATACIÓN PEDICELAR]" +
            " ,[txt_blandos] as [BLANDOS]" +
            " ,[txt_heri_abiertas] as [HERIDAS ABIERTAS]" +
            " ,[txt_machucon] as [MACHUCÓN]" +
            " ,[txt_part_cica] as [PARTIDURAS CICATRIZADAS]" +
            " ,[txt_pitting] as [PITTING]" +
            " ,[txt_pudricion] as [PUDRICIÓN]" +
            " ,[txt_part_agua] as [PARTIDURAS POR AGUA]" +
            " ,[txt_pardas] as [MANCHAS PARDAS]" +
            " ,[txt_pajaro] as [DAÑO DE PAJARO]" +
            " ,[txt_desgarros] as [DESGARROS]" +
            " ,[txt_sierras] as [CORTE DE SIERRAS]" +
            " ,[txt_sut_exp] as [SUTURA EXPUESTA]" +
            " ,[txt_qc_pudricion] as [QC EXPORTABLE FRUTA COMERCIAL < 10%  SIN PUDRICION]" +
            " ,[txt_comp_pudricion] as [COMP EXPORTABLE FRUTA COMERCIAL < 10% SIN PUDRICION]" +
            " ,[txt_qc_deshechos] as [QC EXPORTABLE DESECHO < 2%]" +
            " ,[txt_comp_deshechos] as [COMP EXPORTABLE DESECHO < 2%]" +
            " ,[txt_qc_exportable] as [QC COMERCIAL EXPORTABLE]" +
            " ,[txt_comp_exportable] as [COMP COMERCIAL EXPORTABLE]" +
            " ,[txt_qc_deshecho_com] as [QC COMERCIAL DESECHO < 2%]" +
            " ,[txt_comp_deshecho_com] as [COMP COMERCIAL DESECHO < 2%]" +
            " ,[txt_num_frutos] as [DESECHO NUMERO FRUTOS]" +
            " ,[txt_exportable_2] as [DESECHO EXPORTABLE < 2%]" +
            " ,[txt_comercial_5] as [DESECHO COMERCIAL < 5%]" +
            " ,[txt_obser] as [OBSERVACIONES]" +
            "   FROM [CONTROLPT].[dbo].[CC_PAC_003]";


            SqlCommand command = new SqlCommand(sql + where, con);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            this.ExportToExcel(dt, "MesaDeSeleccion.xls");
        }

        protected void Click_005(object sender, ImageClickEventArgs e)
        {
            string turno = drop_turno_d.SelectedValue;
            string linea = drop_linea_d.SelectedValue;
            string inicio = txt_fechainicio.Text;
            string fin = txt_fechafin.Text;
            string where = "";

            if (turno == "Todos" && linea == "Todas")
            {
                where = "where cl.cptfechor>='" + inicio + "' and cl.cptfechor<='" + fin + "'";
            }

            if (turno != "Todos" && linea == "Todas")
            {
                where = "where (cl.cptfechor>='" + inicio + "' and cl.cptfechor<='" + fin + "') and cl.turcodigo = '" + turno + "'";
            }

            if (linea != "Todas" && turno == "Todos")
            {
                where = "where (cl.cptfechor>='" + inicio + "' and cl.cptfechor<='" + fin + "') and cl.lincodigo = '" + linea + "'";
            }

            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisqc");
            System.Configuration.ConnectionStringSettings connStringmain;
            connStringmain = rootWebConfig.ConnectionStrings.ConnectionStrings["CONTROLPTConnectionString"];
            string PlantaNombre = Session["PlantaName"].ToString();
            SqlConnection con = new SqlConnection(connStringmain.ToString());
            string sql = " select  cl.cptnumero as [ID]" +
               "  ,cl.placodigo as [PLANTA]" +
               "  ,cl.turcodigo as [TURNO]" +
               "  ,cl.cptfechor as [FECHA]" +
               "  ,cl.usurutusu as [USUARIO]" +
               "  ,cl.lincodigo as [LINEA]" +
               "  ,cl.cptproces as [PROCESO]" +
               "  ,cl.cptnulote as [LOTE]" +
               "  ,cl.cptrutprr as [ID PRODUCTOR REAL]" +
               "  ,cl.cptnompre as [NOMBRE PRODUCTOR REAL]" +
               "  ,cl.cptrutpet as [ID PRODUCTOR ETIQUETADO]" +
               "  ,cl.cptnompet as [NOMBRE PRODUCTOR ETIQUETADO]" +
               "  ,cl.cptespcod as [CODIGO ESPECIE]" +
               "  ,cl.cptespdes as [NOMBRE ESPECIE]" +
               "  ,cl.cptvarcod as [CODIGO VARIEDAD]" +
               "  ,cl.cptvardes as [NOMBRE VARIEDAD]" +
               "  ,cl.cptcalibr as [CALIBR3E]" +
               "  ,cl.cptmarcod as [CODIGO MARCA]" +
               "  ,cl.cptmardes as [NOMBRE MARCA]" +
               "  ,cl.cptembcod as [CODIGO EMBALAJE]" +
               "  ,cl.cptembdes as [NOMBRE EMBALAJE]" +
               "  ,cl.cptenvcod as [CODIGO ENVASE]" +
               "  ,cl.cptenvdes as [NOMBRE ENVASE]" +
               "  ,cl.cptpesone as [PESO NETO]" +
               "  ,cl.cptsalida as [SALIDA]" +
               "  ,cl.cptcodcja as [CODIGO CAJA]" +
               "  ,cl.cptclasificacion as [CLASIFICACION]" +
               "  ,cl.cptdestino as [DESTINO]" +
               "  ,def.pesoneto as [PESO NETO II]" +
               "  ,cl.AceptRecha as [RESULTADO CAJA]" +
               "  ,CONVERT(VARCHAR(10),def.defcalbaj) as [CALIBRE BAJO < 10%]" +
               "  ,CONVERT(VARCHAR(10),def.defcalnor) as [CALIBRE OK]" +
               "  ,CONVERT(VARCHAR(10),def.defcalsob) as [CALIBRE SOBRE < 20%]" +
               "  ,CONVERT(VARCHAR(10),def.defprecal) as [PRE CALIBRE]" +
               "  ,CONVERT(VARCHAR(10),def.defdanotr) as [DAÑO TRIPS]" +
               "  ,CONVERT(VARCHAR(10),def.defescama) as [ESCAMA]" +
               "  ,CONVERT(VARCHAR(10),def.deffrutode) as [FRUTOS DEFORMES]" +
               "  ,CONVERT(VARCHAR(10),def.deffrutodo) as [FRUTOS DOBLES]" +
               "  ,CONVERT(VARCHAR(10),def.defguatab) as [GUATA BLANCA]" +
               "  ,CONVERT(VARCHAR(10),def.defherida) as [HERIDAS]" +
               "  ,CONVERT(VARCHAR(10),def.defmancha) as [MANCHAS]" +
               "  ,CONVERT(VARCHAR(10),def.defmedial) as [MEDIA LUNA]" +
               "  ,CONVERT(VARCHAR(10),def.defpiella) as [PIEL DE LAGARTO]" +
               "  ,CONVERT(VARCHAR(10),def.defrusset) as [RUSSET]" +
               "  ,CONVERT(VARCHAR(10),def.defsutura) as [SUTURA]" +
               "  ,CONVERT(VARCHAR(10),def.deffaltoc) as [FALTO DE COLOR]" +
               "  ,CONVERT(VARCHAR(10),def.deframole) as [RAMALEO]" +
               "  ,CONVERT(VARCHAR(10),def.defsinped) as [SIN PEDICELO]" +
               "  ,CONVERT(VARCHAR(10),(defprecal+defdanotr+defescama+deffrutode+deffrutodo+defguatab+defherida+defmancha+defmedial+defpiella+defrusset+defsutura+deffaltoc+deframole+defsinped)) as [SUMA CALIDAD]" +
               "  ,CONVERT(VARCHAR(10),def.defadhesi) as [ADHESIÓN]" +
               "  ,CONVERT(VARCHAR(10),def.defdesfru) as [DESHIDRATACIÓN DE FRUTOS]" +
               "  ,CONVERT(VARCHAR(10),def.defdesped) as [DESHIDRATACIÓN PEDICELAR]" +
               "  ,CONVERT(VARCHAR(10),def.defblando) as [BLANDOS]" +
               "  ,CONVERT(VARCHAR(10),def.defherabi) as [HERIDAS ABIERTAS]" +
               "  ,CONVERT(VARCHAR(10),def.defmachuc) as [MACHUNÓN]" +
               "  ,CONVERT(VARCHAR(10),def.defpartid) as [PARTIDURAS]" +
               "  ,CONVERT(VARCHAR(10),def.defparagu) as [PARTIDURAS POR AGUA]" +
               "  ,CONVERT(VARCHAR(10),def.defparcic) as [PARTIDURA CICATRIZADA]" +
               "  ,CONVERT(VARCHAR(10),def.defpittin) as [PITTING]" +
               "  ,CONVERT(VARCHAR(10),def.defpudric) as [PUDRICION]" +
               "  ,CONVERT(VARCHAR(10),def.defmanpar) as [MANCHAS PARDAS]" +
               "  ,CONVERT(VARCHAR(10),def.defdanopa) as [DAÑO DE PAJARO]" +
               "  ,CONVERT(VARCHAR(10),def.defdesgar) as [DESGARRO]" +
               "  ,CONVERT(VARCHAR(10),def.defcorsie) as [CORTE DE SIERRA]" +
               "  ,CONVERT(VARCHAR(10),def.defsutura_exp) as [SUTURA EXPUESTA]" +
               "  ,def.observac as [OBSERVACIONES]" +
               "  ,CONVERT(VARCHAR(10),(defadhesi+defdesfru+defdesped+defblando+defherabi+defmachuc+defpartid+defparagu+defparcic+defpittin+defpudric+defmanpar+defdanopa+defdesgar+defcorsie+defsutura_exp)) as [SUMA CONDICIÓN]" +
               "  ,CONVERT(VARCHAR(10),CONVERT(decimal(18, 2),(f1+f2+f3+f4+f5)/5.0)) as [PROMEDIO SOLIDOS SOLUBLES]" +
               "  from controlpt as cl inner join defecto as def on cl.cptnumero=def.cptnumero inner join solidossolubles as sol on cl.cptnumero=sol.cptnumero ";



            SqlCommand command = new SqlCommand(sql+where, con);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            this.ExportToExcel(dt, "ProductoTerminado.xls");
        }

        protected void Click_075(object sender, ImageClickEventArgs e)
        {
            string turno = drop_turno_d.SelectedValue;
            string linea = drop_linea_d.SelectedValue;
            string inicio = txt_fechainicio.Text;
            string fin = txt_fechafin.Text;
            string where = "";

            if (turno == "Todos" && linea == "Todas")
            {
                where = "where [fecha]>='" + inicio + "' and [fecha]<='" + fin + "'";
            }

            if (turno != "Todos" && linea == "Todas")
            {
                where = "where ([fecha]>='" + inicio + "' and [fecha]<='" + fin + "') and Turno = '" + turno + "'";
            }

            if (linea != "Todas" && turno == "Todos")
            {
                where = "where ([fecha]>='" + inicio + "' and [fecha]<='" + fin + "') and Linea = '" + linea + "'";
            }

            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisqc");
            System.Configuration.ConnectionStringSettings connStringmain;
            connStringmain = rootWebConfig.ConnectionStrings.ConnectionStrings["CONTROLPTConnectionString"];
            string PlantaNombre = Session["PlantaName"].ToString();
            SqlConnection con = new SqlConnection(connStringmain.ToString());
            string sql = " SELECT  [cptnumero] as [ID]" +
               "       ,[username] as [RESPONSABLE]" +
               "       ,[planta] as [PLANTA]" +
               "       ,[CodProc] as [PROCESO]" +
               "       ,[Linea] as [LINEA]" +
               "       ,[Turno] as [TURNO]" +
               "       ,[Lote] as [LOTE]" +
               "       ,[fecha] as [FECHA]" +
               "       ,[hora] as [HORA]" +
               "       ,[productor] as [PRODUCTOR]" +
               "       ,[variedad] as [VARIEDAD]" +
               "       ,[txt_exp_est] as [% EXPORTABLE ESTIMADO]" +
               "       ,[txt_exp_desc] as [% EXPORTABLE DESCARTADOR]" +
               "       ,[txt_desc_2] as [% DESCARTE CAT 2]" +
               "       ,[txt_desc_3] as [% DESCARTE CAT 3]" +
               "       ,[txt_1desecho] as [CAT 1 % (DESECHO)]" +
               "       ,[txt_2_exp] as [CAT 2 % (EXPORTABLE)]" +
               "       ,[txt_3_exp] as [CAT 3 % (EXPORTABLE)]" +
               "       ,[txt_desc_mesa] as [% EXPORTABLE DESCARTE MESA DE SELECCIÓN]" +
               "       ,[txt_desc_manual] as [% EXPORTABLE DESCARTE MANUAL LINEA]" +
               "       ,[txt_obser] as [OBSERVACIONES]" +
               "   FROM [CONTROLPT].[dbo].[CC_PAC_075_V2] ";




            SqlCommand command = new SqlCommand(sql+where, con);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            this.ExportToExcel(dt, "DescarteComercial.xls");
        }

        public void ExportToExcel(DataTable dt, string filename)
        {
            if (dt.Rows.Count > 0)
            {
                System.IO.StringWriter tw = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                DataGrid dgGrid = new DataGrid();
                dgGrid.DataSource = dt;
                dgGrid.DataBind();

                dgGrid.RenderControl(hw);
                Response.ContentType = "application/vnd.ms-excel";
                Response.BinaryWrite(System.Text.Encoding.UTF8.GetPreamble());
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                this.EnableViewState = false;
                Response.Write(tw.ToString());
                Response.End();
                
            }
        }


    }
}