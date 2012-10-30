using System;
using System.Collections;
using System.Collections.Generic;

namespace MonoMobile.Dialog
{
	/// <summary>
	///    RootElements are responsible for showing a full configuration page.
	/// </summary>
	/// <remarks>
	///    At least one RootElement is required to start the MonoTouch.Dialogs
	///    process.   
	/// 
	///    RootElements can also be used inside Sections to trigger
	///    loading a new nested configuration page.   When used in this mode
	///    the caption provided is used while rendered inside a section and
	///    is also used as the Title for the subpage.
	/// 
	///    If a RootElement is initialized with a section/element value then
	///    this value is used to locate a child Element that will provide
	///    a summary of the configuration which is rendered on the right-side
	///    of the display.
	/// 
	///    RootElements are also used to coordinate radio elements.  The
	///    RadioElement members can span multiple Sections (for example to
	///    implement something similar to the ring tone selector and separate
	///    custom ring tones from system ringtones).
	/// 
	///    Sections are added by calling the Add method which supports the
	///    C# 4.0 syntax to initialize a RootElement in one pass.
	/// </remarks>
	public partial class RootElement
		: Element, IEnumerable, IEnumerable<Section>
	{
		internal Group group;
		public bool UnevenRows;

		int summarySection;
		int summaryElement;

		internal List<Section> Sections = new List<Section>();



		/// <summary>
		/// Enumerator that returns all the sections in the RootElement.
		/// </summary>
		/// <returns>
		/// A <see cref="IEnumerator"/>
		/// </returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			foreach (var s in Sections)
				yield return s;

			// MA.D
			// return Sections.GetEnumerator();
		}

		/// <summary>
		/// Enumerator that returns all the sections in the RootElement.
		/// </summary>
		/// <returns>
		/// A <see cref="IEnumerator"/>
		/// </returns>
		IEnumerator<Section> IEnumerable<Section>.GetEnumerator()
		{
			foreach (var s in Sections)
				yield return s;

			// MA.D 			
			// return Sections.GetEnumerator();

		}

	}
}