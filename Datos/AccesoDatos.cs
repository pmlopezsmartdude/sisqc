using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace Mainsite
{
    public class AccesoDatos
    {
        public static int insertarImpresora(string nombreimp, string marcaimp, string ipimp)
        {
            SqlCommand _comando = MetodosDatos.CrearCommandoProc("insimpresora");
            _comando.Parameters.AddWithValue("@nombreimp", nombreimp);
            _comando.Parameters.AddWithValue("@marcaimp", marcaimp);
            _comando.Parameters.AddWithValue("@ipimp", ipimp);
            return MetodosDatos.EjecutarComando(_comando);
        }

        public int AD_InsertarEmpleados(string EmpNombre, string EmpApellido, string EmpRutSD, string EmpRutDig, string EmpCargo, string EmpCodigo, string EmpPlantaId)
        {
            SqlCommand _comando = MetodosDatos.CrearCommandoProc("[InsertarEmpleado]");
            _comando.Parameters.AddWithValue("@nombre", EmpNombre);
            _comando.Parameters.AddWithValue("@apellido", EmpApellido);
            _comando.Parameters.AddWithValue("@rut", EmpRutSD);
            _comando.Parameters.AddWithValue("@digito", EmpRutDig);
            _comando.Parameters.AddWithValue("@cargo", EmpCargo);
            _comando.Parameters.AddWithValue("@codigo", EmpCodigo);
            _comando.Parameters.AddWithValue("@planta", EmpPlantaId);

            return MetodosDatos.EjecutarComando(_comando);
        }

        public static DataTable obtenerImpresorasTable()
        {
            SqlCommand _comando = MetodosDatos.CrearComando();
            _comando.CommandText = "select dbo.impresoras.nombre,dbo.impresoras.marca,CAST(ROUND((cast(dbo.impresoras.ip as bigint)/16777216),0,1) as varchar(4))+'.'+ CAST((ROUND((cast(dbo.impresoras.ip as bigint) / 65536),0,1) %256) as varchar(4))+'.'+ CAST((ROUND((cast(dbo.impresoras.ip as bigint) / 256),0,1) %256) as varchar(4))+'.'+ CAST((cast(dbo.impresoras.ip as bigint) %256) as varchar(4)) as IPDottedNotation from dbo.impresoras";
            return MetodosDatos.EjecutarComandoSelect(_comando);
        }

        public static DataTable ObtenerEmpleados()
        {
            SqlCommand _comando = MetodosDatos.CrearComando();
            _comando.CommandText = "SELECT * FROM [Empleados]";
            return MetodosDatos.EjecutarComandoSelect(_comando);
        }



    }
}