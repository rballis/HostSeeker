using System;
using System.Collections.Generic;
using System.Text;

namespace HostSeeker
{
    // Host Klasse
    class CHost
    {
        private int m_iSuf;
        private String m_sAdress = string.Empty;
        private String m_sRoundtripTime = string.Empty;
        private String m_sTtl = string.Empty;
        private String m_sDontFragment = string.Empty;
        private String m_sLength = string.Empty;
        private String m_sHostName = string.Empty;

        // Host Klasse mit Atribute
        public CHost(int iSuf, String sAdress, String sRoundtripTime, String sTtl, String sDontFragment, String sLength, String sHostName)
        {
            m_iSuf = iSuf;
            m_sAdress = sAdress;
            m_sRoundtripTime = sRoundtripTime;
            m_sTtl = sTtl;
            m_sDontFragment = sDontFragment;
            m_sLength = sLength;
            m_sHostName = sHostName;
        }

        // Sufix zurückgeben
        public int getSuf()
        {
            return m_iSuf;
        }

        // Komplette IP Adresse zurückgeben
        public string getAdress()
        {
            return m_sAdress;
        }

        // Pingzeit zurückgeben
        public string getRoundtripTime()
        {
            return m_sRoundtripTime;
        }

        // Time to live zurückgeben
        public string getTtl()
        {
            return m_sTtl;
        }

        // Dont Fragment zurückgeben
        public string getDontFragment()
        {
            return m_sDontFragment;
        }

        // Länge zurückgeben
        public string getLength()
        {
            return m_sLength;
        }

        // Host Name zurückgeben
        public String getHostName()
        {
            return m_sHostName;
        }
    }
}
