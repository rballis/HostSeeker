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

        // Sufix zur�ckgeben
        public int getSuf()
        {
            return m_iSuf;
        }

        // Komplette IP Adresse zur�ckgeben
        public string getAdress()
        {
            return m_sAdress;
        }

        // Pingzeit zur�ckgeben
        public string getRoundtripTime()
        {
            return m_sRoundtripTime;
        }

        // Time to live zur�ckgeben
        public string getTtl()
        {
            return m_sTtl;
        }

        // Dont Fragment zur�ckgeben
        public string getDontFragment()
        {
            return m_sDontFragment;
        }

        // L�nge zur�ckgeben
        public string getLength()
        {
            return m_sLength;
        }

        // Host Name zur�ckgeben
        public String getHostName()
        {
            return m_sHostName;
        }
    }
}
