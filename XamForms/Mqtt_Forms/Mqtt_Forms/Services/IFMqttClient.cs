using System;
using Xamarin.Forms;

namespace Mqtt_Forms
{

	public class MyCustomEntry : Xamarin.Forms.View {
		
		public string MeuTexto {
			get;
			set;
		}

		public Color BGColor {
			get;
			set;
		}
	}

	public interface IFMqttClient
	{

		void Connect (string server);

		void Publish (string service, byte[] command);
	}
}

