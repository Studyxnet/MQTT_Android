using System;

using Xamarin.Forms;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using System.Text;

namespace Mqtt_Forms
{
	public class App : Application
	{
		public App ()
		{
			Button btn = new Button ();
			btn.Text = "Acionar MQTT";
//			btn.Clicked += Btn_Clicked;
			// The root page of your application
			MainPage = new ContentPage {
				Content = new StackLayout {
					VerticalOptions = LayoutOptions.Center,
					Children = {
						new Label {
							XAlign = TextAlignment.Center,
							Text = "Welcome to Xamarin Forms!"
						}
						, btn
					}
				}
			};
		}

//		void Btn_Clicked (object sender, EventArgs e)
//		{
//			MqttClient client = new MqttClient ("iot.eclipse.org");
//
//			client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
//
//			string clientId = Guid.NewGuid ().ToString ();
//			client.Connect (clientId);
//
//			var strValue = "*/relay?1";
//
//			client.Publish ("globalcode/things", Encoding.UTF8.GetBytes (strValue));
//		}
//
//		void client_MqttMsgPublishReceived (object sender, MqttMsgPublishEventArgs e)
//		{
//			// handle message received
//		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

