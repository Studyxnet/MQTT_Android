using System;

using Xamarin.Forms;

//using uPLibrary.Networking.M2Mqtt;
//using uPLibrary.Networking.M2Mqtt.Messages;
using System.Text;

namespace Mqtt_Forms
{
	public class App : Application
	{
		
		public Entry cmdS {
			get;
			set;
		}

		public Entry cmdT {
			get;
			set;
		}

		public Entry cmdE {
			get;
			set;
		}

		public App ()
		{
			Button btn = new Button ();
			cmdE = new Entry ();
			cmdE.Placeholder = "Insira seu comando";

			cmdS = new Entry ();
			cmdS.Placeholder = "Insira o broker";

			cmdT = new Entry ();
			cmdT.Placeholder = "Insira o Topic";

			btn.Text = "Acionar MQTT";
			btn.Clicked += Btn_Clicked;
			// The root page of your application
			MainPage = new ContentPage {
				Content = new StackLayout {
					Padding = 20,
					VerticalOptions = LayoutOptions.Center,
					Children = {
						new Label {
							XAlign = TextAlignment.Center,
							Text = "Welcome to Xamarin Forms!"
						},
						cmdS,
						cmdT,
						cmdE,
						btn
					}
				}
			};
		}

		void Btn_Clicked (object sender, EventArgs e)
		{
			var client = DependencyService.Get<IFMqttClient> ();

			var strValue = cmdE.Text;

			client.Connect (cmdS.Text);
			if (!string.IsNullOrEmpty (strValue))
				client.Publish (cmdT.Text, Encoding.UTF8.GetBytes (strValue));

			var topics = new string[] { 
				Constants.GeneralTopic
			};

			foreach (var item in topics) {
				Xamarin.Forms.MessagingCenter.Subscribe<MqqtReceived> (this, item, (t) => myByteAction (t));
			}

			client.Subscribe (topics);
		}
		//
		//		void client_MqttMsgPublishReceived (object sender, MqttMsgPublishEventArgs e)
		//		{
		//			// handle message received
		//		}

		public void myByteAction (MqqtReceived ReceivedObject)
		{
			var msg = Encoding.UTF8.GetString (ReceivedObject.Message, 0, ReceivedObject.Message.Length);
			Device.BeginInvokeOnMainThread (() => {
				switch (ReceivedObject.Topic) {
				case Constants.GeneralTopic:
					//JsonConvert to Object
					var surf = Newtonsoft.Json.JsonConvert.DeserializeObject<Surfboard> (msg);
					System.Diagnostics.Debug.WriteLine (surf);
					break;
				default:
					System.Diagnostics.Debug.WriteLine ("Mensagem recebida da IoT: " + msg);	
					break;
				}


			});

		}

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

