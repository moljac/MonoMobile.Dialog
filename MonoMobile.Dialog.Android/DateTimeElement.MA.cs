using System;
using Android.App;
using Android.Content;

namespace MonoMobile.Dialog
{
	public partial class DateTimeElement : StringElement
	{
		protected DateTimeElement(string caption, DateTime date, int layoutId)
			: base(caption, layoutId)
		{
			DateValue = date;
		}

		public virtual string Format(DateTime dt)
		{
			return
				dt.ToShortDateString() + " " + dt.ToShortTimeString()
				;
		}

		/// <summary>
		/// MT.D unification
		/// </summary>
		/// <param name="dt"></param>
		/// <returns></returns>
		public virtual string FormatDate(DateTime dt)
		{
			return this.Format(dt);
		}
	}
}