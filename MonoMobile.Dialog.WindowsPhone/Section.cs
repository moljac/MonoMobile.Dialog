using System;
using System.Collections;
using System.Collections.Generic;

namespace MonoMobile.Dialog
{
	public partial class Section
		: 
		  Element
		, IEnumerable
		, IEnumerable<Element>	// // mc++ added
	{
		# region    IDisposable
		//-------------------------------------------------------------------------
		public void Dispose()
		{
			Dispose(true);
		}
		//-------------------------------------------------------------------------
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				Parent = null;
				Clear();
				Elements = null;
			}
			base.Dispose(disposing);
		}
		//-------------------------------------------------------------------------
		# endregion IDisposable

		# region    IEnumerable
		//-------------------------------------------------------------------------
		/// <summary>
		/// Enumerator to get all the elements in the Section.
		/// </summary>
		/// <returns>
		/// A <see cref="IEnumerator"/>
		/// </returns>
		public IEnumerator GetEnumerator()
		{
			foreach (var e in Elements)
				yield return e;
		}
		//-------------------------------------------------------------------------
		# region    mc++
		//-------------------------------------------------------------------------
		/// <summary>
		/// Enumerator to get all the elements in the Section.
		/// </summary>
		/// <returns></returns>
		/// A <see cref="IEnumerator{T}"/>
		IEnumerator<Element> IEnumerable<Element>.GetEnumerator()
		{
			foreach (var e in Elements)
				yield return e;
		}
		//-------------------------------------------------------------------------
		/// Enumerator to get all the elements in the Section.
		/// </summary>
		/// <returns>
		/// A <see cref="IEnumerator{T}"/>
		/// </returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			foreach (Element e in Elements)
				yield return e;
		}
		//-------------------------------------------------------------------------
		# endregion mc++
		# endregion IEnumerable

		# region    Properites
		//-------------------------------------------------------------------------
		public List<Element> Elements = new List<Element>();
		public List<Section> Sections = new List<Section>();
		//-------------------------------------------------------------------------
		/// <summary>
		/// The section footer, as a string.
		/// </summary>
		public string Footer
		{
			get
			{
				return footer as string;
			}

			set
			{
				footer = value;
			}
		}
		object footer;		// MT.D object footer!!!
		//-------------------------------------------------------------------------
		/// <summary>
		///    The section header, as a string
		/// </summary>
		public string Header
		{
			get
			{
				return header as string;
			}
			set
			{
				header = value;
			}
		}
		object header;		// MT.D object header!!!
		//-------------------------------------------------------------------------
		# endregion Properites

		# region    Constructors
		//-------------------------------------------------------------------------
		//-------------------------------------------------------------------------
		# endregion Constructors

		# region    Collection
		//-------------------------------------------------------------------------
		//-------------------------------------------------------------------------
		# endregion Collection
	
	}
}