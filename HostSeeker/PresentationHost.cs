using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HostSeeker
{
	internal class PresentationHost
	{
		public CHost Host { get; set; }

		public string IP
		{
			get { return Host.getAdress(); }
		}

		public string HostName
		{
			get { return Host.getHostName(); }
		}
	}
}
