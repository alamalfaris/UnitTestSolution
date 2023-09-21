using NetworkUtility.Dns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace NetworkUtility.Ping
{
    public class NetworkService
    {
        private readonly IDns _dns;

        public NetworkService(IDns dns)
        {
            _dns = dns;
        }

        public string SendPing()
        {
            var dnsSuccess = _dns.SendDns();
            if (dnsSuccess)
            {
                return "Success: Ping sent";
            }
            else
            {
                return "Failed: Ping sent";
            }
        }

        public int PingTimeout(int a, int b)
        {
            return a + b;
        }

        public DateTime LastPingSent()
        {
            return DateTime.Now;
        }

        public PingOptions GetPingOptions()
        {
            return new PingOptions()
            {
                DontFragment = true,
                Ttl = 1
            };
        }

        public IEnumerable<PingOptions> MostRecentPings()
        {
            IEnumerable<PingOptions> pingOptions = new[]
            {
                new PingOptions() { DontFragment = true, Ttl = 1 },
                new PingOptions() { DontFragment = true, Ttl = 1 },
                new PingOptions() { DontFragment = true, Ttl = 1 },
            };
            return pingOptions;
        }
    }
}
