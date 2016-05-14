using System;

using UIKit;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using System.Text;

namespace Mqqt_ios
{
	public partial class ViewController : UIViewController
	{
		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

		partial void UIButton3_TouchUpInside (UIButton sender)
		{

			MqttClient client = new MqttClient ("iot.eclipse.org");

			client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;

			string clientId = Guid.NewGuid ().ToString ();
			client.Connect (clientId);

			var strValue = "*/speaker?1";

			client.Publish ("globalcode/things", Encoding.UTF8.GetBytes (strValue));
		}

		void client_MqttMsgPublishReceived (object sender, MqttMsgPublishEventArgs e)
		{
			// handle message received
		}
	}
}

