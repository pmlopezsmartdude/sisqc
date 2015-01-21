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
    public partial class CC_PAC_075_INGRESO : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
                {
                System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisconpt");
            System.Configuration.ConnectionStringSettings connStringmain;
            System.Configuration.ConnectionStringSettings connStringLM;
            if (Session["PlantaName"] != null)
            {
                
                    connStringmain = rootWebConfig.ConnectionStrings.ConnectionStrings["CONTROLPTConnectionString"];
                    string PlantaNombre = Session["PlantaName"].ToString();
                    string comando = "SELECT convert(varchar(10),placodigo) as placodigo FROM planta WHERE pladescri ='" + PlantaNombre + "'";
                    SqlConnection conexion = new SqlConnection(connStringmain.ToString());
                    conexion.Open();
                    SqlCommand sql = new SqlCommand(comando, conexion);
                    using (SqlDataReader reader = sql.ExecuteReader())
                    {
                        reader.Read();
                        txt_cod_plan.Text = reader.GetString(0);
                    }
                    conexion.Close();
                

            }
            if (Session["PlantaName"].ToString() == "Planta Mostazal")
            {
                connStringLM = rootWebConfig.ConnectionStrings.ConnectionStrings["LotManager01"];

            }
            else
            {
                connStringLM = rootWebConfig.ConnectionStrings.ConnectionStrings["LotManager40"];

            }

                }
            catch
            {
            }
            if (!IsPostBack)
            {
                DropLinea();
                DropVariedad();
                DDL_prodreal();
            }
            lbl_fecha.Text = DateTime.Now.ToString("yyyy-MM-dd");
            lbl_hora.Text = DateTime.Now.ToString("HH:mm:ss");



        }

        protected void proc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string proceso = Convert.ToString(drop_proc_d.SelectedValue);

            DropLote(proceso);

        }

        protected void linea_SelectedIndexChanged(object sender, EventArgs e)
        {
            int linea = Convert.ToInt32(drop_linea_d.SelectedValue);

            BuscaTurno(linea);

        }

        protected void turno_SelectedIndexChanged(object sender, EventArgs e)
        {
            int linea = Convert.ToInt32(drop_linea_d.SelectedValue);
            string turno = Convert.ToString(drop_turno_d.SelectedValue);

            DDLProcesos(linea, turno);

        }

        protected void lote_SelectedIndexChanged(object sender, EventArgs e)
        {

         //   txtDescarte.Focus();

        }

        private void DDLProcesos(int linea, string turno)
        {
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisconpt");
            System.Configuration.ConnectionStringSettings connStringLM;
            if (Session["PlantaName"].ToString() == "Planta Mostazal")
            {
                connStringLM = rootWebConfig.ConnectionStrings.ConnectionStrings["LotManager01"];
            }
            else
            {
                connStringLM = rootWebConfig.ConnectionStrings.ConnectionStrings["LotManager40"];
            }
            SqlConnection con = new SqlConnection(connStringLM.ToString());
            con.Open();
            //linea
            SqlCommand cmd_proc = new SqlCommand("select  PROC_NumeroProcesso from Ana_Linea as lin inner join [PROD_Processo] as prodproc on lin.lin_codice=proc_linea_fk " +
            " inner join ANA_Turno as tur on tur.TUR_Linea_FK=lin.lin_codice where lin.LIN_Codice='" + linea + "' and tur.TUR_Descrizione='" + turno + "'" +
            " group by PROC_NumeroProcesso order by PROC_NumeroProcesso desc", con);
            SqlDataAdapter sda_proc = new SqlDataAdapter(cmd_proc);
            DataSet ds_proc = new DataSet();
            sda_proc.Fill(ds_proc);

            drop_proc_d.DataSourceID = "";
            drop_proc_d.DataSource = ds_proc;
            drop_proc_d.DataBind();

            string proceso = Convert.ToString(drop_proc_d.SelectedValue);

            DropLote(proceso);
            con.Close();
        }

        private void DropLinea()
        {
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisconpt");
            System.Configuration.ConnectionStringSettings connStringLM;
            if (Session["PlantaName"].ToString() == "Planta Mostazal")
            {
                connStringLM = rootWebConfig.ConnectionStrings.ConnectionStrings["LotManager01"];
            }
            else
            {
                connStringLM = rootWebConfig.ConnectionStrings.ConnectionStrings["LotManager40"];
            }
            SqlConnection con = new SqlConnection(connStringLM.ToString());
            con.Open();
            SqlCommand cmd_linea = new SqlCommand("select  LIN_Codice from Ana_Linea as lin inner join [PROD_Processo] as prodproc on lin.lin_codice=proc_linea_fk group by LIN_Codice", con);
            SqlDataAdapter sda_linea = new SqlDataAdapter(cmd_linea);
            DataSet ds_linea = new DataSet();
            sda_linea.Fill(ds_linea);

            drop_linea_d.DataSourceID = "";
            drop_linea_d.DataSource = ds_linea;
            drop_linea_d.DataBind();

            int linea = Convert.ToInt32(drop_linea_d.SelectedValue);

            BuscaTurno(linea);


            con.Close();
        }

        private void BuscaTurno(int linea)
        {
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisconpt");
            System.Configuration.ConnectionStringSettings connStringLM;
            if (Session["PlantaName"].ToString() == "Planta Mostazal")
            {
                connStringLM = rootWebConfig.ConnectionStrings.ConnectionStrings["LotManager01"];
            }
            else
            {
                connStringLM = rootWebConfig.ConnectionStrings.ConnectionStrings["LotManager40"];
            }
            SqlConnection con = new SqlConnection(connStringLM.ToString());
            con.Open();
            //turno
            SqlCommand cmd_turno = new SqlCommand("select tur_codice, TUR_Descrizione from Ana_Turno where tur_linea_fk='" + linea + "'", con);
            SqlDataAdapter sda_turno = new SqlDataAdapter(cmd_turno);
            DataSet ds_turno = new DataSet();
            sda_turno.Fill(ds_turno);

            drop_turno_d.DataSourceID = "";
            drop_turno_d.DataSource = ds_turno;
            drop_turno_d.DataBind();


            int linea_2 = Convert.ToInt32(drop_linea_d.SelectedValue);
            string turno = Convert.ToString(drop_turno_d.SelectedValue);

            DDLProcesos(linea_2, turno);

            con.Close();
        }

        private void DropLote(string proceso)
        {
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisconpt");
            System.Configuration.ConnectionStringSettings connStringLM;
            if (Session["PlantaName"].ToString() == "Planta Mostazal")
            {
                connStringLM = rootWebConfig.ConnectionStrings.ConnectionStrings["LotManager01"];
            }
            else
            {
                connStringLM = rootWebConfig.ConnectionStrings.ConnectionStrings["LotManager40"];
            }
            SqlConnection con = new SqlConnection(connStringLM.ToString());
            con.Open();
            //turno
            SqlCommand cmd_lote = new SqlCommand("select distinct LOT_NumeroLotto from PROD_Lotto as lote inner join  [PROD_Processo] as proce on lote.LOT_processo_FK=proce.proc_id where  proce.proc_numeroprocesso='" + proceso + "'", con);
            SqlDataAdapter sda_lote = new SqlDataAdapter(cmd_lote);
            DataSet ds_lote = new DataSet();
            sda_lote.Fill(ds_lote);

            drop_lote_d.DataSourceID = "";
            drop_lote_d.DataSource = ds_lote;
            drop_lote_d.DataBind();

            con.Close();
        }

        protected void Limpiar_Click(object sender, EventArgs e)
        {
            txt_exp_est.Text = "0";
            txt_exp_desc.Text = "0";
            txt_desc_2.Text = "0";
            txt_desc_3.Text = "0";
            txt_1desecho.Text = "0";
            txt_2_exp.Text = "0";
            txt_3_exp.Text = "0";
            txt_desc_mesa.Text = "0";
            txt_desc_manual.Text = "0";
            txt_obser.Text = "0";
            lbl_fecha.Text = DateTime.Now.ToString("yyyy-MM-dd");
            lbl_hora.Text = DateTime.Now.ToString("HH:mm:ss");

            txt_exp_est.Focus();
            btnGrabar.Enabled = true;
            btnLimpiar.Enabled = true;
        }

        protected void Grabar_Click(object sender, EventArgs e)
        {
            string numeroctrl = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffffffzzz");
            string username = HttpContext.Current.User.Identity.Name;
            string planta = txt_cod_plan.Text;
            string CodProc = drop_proc_d.SelectedValue;
            string Linea = drop_linea_d.SelectedValue;
            string Turno = drop_turno_d.SelectedValue;
            string Lote = drop_lote_d.SelectedValue;
            string fecha = DateTime.Now.ToString("yyyy-MM-dd");
            string hora = DateTime.Now.ToString("HH:mm:ss");
            string productor = DDL_prodreal_d.SelectedValue;
            string variedad = DDL_variedad_d.SelectedValue;
            if (txt_exp_est.Text == "") { txt_exp_est.Text = "0"; };
            if (txt_exp_desc.Text == "") { txt_exp_desc.Text = "0"; };
            if (txt_desc_2.Text == "") { txt_desc_2.Text = "0"; };
            if (txt_desc_3.Text == "") { txt_desc_3.Text = "0"; };
            if (txt_1desecho.Text == "") { txt_1desecho.Text = "0"; };
            if (txt_2_exp.Text == "") { txt_2_exp.Text = "0"; };
            if (txt_3_exp.Text == "") { txt_3_exp.Text = "0"; };
            if (txt_desc_mesa.Text == "") { txt_desc_mesa.Text = "0"; };
            if (txt_desc_manual.Text == "") { txt_desc_manual.Text = "0"; };
            if (txt_obser.Text == "") { txt_obser.Text = "0"; };
            

            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisconpt");
            System.Configuration.ConnectionStringSettings connStringmain;
            connStringmain = rootWebConfig.ConnectionStrings.ConnectionStrings["CONTROLPTConnectionString"];

            string comando = "insert into CC_PAC_075_V2 (cptnumero,	username,	planta,	CodProc,	Linea,	Turno,	Lote,	fecha,	hora,	productor,	variedad,	txt_exp_est,	txt_exp_desc,	txt_desc_2,	txt_desc_3,	txt_1desecho,	txt_2_exp,	txt_3_exp,	txt_desc_mesa,	txt_desc_manual,	txt_obser)" +
            " values ('" + numeroctrl + "','" + username + "','" + planta + "','" + CodProc + "','" + Linea + "','" + Turno + "','" + Lote + "','" + fecha + "','" + hora + "','" + productor + "','" + variedad + "','" + txt_exp_est.Text + "','" + txt_exp_desc.Text + "','" + txt_desc_2.Text + "','" + txt_desc_3.Text + "','" + txt_1desecho.Text + "','" + txt_2_exp.Text + "','" + txt_3_exp.Text + "','" + txt_desc_mesa.Text + "','" + txt_desc_manual.Text + "','" + txt_obser.Text + "')";

            try
            {
                SqlConnection conexion = new SqlConnection(connStringmain.ToString());
                conexion.Open();


                using (SqlCommand sql = new SqlCommand(comando, conexion))
                {
                    sql.ExecuteNonQuery();
                    conexion.Close();
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "scriptName", "alert(\"Registro guardado OK\");", true);
                txt_exp_est.Text = "0";
                txt_exp_desc.Text = "0";
                txt_desc_2.Text = "0";
                txt_desc_3.Text = "0"; 
                txt_1desecho.Text = "0";
                txt_2_exp.Text = "0";
                txt_3_exp.Text = "0"; 
                txt_desc_mesa.Text = "0";
                txt_desc_manual.Text = "0";
                txt_obser.Text = "0";
                lbl_fecha.Text = DateTime.Now.ToString("yyyy-MM-dd");
                lbl_hora.Text = DateTime.Now.ToString("HH:mm:ss");

            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "scriptName", "alert(\"Registro no guardado\");", true);
            }
            
            btnGrabar.Enabled = true;
            btnLimpiar.Enabled = true;
        }

        protected void btnLoadData_click(object senders, EventArgs e)
        {

        }


        private void DropVariedad()
        {
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisconpt");
            System.Configuration.ConnectionStringSettings connStringLM;
            connStringLM = rootWebConfig.ConnectionStrings.ConnectionStrings["Agroweb_planta"];
            SqlConnection con = new SqlConnection(connStringLM.ToString());
            try
            {
                con.Open();
                //linea
                SqlCommand cmd_proc = new SqlCommand("select COD_VARIEDAD, VARDESC from VARIEDAD where CODESPECIE='21' order by vardesc asc", con);
                SqlDataAdapter sda_proc = new SqlDataAdapter(cmd_proc);
                DataSet ds_proc = new DataSet();
                sda_proc.Fill(ds_proc);
                DDL_variedad_d.DataSourceID = "";
                DDL_variedad_d.DataSource = ds_proc;
                DDL_variedad_d.DataBind();
                con.Close();
            }
            catch
            {
                DDL_variedad_d.DataSourceID = "";
                DDL_variedad_d.DataSource = "";
                DDL_variedad_d.DataBind();
            }


        }

        private void DDL_prodreal()
        {
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisconpt");
            System.Configuration.ConnectionStringSettings connStringLM;
            connStringLM = rootWebConfig.ConnectionStrings.ConnectionStrings["Agroweb_planta"];
            SqlConnection con = new SqlConnection(connStringLM.ToString());
            try
            {
                con.Open();
                SqlCommand cmd_proc = new SqlCommand("select CODPRODUCTOR, ALIAS, DESCRIPCION from [dbo].[PRODUCTORES] group by CODPRODUCTOR, ALIAS, DESCRIPCION order by DESCRIPCION asc", con);
                SqlDataAdapter sda_proc = new SqlDataAdapter(cmd_proc);
                DataSet ds_proc = new DataSet();
                sda_proc.Fill(ds_proc);
                DDL_prodreal_d.DataSourceID = "";
                DDL_prodreal_d.DataSource = ds_proc;
                DDL_prodreal_d.DataBind();
                con.Close();
            }
            catch
            {
                DDL_prodreal_d.DataSourceID = "";
                DDL_prodreal_d.DataSource = "";
                DDL_prodreal_d.DataBind();
            }

        }

    }
}