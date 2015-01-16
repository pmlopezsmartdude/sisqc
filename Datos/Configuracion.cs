using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datos
{
    public class Configuracion
    {
        static string cadenaConexion = @"Data Source=192.168.1.104;Initial Catalog =trazabilidad;Integrated Security=false;uid=wtcdbo;pwd=.zmxnqp10";

        public static string CadenaConexion
        {
            get { return cadenaConexion; }
        }


    }
}
