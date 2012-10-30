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
	/// <summary>
	/// TODO: Move this to new class to have better API interface
	/// </summary>
	public partial class Element
	{

		public delegate void ElementTraversingDelegatePrototype(Element e);
		public event ElementTraversingDelegatePrototype ElementTraversingDelegate;

		public virtual void Traverse(Element e)
		{
			// Execute delegate if defined
			if (null != e.ElementTraversingDelegate)
			{
				e.ElementTraversingDelegate(e);
			}

			// Dive deeper 01
			RootElement re = e as RootElement;

			if (null != re)
			{
				foreach (Section s in re.Sections)
				{
					// Set  delegate
					s.ElementTraversingDelegate += e.ElementTraversingDelegate;
					// Dive in (execute delegate and dive)
					s.Traverse(s);
				}
			}

			// Dive deeper 02
			Section section = this as Section;

			if (null != section)
			{
				foreach (Element element in section.Elements)
				{
					// Set  delegate
					element.ElementTraversingDelegate += section.ElementTraversingDelegate;
					// Dive in (execute delegate and dive)
					element.Traverse(element);
				}
			}

			return;
		}
	}
}