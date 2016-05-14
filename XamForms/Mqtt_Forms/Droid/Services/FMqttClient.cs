using System;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using Mqtt_Forms.Droid;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Android.Widget;

[assembly: Xamarin.Forms.Dependency (typeof(FMqttClient))]
namespace Mqtt_Forms.Droid
{
	public class myrend : ViewRenderer<MyCustomEntry,TextView>
	{
		public myrend ()
		{
				
		}	

		protected override void OnElementChanged (ElementChangedEventArgs<MyCustomEntry> e)
		{
			base.OnElementChanged (e);

			var txv = new TextView (Xamarin.Forms.Forms.Context);
			txv.Text = Element.MeuTexto;
			txv.SetBackgroundColor (Element.BGColor.ToAndroid ());


		}

	}

	public class FMqttClient : IFMqttClient
	{
		public MqttClient client {
			get;
			set;
		}

		public FMqttClient ()
		{
		}

		#region IFMqttClient implementation

		public void Connect (string server)
		{
			client = new MqttClient (server);

			client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;

			string clientId = Guid.NewGuid ().ToString ();
			client.Connect (clientId);
		}

		void client_MqttMsgPublishReceived (object sender, MqttMsgPublishEventArgs e)
		{
			// handle message received
		}

		public void Publish (string service, byte[] command)
		{
			client.Publish (service, command);
		}

		#endregion
	}
}

