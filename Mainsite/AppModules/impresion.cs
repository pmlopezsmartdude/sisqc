using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Sockets;
using System.Web.Security;
using System.Security.Cryptography;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;

namespace Mainsite.AppModules
{
    public class impresion
    {
        public static object imprimebixolon(string ip, int puerto, string fruit, string fruto, string variedad, string calibre, string dark, string cat, string peso, string codigoenvase, string lote, string numproceso, string fechaembalaje, string sdp, string codigoproductor, string region, string provincia, string comuna, string cse, string exportador, string csp, string packing, string salida, string turnos, string codigobarras)
        {
            try
            {
                IPAddress addres = IPAddress.Parse(ip);
                int iportno = System.Convert.ToInt16(puerto);
                EndPoint ep = new IPEndPoint(addres, iportno);
                Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                sock.Connect(ep);
                NetworkStream ns = new NetworkStream(sock);
                string impresionslcs = "CB\r\n" + "SM0,0\r\n" + "SS3\r\n" + "SW530\r\n" + "STd\r\n" + "SOT\r\n" + "SD20\r\n" + "SL400,28,G\r\n" + "T53,15,2,0,1,0,0,N,B,'" + fruit + "/" + fruto +
                    "'\r\n" + "T53,45,2,0,2,0,0,N,B,'" + variedad + "'\r\n" + "T317,18,4,2,2,0,0," + dark + ",N,'" + calibre + "'\r\n" + "T310,100,2,2,1,0,0,N,N,'" + cat + "'\r\n" +
                    "T53,92,1,0,0,0,0,N,N,'Net Wt: Kg. Neto'\r\n" + "T53,105,2,1,2,0,0,N,N,'" + peso + "'\r\n" + "T160,105,2,1,2,0,0,N,B,'" + codigoenvase + "'\r\n" +
                    "T311,127,1,0,0,0,0,N,N,'Lote  :" + lote + "'\r\n" + "T311,147,1,0,0,0,0,N,N,'Prc.No:" + numproceso + "'\r\n" + "T311,167,1,0,0,0,0,N,N,'Date/Fecha:'\r\n" +
                    "T311,184,1,0,2,0,0,N,N,'" + fechaembalaje + "'\r\n" + "T311,230,1,0,2,0,0,N,N,'SDP:" + sdp + "'\r\n" + "BD309,14,470,232,B,2\r\n" + "T53,153,0,0,2,0,0,N,B,'Grower/Productor/CSG:'\r\n" +
                    "T205,176,2,1,2,0,0,N,B,'" + codigoproductor + "'\r\n" + "T53,194,1,0,0,0,0,N,N,'REGION: '\r\n" + "T144,194,1,0,0,0,0,N,N,'" + region + "'\r\n" +
                    "T53,224,1,0,0,0,0,N,N,'PROV:'\r\n" + "T112,218,0,0,2,0,0,N,N,'" + provincia + "'\r\n" + "T53,255,1,0,0,0,0,N,N,'COM:'\r\n" + "T112,249,0,0,2,0,0,N,N,'" +
                    comuna + "'\r\n" + "T472,395,0,0,0,0,3,N,N,'PRODUCT OF CHILE/PRODUCTO'\r\n" + "T472,168,0,0,0,0,3,N,N,'DE'\r\n" + "T472,148,0,0,0,0,3,N,N,'CHILE'\r\n" +
                    "T472,98,0,0,0,0,3,N,N,'CSE:" + cse + "'\r\n" + "T485,395,0,0,0,0,3,N,B,F,'Export by:" + exportador + "'\r\n" + "T22,370,0,0,0,0,3,N,N,F,'Packing by/Embalado por/CSP: " + csp + "'\r\n" +
                    "T37,370,0,1,1,0,3,N,N,'" + packing + "'\r\n" + "T53,390,2,1,1,0,3,N,N,'" + salida + "'\r\n" + "T446,380,2,1,1,0,3,N,N,'" + turnos + "'\r\n" + "B190,305,1,3,300,100,0,0,'" + codigobarras + "'\r\n" +
                    "T130,280,2,1,1,0,0,N,N,'(21)" + codigobarras + "'\r\n" + "P1\r\n";
                byte[] toSend = Encoding.ASCII.GetBytes(impresionslcs);
                ns.Write(toSend, 0, toSend.Length);
                sock.Close();

            }
            catch (SystemException ex)
            {
                
                string error = "error:" + ex + "de impresion";
                return error;
            }
            finally
            {
               
            }
            return "0";

        }

 
    }
}