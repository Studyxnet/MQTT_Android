using System;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using Mqtt_Forms.iOS;

[assembly: Xamarin.Forms.Dependency (typeof(FMqttClient))]
namespace Mqtt_Forms.iOS
{
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
			try {

				client = new MqttClient (server);

				client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;

				string clientId = Guid.NewGuid ().ToString ();
				client.Connect (clientId);


			}//catch(uPLibrary.Exception.ser
			catch (Exception ex) {
				throw new Exception (ex.Message);
			}
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

