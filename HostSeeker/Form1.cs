using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.ConstrainedExecution;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using System.Linq;



namespace HostSeeker
{
    public partial class Form1 : Form
    {
        private List<object> m_lLocalIP;
        private List<CHost> m_lHostList;
        private List<object> m_lThreadList;
        private PrinterSettings m_cPrtSet;
        private PrintDialog m_cPDialog;
        private PrintDocument m_cPDocument;
        private PrintPreviewDialog m_cPPreview;
        private int m_iStartSeite;
        private int m_iAnzahlSeiten;
        private int m_iSeitenNummer;
        private static int m_iMinIPSup = 1;
        private static int m_iMaxIPSup = 254;
        private string m_sPrintHost;
        private string m_sPrintTime;

        public Form1()
        {
            InitializeComponent();
            progressBar1.Maximum = m_iMaxIPSup;
            progressBar1.Step = m_iMinIPSup;
            m_lLocalIP = new List<object>();
            m_lHostList = new List<CHost>();
            m_lThreadList = new List<object>();
            m_cPrtSet = new PrinterSettings();
            m_cPDialog = new PrintDialog();
            m_cPDocument = new PrintDocument();
            m_cPPreview = new PrintPreviewDialog();

            GetLocalNetworkInterface();

            m_cPDocument.DocumentName = "HostSeeker List";
            m_cPDocument.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);
        }

        //Einholen der Netzwar Adappter
        private void GetLocalNetworkInterface()
        {
            NetworkInterface[] MyInterfaces = NetworkInterface.GetAllNetworkInterfaces();

            cbInterface.Items.Add("<Choose Network Interface>");
            cbInterface.SelectedIndex = 0;

            foreach (NetworkInterface Networkcards in MyInterfaces)
            {
                IPInterfaceProperties adapterProperties = Networkcards.GetIPProperties();
                UnicastIPAddressInformationCollection anyCast = adapterProperties.UnicastAddresses;
                if (anyCast.Count > 0)
                {
                    foreach (IPAddressInformation any in anyCast)
                    {
                        if (any.Address.AddressFamily.ToString() == AddressFamily.InterNetwork.ToString())
                        {
                            cbInterface.Items.Add(Networkcards.Name);
                            m_lLocalIP.Add(any);

                            break;
                        }
                    }
                }
            }

        }

        // Einholen der Localen IP Adresse
        private void GetLocalIP_Click(object oSender, EventArgs cEv)
        {
            try
            {
                String sIP = string.Empty;
                int iPos1 = 0;
                int iPos2 = 0;
                int iPos3 = 0;

                sIP = ((IPAddressInformation)m_lLocalIP[cbInterface.SelectedIndex - 1]).Address.ToString();

                iPos1 = sIP.IndexOf(".");
                Sub1.Text = sIP.Substring(0, iPos1);
                Sub1.Update();

                iPos2 = sIP.IndexOf(".", iPos1 + 1);
                Sub2.Text = sIP.Substring(iPos1 + 1, iPos2 - iPos1 - 1);
                Sub2.Update();

                iPos3 = sIP.IndexOf(".", iPos2 + 1);
                Sub3.Text = sIP.Substring(iPos2 + 1, iPos3 - iPos2 - 1);
                Sub3.Update();

                if (CheckSubnetIP())
                    btnStartSeek.Enabled = true;
                else
                    btnStartSeek.Enabled = false;
            }
            catch
            {
                btnStartSeek.Enabled = false;
                MessageBox.Show("Failed to get local IP subnet", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void interfaceBox_SelectedIndexChanged(object oSender, EventArgs cEv)
        {
            btnStartSeek.Enabled = false;
            btnHostList.Enabled = false;

            if (cbInterface.SelectedIndex > 0)
            {
                btnGetLocalIP.Enabled = true;
            }
            else
            {
                btnGetLocalIP.Enabled = false;
            }
        }

        // Starten der Suche
        private void StartSeek_Click(object oSender, EventArgs cEv)
        {
            // Einlesen der Class C IP
            String sIP = Sub1.Text + "." + Sub2.Text + "." + Sub3.Text + ".";
            int iThreadRun = 0;
            int iNewProgrValue;
            bool bRunnFlag;

			this.Cursor = Cursors.WaitCursor;

			bsHost.Clear();

			hostEntry.Items.Clear();
			hostEntry.Refresh();

			progressBar1.Visible = true;
			progressBar1.Value = 0;
			m_lHostList.Clear();
			m_lThreadList.Clear();
			btnHostList.Enabled = false;

			// Iteration durch den IP Adressenbereich
			for (int i = m_iMinIPSup; i <= m_iMaxIPSup; i++)
			{
				// statusbar schreiben
				statusBarLabel1.Text = "Send Ping: " + sIP + i;
				statusBar.Refresh();

				// Ping Klasse instanz erzeugen
				CHostPing cHostPing = new CHostPing(sIP, i, m_lHostList);

				// Thread erzeugen
				Thread pingThread = new Thread(new ThreadStart(cHostPing.SendPing));

				// Thread starten
				pingThread.Start();

				// Thread an Liste Anhängen
				m_lThreadList.Add(pingThread);

				// Progressbar schreiben
				progressBar1.PerformStep();
			}

			// Progressbar neu aufbauen
			progressBar1.Maximum = m_lThreadList.Count;
			progressBar1.Value = 0;

			// Statusbar neu schreiben
			statusBarLabel1.Text = "Replies left to finish";
			statusBar.Refresh();

			// Prüfung ob alle Threads beendet wurden
			while (true)
			{
				bRunnFlag = false;
				iThreadRun = 0;

				// Iteration durch Treasliste...
				foreach (Thread pingThread in m_lThreadList)
				{
					// ... wen Thread noch läuft...
					if (pingThread.ThreadState == ThreadState.Running)
					{
						// .. flag setzen...
						bRunnFlag = true;
						iThreadRun++;
					}
				}

				// Progressbar schreiben
				if (iThreadRun == 0)
				{
					iNewProgrValue = progressBar1.Maximum;
				}
				else
				{
					iNewProgrValue = progressBar1.Maximum / iThreadRun;
				}

				if (iNewProgrValue > progressBar1.Maximum)
				{
					progressBar1.Value = progressBar1.Maximum;
				}
				else
				{
					progressBar1.Value = iNewProgrValue;
				}

				// ... wenn kein Thred mehr aktiv dann Prüfung beenden
				if (!bRunnFlag)
				{
					break;
				}
			}

			// Iteration durch Adressbereich...
			foreach (CHost cHost in m_lHostList.OrderBy(ch => ch.getSuf()))
			{
				// ... wenn SubnetAdresse stimmt
				var pHost = new PresentationHost
				{
					Host = cHost
				};

				bsHost.Add(pHost);
			}

			if (dgvHostTable.Rows.Count > 0)
				btnHostList.Enabled = true;

			progressBar1.Visible = false;
			statusBarLabel1.Text = "Finished and " + dgvHostTable.Rows.Count.ToString() + " Hosts found on this Subnet";
			statusBar.Refresh();

			this.Cursor = Cursors.Default;
		}

		// Adresse prüfen ob plausibel ist
		private bool CheckSubnetIP()
        {
            try
            {
                int iSub1 = Convert.ToInt32(Sub1.Text);
                int iSub2 = Convert.ToInt32(Sub2.Text);
                int iSub3 = Convert.ToInt32(Sub3.Text);

                if (iSub1 < 0 || iSub1 > 255)
					return false;
				if (iSub2 < 0 || iSub2 > 255)
					return false;
				if (iSub3 < 0 || iSub3 > 255)
					return false;
			}
			catch
            {
                return false;
            }

            return true;
        }

        // AboutBox anzeigen
        private void ShowAbout_Click(object oSender, EventArgs cEv)
        {
            new About().ShowDialog();
        }

        // Host Liste drucken
        private void hostList_Click(object oSender, EventArgs cEv)
        {
            m_cPDialog.Document = m_cPDocument;
            m_cPDialog.AllowSelection = true;

            if (m_cPDialog.ShowDialog() == DialogResult.OK)
            {
                m_sPrintTime = DateTime.Now.ToLongTimeString();
                m_cPDocument = m_cPDialog.Document;

                m_iStartSeite = 1;
                m_iAnzahlSeiten = m_cPrtSet.MaximumPage;
                m_iSeitenNummer = 1;

                switch (m_cPDialog.PrinterSettings.PrintRange)
                {
                    case PrintRange.AllPages:
                        m_sPrintHost = hostList4Print(false);
                        break;

                    case PrintRange.Selection:
                        m_sPrintHost = hostList4Print(true);
                        break;
                }

                m_cPDocument.Print();
            }
        }

        private string hostList4Print(bool bSelection)
        {
            string sPrintHost = string.Empty;

            if (bSelection)
            {
                // Iterate through the SelectedCells collection and sum up the values.
                for (int iTablePos = 0; iTablePos < (dgvHostTable.Rows.Count); iTablePos++)
                {
                    if ((dgvHostTable.Rows[iTablePos].Cells[0].Selected) || (dgvHostTable.Rows[iTablePos].Cells[1].Selected))
                    {
                        // Iteration durch Adressliste
                        foreach (CHost cHost in m_lHostList)
                        {
                            if (cHost.getAdress().CompareTo(dgvHostTable.Rows[iTablePos].Cells[0].Value.ToString()) == 0)
                            {
                                // IP Adresse in Hostliste eintragen...
                                sPrintHost += cHost.getAdress();

                                // ... prüfen ob auch ein Host Eintrag existiert...
                                if (cHost.getHostName().Length > 0)
                                {
                                    // ... als neuen Knoten eintragen
                                    sPrintHost += ": " + cHost.getHostName();
                                }

                                sPrintHost += "\n";

                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                // Iterate through the SelectedCells collection and sum up the values.
                for (int iTablePos = 0; iTablePos < (dgvHostTable.Rows.Count); iTablePos++)
                {
                    // Iteration durch Adressliste
                    foreach (CHost cHost in m_lHostList)
                    {
                        // ... wenn SubnetAdresse stimmt
                        if (cHost.getAdress().CompareTo(dgvHostTable.Rows[iTablePos].Cells[0].Value.ToString()) == 0)
                        {
                            // IP Adresse in Hostliste eintragen...
                            sPrintHost += cHost.getAdress();

                            // ... prüfen ob auch ein Host Eintrag existiert...
                            if (cHost.getHostName().Length > 0)
                            {
                                // ... als neuen Knoten eintragen
                                sPrintHost += ": " + cHost.getHostName();
                            }

                            sPrintHost += "\n";

                            break;
                        }
                    }
                }
            }

            return sPrintHost;
        }

        // The PrintPage event is raised for each page to be printed.
        private void pd_PrintPage(object oSender, PrintPageEventArgs cEv)
        {
            StringFormat stringFormat = new StringFormat();
            RectangleF rectFPapier, rectFText;
            int intChars, intLines;
            // Anzahl der Druckseiten
            System.Drawing.Font printFont = new System.Drawing.Font("Arial", 10);

            // Ermitteln des Rectangles, das den gesamten Druckbereich
            // beschreibt (inklusive Kopf- und Fusszeile)
            rectFPapier = cEv.MarginBounds;

            // Ermitteln des Rectangles, das den Bereich für den
            // Text beschreibt (ausschließlich Kopf- und Fusszeile)
            rectFText = RectangleF.Inflate(rectFPapier, 0, -2 * printFont.GetHeight(cEv.Graphics));

            // eine gerade Anzahl von Druckzeilen ermitteln
            int anzahlZeilen = (int)Math.Floor(rectFText.Height / printFont.GetHeight(cEv.Graphics));

            // die Höhe die textbeinhaltenden Rechtecks festlegen, damit die
            // letzte Druckzeile nicht abgeschnitten wird
            rectFText.Height = anzahlZeilen * printFont.GetHeight(cEv.Graphics);

            // das StringFormat-Objekt festlegen, um den Text in einem Rechteck
            // anzuzeigen - Text bis zum nächstliegenden Wort verkürzen
            stringFormat.Trimming = StringTrimming.Word;

            //	legt die Druckstartseite fest, wenn es sich nicht um die
            // erste Dokumentenseite handelt
            while ((m_iSeitenNummer < m_iStartSeite) && (m_sPrintHost.Length > 0))
            {
                cEv.Graphics.MeasureString(m_sPrintHost, printFont, rectFText.Size, stringFormat, out intChars, out intLines);
                m_sPrintHost = m_sPrintHost.Substring(intChars);
                m_iSeitenNummer++;
            }

            // Druckjob beenden, wenn es keinen Text zum Drucken mehr gibt
            if (m_sPrintHost.Length == 0)
            {
                cEv.Cancel = true;
                return;
            }

            // den Text an das Graphics-Objekt übergeben
            cEv.Graphics.DrawString(m_sPrintHost, printFont, Brushes.Black, rectFText, stringFormat);

            // Text für die nächste Seite
            // intChars - Anzahl der Zeichen in der Zeichenfolge
            // intLines - Anzahl der Zeilen in der Zeichenfolge
            cEv.Graphics.MeasureString(m_sPrintHost, printFont, rectFText.Size, stringFormat, out intChars, out intLines);
            m_sPrintHost = m_sPrintHost.Substring(intChars);

            // StringFormat restaurieren
            stringFormat = new StringFormat();

            // Dateiname in der Kopfzeile anzeigen
            stringFormat.Alignment = StringAlignment.Center;
            cEv.Graphics.DrawString("HostSeeker v1 Host list printed at " + m_sPrintTime, printFont, Brushes.Black, rectFPapier, stringFormat);

            // Seitennummer in der Fusszeile anzeigen
            stringFormat.LineAlignment = StringAlignment.Far;
            cEv.Graphics.DrawString("Page " + m_iSeitenNummer, printFont, Brushes.Black, rectFPapier, stringFormat);

            // ermitteln, ob weitere Seiten zu drucken sind
            m_iSeitenNummer++;
            cEv.HasMorePages = (m_sPrintHost.Length > 0) && (m_iSeitenNummer < m_iStartSeite + m_iAnzahlSeiten);

            // Neuinitialisierung
            if (!cEv.HasMorePages)
            {
                m_iStartSeite = 1;
                m_iSeitenNummer = 1;
                m_iAnzahlSeiten = m_cPrtSet.MaximumPage;
            }
        }

        private void dgvHostTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dgvHostTable.Rows[e.RowIndex].DataBoundItem is PresentationHost pHost)
                {
                    var cHost = pHost.Host;

                    hostEntry.Items.Clear();

                    hostEntry.Items.Add("IP Address:\t\t\t" + cHost.getAdress());
                    hostEntry.Items.Add("Host Name:\t\t\t" + cHost.getHostName());
                    hostEntry.Items.Add("");
                    hostEntry.Items.Add("Ping result:");
                    hostEntry.Items.Add("Roundtrip time:\t\t\t" + cHost.getRoundtripTime());
                    hostEntry.Items.Add("Time to live:\t\t\t" + cHost.getTtl());
                    hostEntry.Items.Add("Don't fragment:\t\t\t" + cHost.getDontFragment());
                    hostEntry.Items.Add("Buffer size:\t\t\t" + cHost.getLength());
                }
            }
        }
    }
}