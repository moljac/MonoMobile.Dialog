using System;
using System.Collections.Generic;
using System.Text;


/*

http://www.raspbian.org/
http://www.raspberrypi.org/
http://twitter.com/praeclarum
http://praeclarum.org/
https://speakerdeck.com/chrisntr/cross-platform-mobile-applications-with-c-and-net-miracle-open-world-2012
 
 
 */
namespace MonoMobile.Dialog
{
	public partial class Element
	{
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder("Element-");
			sb.Append("Type=");
			sb.Append((this.GetType().ToString()));
			sb.Append(base.ToString());

			return sb.ToString();
		}

	}
}