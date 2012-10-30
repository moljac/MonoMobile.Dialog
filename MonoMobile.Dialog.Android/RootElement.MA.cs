using System;
using System.Collections;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Views;
using Android.Widget;

namespace MonoMobile.Dialog
{
	public partial class RootElement : Element, IEnumerable<Section>, IDialogInterfaceOnClickListener
	{
		TextView _caption;
		TextView _value;

		public Func<RootElement, View> createOnSelected;


		# region    Constructors
		//-------------------------------------------------------------------------
		/// <summary>
		///  Initializes a RootSection with a caption
		/// </summary>
		/// <param name="caption">
		///  The caption to render.
		/// </param>
		public RootElement(string caption)
			: base(caption, (int)ElementLayout.dialog_root)
		{
			summarySection = -1;
			Sections = new List<Section>();
		}
		//-------------------------------------------------------------------------
		# endregion Constructors
	

		/// <summary>
		/// Initializes a RootSection with a caption and a callback that will
		/// create the nested UIViewController that is activated when the user
		/// taps on the element.
		/// </summary>
		/// <param name="caption">
		///  The caption to render.
		/// </param>
		public RootElement(string caption, Func<RootElement, View> createOnSelected)
			: base(caption, (int)ElementLayout.dialog_root)
		{
			summarySection = -1;
			this.createOnSelected = createOnSelected;
			Sections = new List<Section>();
		}

		/// <summary>
		///   Initializes a RootElement with a caption with a summary fetched from the 
		///   specified section and element
		/// </summary>
		/// <param name="caption">
		/// The caption to render cref="System.String"/>
		/// </param>
		/// <param name="section">
		/// The section that contains the element with the summary.
		/// </param>
		/// <param name="element">
		/// The element index inside the section that contains the summary for this RootSection.
		/// </param>
		public RootElement(string caption, int section, int element)
			: base(caption, (int)ElementLayout.dialog_root)
		{
			summarySection = section;
			summaryElement = element;
		}

		/// <summary>
		/// Initializes a RootElement that renders the summary based on the radio settings 
		/// of the contained elements. 
		/// </summary>
		/// <param name="caption">
		/// The caption to ender
		/// </param>
		/// <param name="group">
		/// The group that contains the checkbox or radio information.  This is used to display
		/// the summary information when a RootElement is rendered inside a section.
		/// </param>
		public RootElement(string caption, Group g)
			: base(caption, (int)ElementLayout.dialog_root)
		{
			this.group = g;
		}

		/// <summary>
		/// Single save point for a context, elements can get this context via GetContext() for navigation operations
		/// </summary>
		public Context Context { get; set; }

		public int Count
		{
			get
			{
				return Sections.Count;
			}
		}

		public Section this[int idx]
		{
			get
			{
				return Sections[idx];
			}
		}

		internal int IndexOf(Section target)
		{
			int idx = 0;
			foreach (Section s in Sections)
			{
				if (s == target)
					return idx;
				idx++;
			}
			return -1;
		}

		internal void Prepare()
		{
			int current = 0;
			foreach (Section s in Sections)
			{
				foreach (Element e in s.Elements)
				{
					var re = e as RadioElement;
					if (re != null)
						re.RadioIdx = current++;
					if (UnevenRows == false && e is IElementSizing)
						UnevenRows = true;
				}
			}
		}

		public override string Summary()
		{
			return GetSelectedValue();
		}
		
		void SetSectionStartIndex()
		{
			int currentIndex = 0;
			foreach(var section in Sections)
			{
				section.StartIndex = currentIndex;
				currentIndex += section.Count;
			}
		}
		/// <summary>
		/// Adds a new section to this RootElement
		/// </summary>
		/// <param name="section">
		/// The section to add, if the root is visible, the section is inserted with no animation
		/// </param>
		public void Add(Section section)
		{
			if (section == null)
				return;

			Sections.Add(section);
			section.Parent = this;
			SetSectionStartIndex();
		}

		//
		// This makes things LINQ friendly;  You can now create RootElements
		// with an embedded LINQ expression, like this:
		// new RootElement ("Title") {
		//     from x in names
		//         select new Section (x) { new StringElement ("Sample") }
		//
		public void Add(IEnumerable<Section> sections)
		{
			foreach (var s in sections)
				Add(s);
			
			SetSectionStartIndex();
		}

		/// <summary>
		/// Inserts a new section into the RootElement
		/// </summary>
		/// <param name="idx">
		/// The index where the section is added <see cref="System.Int32"/>
		/// </param>
		/// <param name="newSections">
		/// A <see cref="Section[]"/> list of sections to insert
		/// </param>
		/// <remarks>
		///    This inserts the specified list of sections (a params argument) into the
		///    root using the specified animation.
		/// </remarks>
		public void Insert(int idx, params Section[] newSections)
		{
			if (idx < 0 || idx > Sections.Count)
				return;
			if (newSections == null)
				return;

			//if (Table != null)
			//    Table.BeginUpdates();

			int pos = idx;
			foreach (var s in newSections)
			{
				s.Parent = this;
				Sections.Insert(pos++, s);
			}
			
			SetSectionStartIndex();
		}

		/// <summary>
		/// Removes a section at a specified location
		/// </summary>
		public void RemoveAt(int idx)
		{
			if (idx < 0 || idx >= Sections.Count)
				return;

			Sections.RemoveAt(idx);
			
			SetSectionStartIndex();
		}

		public void Remove(Section s)
		{
			if (s == null)
				return;
			int idx = Sections.IndexOf(s);
			if (idx == -1)
				return;
			RemoveAt(idx);
			
			SetSectionStartIndex();
		}

		public void Clear()
		{
			foreach (var s in Sections)
				s.Dispose();
			Sections = new List<Section>();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				Context = null;
				if (Sections == null)
					return;
				Clear();
				Sections = null;
			}
		}

		/// <summary>
		/// The currently selected Radio item in the whole Root.
		/// </summary>
		public int RadioSelected
		{
			get
			{
				var radio = group as RadioGroup;
				if (radio != null)
					return radio.Selected;
				return -1;
			}
			set
			{
				var radio = group as RadioGroup;
				if (radio != null)
					radio.Selected = value;
			}
		}

		private string GetSelectedValue()
		{
			var radio = group as RadioGroup;
			if (radio == null)
				return string.Empty;

			int selected = radio.Selected;
			int current = 0;
			string radioValue = string.Empty;
			foreach (var s in Sections)
			{
				foreach (var e in s.Elements)
				{
					if (!(e is RadioElement))
						continue;

					if (current == selected)
						return e.Summary();

					current++;
				}
			}

			return string.Empty;
		}

		public override View GetView(Context context, View convertView, ViewGroup parent)
		{
			Context = context;

			LayoutInflater inflater = LayoutInflater.FromContext(context);
			
			View cell = new TextView(context) {TextSize = 16f, Text = Caption};
			var radio = group as RadioGroup;

			if (radio != null)
			{
				string radioValue = GetSelectedValue();
				cell = DroidResources.LoadStringElementLayout(context, convertView, parent, LayoutId, out _caption, out _value);
				if (cell != null)
				{
					_caption.Text = Caption;
					_value.Text = radioValue;
//                    this.Click = (o, e) => { SelectRadio(); };
					this.Click += delegate { SelectRadio(); };
				}
			}
			else if (group != null)
			{
				int count = 0;
				foreach (var s in Sections)
				{
					foreach (var e in s.Elements)
					{
						var ce = e as CheckboxElement;
						if (ce != null)
						{
							if (ce.Value)
								count++;
							continue;
						}
						var be = e as BoolElement;
						if (be != null)
						{
							if (be.Value)
								count++;
							continue;
						}
					}
				}
				//cell.DetailTextLabel.Text = count.ToString();
			}
			else if (summarySection != -1 && summarySection < Sections.Count)
			{
				var s = Sections[summarySection];
				//if (summaryElement < s.Elements.Count)
				//    cell.DetailTextLabel.Text = s.Elements[summaryElement].Summary();
			}
			//cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;

			return cell;
		}


		public void SelectRadio()
		{
			List<string> items = new List<string>();
			foreach (var s in Sections)
			{
				foreach (var e in s.Elements)
				{
					if (e is RadioElement)
						items.Add(e.Summary());
				}
			}

			var dialog = new AlertDialog.Builder(Context);
			dialog.SetSingleChoiceItems(items.ToArray(), this.RadioSelected, this);
			dialog.SetTitle(this.Caption);
			dialog.SetNegativeButton("Cancel", this);
			dialog.Create().Show();
		}

		void IDialogInterfaceOnClickListener.OnClick(IDialogInterface dialog, int which)
		{
			if ((int)which >= 0)
			{
				this.RadioSelected = (int)which;
				string radioValue = GetSelectedValue();
				_value.Text = radioValue;
			}

			dialog.Dismiss();
		}

	}
}