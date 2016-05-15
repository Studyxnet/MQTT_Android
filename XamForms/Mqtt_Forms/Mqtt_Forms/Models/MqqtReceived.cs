using System;

namespace Mqtt_Forms
{
	public class MqqtReceived
	{
		public MqqtReceived ()
		{
		}

		public byte[] Message {
			get;
			set;
		}

		public string Topic {
			get;
			set;
		}

		public string Broker {
			get;
			set;
		}
	}
}

