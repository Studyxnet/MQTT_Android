using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using uPLibrary.Networking.M2Mqtt;
using System.Text;

namespace Mqtt_Forms.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init ();

			LoadApplication (new App ());

			return base.FinishedLaunching (app, options);
		}

		void Btn_Clicked (object sender, EventArgs e)
				{
					MqttClient client = new MqttClient ("iot.eclipse.org");
		
//					client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
		
					string clientId = Guid.NewGuid ().ToString ();
					client.Connect (clientId);
		
					var strValue = "*/relay?1";
		
					client.Publish ("globalcode/things", Encoding.UTF8.GetBytes (strValue));
				}
	}
}

