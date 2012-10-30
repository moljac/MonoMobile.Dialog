using System;
using Android.App;
using Android.Content;

namespace MonoMobile.Dialog
{
	public partial class TimeElement : DateTimeElement
	{
		public TimeElement(string caption, DateTime date)
			: base(caption, date)
		{
			this.Click = delegate { EditDate(); };
		}

		protected TimeElement(string caption, DateTime date, int layoutId)
			: base(caption, date, layoutId)
		{
			this.Click = delegate { EditDate(); };
		}

		public override string Format(DateTime dt)
		{
			return dt.ToShortTimeString();
		}

		// the event received when the user "sets" the date in the dialog
		void OnDateSet(object sender, TimePickerDialog.TimeSetEventArgs e)
		{
			DateTime current = DateValue;
			DateValue = new DateTime(current.Year, current.Month, current.Day, e.HourOfDay, e.Minute, 0);
		}

		private void EditDate()
		{
			Context context = GetContext();
			if (context == null)
			{
			global::Android.Util.Log.Warn("TimeElement", "No Context for Edit");
				return;
			}
			DateTime val = DateValue;
			// TODO: get the current time setting for thge 24 hour clock
			new TimePickerDialog(context, OnDateSet, val.Hour, val.Minute, false).Show();
		}
	}
}