using System;
using System.Collections.Generic;

namespace Mqtt_Forms
{
	public class Component
	{
		public string Name {
			get;
			set;
		}

		public string Value {
			get;
			set;
		}
	}

	public class Surfboard
	{
		public string Name {
			get;
			set;
		}

		public string Firmware {
			get;
			set;
		}

		public string Serial {
			get;
			set;
		}

		public string Key {
			get;
			set;
		}

		public List<Component> Components {
			get;
			set;
		}
	}
}

