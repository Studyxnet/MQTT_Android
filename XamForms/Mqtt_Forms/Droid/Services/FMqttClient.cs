using System;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using Mqtt_Forms.Droid;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Android.Widget;
using System.Linq;

[assembly: Xamarin.Forms.Dependency (typeof(FMqttClient))]
namespace Mqtt_Forms.Droid
{
	public class FMqttClient : IFMqttClient
	{
		public MqttClient client {
			get;
			set;
		}


		public string Broker {
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



				string clientId = Guid.NewGuid ().ToString ();
				client.Connect (clientId);	

				Broker = server;

			} catch (Exception ex) {
				throw new Exception (ex.Message);
			}

		}

		void client_MqttMsgPublishReceived (object sender, MqttMsgPublishEventArgs e)
		{
			if (e.Message.Any ()) {

				var receive = new MqqtReceived () {
					Broker = Broker,
					Topic = e.Topic,
					Message = e.Message
				};

				Xamarin.Forms.MessagingCenter.Send<MqqtReceived> (receive, e.Topic);
			}
		}

		public void Publish (string service, byte[] command)
		{
			client.Publish (service, command);
		}


		public void Subscribe (string[] topics)
		{
			client.Subscribe (topics,
				new byte[] { 
					MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE 
				});


			client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
			client.MqttMsgSubscribed += Client_MqttMsgSubscribed;
			client.MqttMsgUnsubscribed += Client_MqttMsgUnsubscribed;
			client.MqttMsgPublished += Client_MqttMsgPublished;
		}

		void Client_MqttMsgPublished (object sender, MqttMsgPublishedEventArgs e)
		{

		}

		void Client_MqttMsgUnsubscribed (object sender, MqttMsgUnsubscribedEventArgs e)
		{

		}

		void Client_MqttMsgSubscribed (object sender, MqttMsgSubscribedEventArgs e)
		{

		}

		#endregion
	}
}

