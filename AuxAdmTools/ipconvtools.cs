using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;


namespace AuxAdmTools
{
    public class ipconvtools
    {
        public static object convertiptoint(string ip)
        {
            Int64 ipInteger = 0;
            try
            {
                ipInteger = (long)(uint)IPAddress.NetworkToHostOrder(BitConverter.ToInt32(IPAddress.Parse(ip).GetAddressBytes(), 0));
            }
            catch (Exception)
            {
            }
            return ipInteger;
        }
 
    }
}
