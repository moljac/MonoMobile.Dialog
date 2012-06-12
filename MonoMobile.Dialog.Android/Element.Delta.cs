using System;
using Android.Content;
using Android.Views;

using System.Collections;
using System.Collections.Generic;

namespace MonoMobile.Dialog
{
	public abstract partial class Element 
		:
		// mc++ Added from Miguel's MT.D
		IEnumerable, IEnumerable<Section>
	{
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
		}

		IEnumerator<Section> IEnumerable<Section>.GetEnumerator()
		{
			foreach (var s in Sections)
				yield return s;
		}
	}
}