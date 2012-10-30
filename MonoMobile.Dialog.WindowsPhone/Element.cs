using System;

namespace MonoMobile.Dialog
{
	public abstract partial class Element
	{
		/// <summary>
		///  The caption to display for this given element
		/// </summary>
		public string Caption { get; set; }

		/// <summary>
		///  Handle to the container object.
		/// </summary>
		/// <remarks>
		/// For sections this points to a RootElement, for every other object this 
		/// points to a Section and it is null for the re RootElement.
		/// </remarks>
		public Element Parent { get; set; }

		/// <summary>
		/// An Object that contains data about the element. The default is null.
		/// 
		/// Note mc++: Available in MA.D not in original MT.D
		/// </summary>
		public Object Tag { get; set; }

		
		# region    Region
		//-------------------------------------------------------------------------
		public Element ()
		{
			return;
		}
		//-------------------------------------------------------------------------
		/// <summary>
		///  Initializes the element with the given caption.
		/// </summary>
		/// <param name="caption">
		/// The caption.
		/// </param>
		public Element(string caption)
		{
			Caption = caption;
		}
		//-------------------------------------------------------------------------
		# endregion Region
	

		public void Dispose()
		{
			Dispose(true);
		}

		protected virtual void Dispose(bool disposing)
		{
		}


		/// <summary>
		/// Returns a summary of the value represented by this object, suitable 
		/// for rendering as the result of a RootElement with child objects.
		/// </summary>
		/// <returns>
		/// The return value must be a short description of the value.
		/// </returns>
		public virtual string Summary()
		{
			return string.Empty;
		}

		/// <summary>
		///   Method invoked to determine if the cell matches the given text, never 
		///   invoked with a null value or an empty string.
		/// </summary>
		public virtual bool Matches(string text)
		{
			if (Caption == null)
				return false;
			return Caption.IndexOf(text, StringComparison.CurrentCultureIgnoreCase) != -1;

			/* 
			 * MA.D
			return Caption != null && Caption.IndexOf(text, StringComparison.CurrentCultureIgnoreCase) != -1;
			 */

		}

	}
}