using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace MonoMobile.Dialog
{
	public partial class RootElement
	{
		public Func<RootElement, UIElement> createOnSelected;

		# region    Constructors
		//-------------------------------------------------------------------------
		/// <summary>
		///  Initializes a RootSection with a caption
		/// </summary>
		/// <param name="caption">
		///  The caption to render.
		/// </param>
		public RootElement(string caption)
			: base(caption)
		{
			Button btn = new Button();
			this.Children.Add(btn);
			summarySection = -1;
			Sections = new List<Section>();
		}
		//-------------------------------------------------------------------------
		/// <summary>
		///   Initializes a RootElement with a caption with a summary fetched from the specified section and leement
		/// </summary>
		/// <param name="caption">
		/// The caption to render cref="System.String"/>
		/// </param>
		/// <param name="section">
		/// The section that contains the fe with the summary.
		/// </param>
		/// <param name="fe">
		/// The fe index inside the section that contains the summary for this RootSection.
		/// </param>
		public RootElement(string caption, int section, int element)
			: base(caption)
		{
			summarySection = section;
			summaryElement = element;
		}
		//-------------------------------------------------------------------------
		/// <summary>
		/// Initializes a RootElement that renders the summary based on the radio settings of the contained elements. 
		/// </summary>
		/// <param name="caption">
		/// The caption to ender
		/// </param>
		/// <param name="group">
		/// The group that contains the checkbox or radio information.  This is used to display
		/// the summary information when a RootElement is rendered inside a section.
		/// </param>
		public RootElement(string caption, Group group)
			: base(caption)
		{
			this.group = group;
		}
		//-------------------------------------------------------------------------
		# endregion Constructors

		public StackPanel StackPanel;

		# region    Collection
		//-------------------------------------------------------------------------
		/// <summary>
		/// Adds a new section to this RootElement
		/// </summary>
		/// <param name="section">
		/// The section to add, if the e is visible, the section is inserted with no animation
		/// </param>
		public void Add(Section section)
		{
			if (section == null)
				return;

			Sections.Add(section);
			section.Parent = this;
			if (StackPanel == null)
				return;

			// StackPanel.InsertSections(MakeIndexSet(Sections.Count - 1, 1), UITableViewRowAnimation.None); // MT.D
			StackPanel.Children.Add(section);
		}
		//-------------------------------------------------------------------------
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
		}
		//-------------------------------------------------------------------------
		/// <summary>
		/// Inserts a new section into the RootElement
		/// </summary>
		/// <param name="idx">
		/// The index where the section is added <see cref="System.Int32"/>
		/// </param>
		/// <param name="anim">
		/// The <see cref="UIstack_panelRowAnimation"/> type.
		/// </param>
		/// <param name="newSections">
		/// A <see cref="Section[]"/> list of sections to insert
		/// </param>
		/// <remarks>
		///    This inserts the specified list of sections (a params argument) into the
		///    e using the specified animation.
		/// </remarks>
		public void Insert
			(
			  int idx
			// , UITableViewRowAnimation anim			// MT.D
			, DoubleAnimation anim
			, params Section[] newSections
			)
		{
			if (idx < 0 || idx > Sections.Count)
				return;
			if (newSections == null)
				return;

			if (StackPanel != null)
			{
				// StackPanel.BeginUpdates();	// MT.D
				StackPanel.UpdateLayout();	// ????
			}

			int pos = idx;
			foreach (var s in newSections)
			{
				s.Parent = this;
				Sections.Insert(pos++, s);
			}

			if (StackPanel == null)
				return;

			// StackPanel.InsertSections(MakeIndexSet(idx, newSections.Length), anim); // MT.D
			// StackPanel.EndUpdates();												// MT.D

			foreach (Section s in newSections)
			{
				StackPanel.Children.Add(s);
			}
			StackPanel.UpdateLayout();
		}
		//-------------------------------------------------------------------------
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
		///    e using the Fade animation.
		/// </remarks>
		public void Insert(int idx, Section section)
		{
			Insert
				(
				  idx
				// , UITableViewRowAnimation	// MT.D
				// , DoubleAnimation.Fade		// TODO:	
				, section
				);
		}
		//-------------------------------------------------------------------------
		/// <summary>
		/// Removes a section at a specified location
		/// </summary>
		public void RemoveAt(int idx)
		{
			RemoveAt
				(
				  idx
				//, UIstack_panelRowAnimation.Fade
				);
		}
		//-------------------------------------------------------------------------
		/// <summary>
		/// Removes a section at a specified location using the specified animation
		/// </summary>
		/// <param name="idx">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="anim">
		/// A <see cref="UIstack_panelRowAnimation"/>
		/// </param>
		public void RemoveAt
			(
			  int idx
			// , UITableViewRowAnimation anim		// MT.D
			, DoubleAnimation anim
			)
		{
			if (idx < 0 || idx >= Sections.Count)
				return;

			Sections.RemoveAt(idx);

			if (StackPanel == null)
				return;

			// TableView.DeleteSections(NSIndexSet.FromIndex(idx), anim);  // MT.D
			StackPanel.Children.Clear();
			StackPanel.UpdateLayout();
		}
		//-------------------------------------------------------------------------
		public void Remove(Section s)
		{
			if (s == null)
				return;
			int idx = Sections.IndexOf(s);
			if (idx == -1)
				return;
			RemoveAt
				(
				  idx
				//, UITableViewRowAnimation.Fade
				// DoubleAnimation.
				);
		}
		//-------------------------------------------------------------------------
		public void Remove
			(
			  Section s
			// , UITableViewRowAnimation anim	// MT.D
			, DoubleAnimation anim
			)
		{
			if (s == null)
				return;
			int idx = Sections.IndexOf(s);
			if (idx == -1)
				return;
			RemoveAt(idx, anim);
		}
		//-------------------------------------------------------------------------
		public void Clear()
		{
			foreach (var s in Sections)
				s.Dispose();
			Sections = new List<Section>();
			if (StackPanel != null)
			{
				// TableView.ReloadData();	// MT.D
				StackPanel.UpdateLayout();
			}
		}
		//-------------------------------------------------------------------------
		public int Count
		{
			get
			{
				return Sections.Count;
			}
		}
		//-------------------------------------------------------------------------
		public Section this[int idx]
		{
			get
			{
				return Sections[idx];
			}
		}
		//-------------------------------------------------------------------------
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
		//-------------------------------------------------------------------------
		# endregion Collection

		/// <summary>
		/// MT.D: public override UITableViewCell GetCell(UITableView tv)
		/// MA.D: public override View GetView(Context context, View convertView, ViewGroup parent)
		/// WP.D: Brainstorming needed!
		/// 
		/// Control					NOGO
		/// FrameworkElement		GO!
		/// TODO: see more!
		/// </summary>
		/// <returns></returns>
		public override FrameworkElement GetControl()
		{
			System.Diagnostics.Debug.WriteLine("RootElement.GetControl() ");

			StackPanel sp_rootelement = new StackPanel()
			{
			  Orientation = System.Windows.Controls.Orientation.Vertical
			, Name = "RootElement"
			,VerticalAlignment = System.Windows.VerticalAlignment.Stretch
			};

			TextBlock tb = new TextBlock();
			tb.Text = this.Caption;
			sp_rootelement.Children.Add(tb);

			foreach (Section s in Sections)
			{
				FrameworkElement fe_section = s.GetControl();
				sp_rootelement.Children.Add(fe_section);
			}

			//return sp_rootelement;

			//ScrollViewer scv = new ScrollViewer()
			//{
			//    Content = sp_rootelement
			//};

			return sp_rootelement;
		}
	}
}