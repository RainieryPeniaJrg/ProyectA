using System.Net.Sockets;
using System.Net;

namespace BE_ProyectoA.Persistence.Identity.Helpers
{
    public class IpHelper
    {
        public static string GetIpAdress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return string.Empty;
        }
    }
}
