using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.NetworkInformation;

namespace HostSeeker
{
    // Ping Klasse
    class CHostPing
    {
        private String m_sIp = string.Empty;
        private int m_iSuf;
        private List<CHost> m_lHostList;

        public CHostPing(String sIp, int iSuf, List<CHost> lHostList)
        {
            m_sIp = sIp;
            m_iSuf = iSuf;
            m_lHostList = lHostList;
        }

        // senden von Ping
        public void SendPing()
        {
            Ping pingSender;
            PingOptions pingOptions;

            try
            {
                // Ping und PingOptions Klasse Instanz erzeugen
                if ((pingSender = new Ping()) != null && (pingOptions = new PingOptions()) != null)
                {
                    // Create a buffer of 32 bytes of data to be transmitted.
                    string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                    byte[] buffer = Encoding.ASCII.GetBytes(data);

                    // Use the default Ttl value which is 128,
                    // but change the fragmentation behavior.
                    pingOptions.DontFragment = true;

                    // Ping senden...
                    PingReply reply = pingSender.Send(m_sIp + m_iSuf, 120, buffer, pingOptions);

                    // ... wenn etwas zurück kommt
                    if (reply.Status == IPStatus.Success)
                    {
                        // Host Klasse Instanz erzeugen mit Daten
                        CHost cHost = new CHost(m_iSuf,
                            reply.Address.ToString(),
                            reply.RoundtripTime.ToString(),
                            reply.Options.Ttl.ToString(),
                            reply.Options.DontFragment.ToString(),
                            reply.Buffer.Length.ToString(),
                            resolveHostName(m_sIp + m_iSuf));

                        // An Hostliste anfügen
                        m_lHostList.Add(cHost);
                    }
                }
            }
            catch
            {
                return;
            }
        }

        // Host auflösen
        private string resolveHostName(String sIp)
        {
            try
            {
                // Host auflösen
                IPHostEntry host = Dns.GetHostByAddress(sIp);

                // Host Namen zurückgeben
                return host.HostName;
            }
            catch
            {
                // Host nicht verfügbar, nichts zurückgeben
                return "";
            }
        }
    }
}
