using Android.App;
using Android.Widget;
using Android.OS;
using uPLibrary.Networking.M2Mqtt;
using System.Net;
using System;
using uPLibrary.Networking.M2Mqtt.Messages;
using System.Text;

namespace TesteMQTT
{
	[Activity (Label = "TesteMQTT", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);
			
			button.Click += delegate {

				MqttClient client = new MqttClient("iot.eclipse.org");

				client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;

				string clientId = Guid.NewGuid().ToString();
				client.Connect(clientId);

				var strValue = "*/relay?1";

				client.Publish("globalcode/things", Encoding.UTF8.GetBytes(strValue), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE);
			};
		}

		 void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
		{
			// handle message received
		}
	}
}


