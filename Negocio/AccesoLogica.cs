using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Mainsite
{
    public class AccesoLogica
    {
        public static DataTable obtenerImpresorasTable()
        {
            return AccesoDatos.obtenerImpresorasTable();
        }

        public static DataTable ObtenerEmpleados()
        {
            return AccesoDatos.ObtenerEmpleados();
        }


        public int AL_InsertarEmpleados(string EmpNombre, string EmpApellido, string EmpRutSD, string EmpRutDig, string EmpCargo, string EmpCodigo, string EmpPlantaId)
        {
            AccesoDatos acceso = new AccesoDatos();
            return acceso.AD_InsertarEmpleados(EmpNombre, EmpApellido, EmpRutSD, EmpRutDig, EmpCargo, EmpCodigo, EmpPlantaId);
        }

    }
}