using System;
using Android.App;
using Android.Content;

namespace MonoMobile.Dialog
{
	public partial class DateElement : DateTimeElement
	{
		public DateElement(string caption, DateTime date)
			: base(caption, date)
		{
			this.Click = delegate { EditDate(); };
		}

		protected DateElement(string caption, DateTime date, int layoutId)
			: base(caption, date, layoutId)
		{
			this.Click = delegate { EditDate(); };
		}

		public override string Format(DateTime dt)
		{
			return dt.ToShortDateString();
		}

		// the event received when the user "sets" the date in the dialog
		void OnDateSet(object sender, DatePickerDialog.DateSetEventArgs e)
		{
			DateTime current = DateValue;
			DateValue = new DateTime(e.Date.Year, e.Date.Month, e.Date.Day, current.Hour, current.Minute, 0);
		}

		private void EditDate()
		{
			Context context = GetContext();
			if (context == null)
			{
			global::Android.Util.Log.Warn("DateElement", "No Context for Edit");
				return;
			}
			DateTime val = DateValue;
			new DatePickerDialog(context, OnDateSet, val.Year, val.Month - 1, val.Day).Show();
		}
	}
}