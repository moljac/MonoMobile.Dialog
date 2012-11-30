using System;
using System.Collections;
using System.Collections.Generic;

using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Controls;


namespace MonoMobile.Dialog
{
	public partial class Section
		//: UIElement
	{
		# region    Properites
		//-------------------------------------------------------------------------
		//-------------------------------------------------------------------------
		# endregion Properites

		# region    Constructors
		//-------------------------------------------------------------------------
		/// <summary>
		///  Constructs a Section without header or footers.
		/// </summary>
		public Section()
			: base(null)
		{
		}
		//-------------------------------------------------------------------------
		/// <summary>
		///  Constructs a Section with the specified header
		/// </summary>
		/// <param name="caption">
		/// The header to display
		/// </param>
		public Section(string caption)
			: base(caption)
		{
		}
		//-------------------------------------------------------------------------
		/// <summary>
		/// Constructs a Section with a header and a footer
		/// </summary>
		/// <param name="caption">
		/// The caption to display (or null to not display a caption)
		/// </param>
		/// <param name="footer">
		/// The footer to display.
		/// </param>
		public Section(string caption, string footer)
			: base(caption)
		{
			Footer = footer;
		}
		//-------------------------------------------------------------------------
		# endregion Constructors

		# region    Collection
		//-------------------------------------------------------------------------
		//-------------------------------------------------------------------------
		//-------------------------------------------------------------------------
		# endregion Collection

		# region    Collection
		//-------------------------------------------------------------------------
		/// <summary>
		/// Adds a new child Element to the Section
		/// </summary>
		/// <param name="fe">
		/// An fe to add to the section.
		/// </param>
		public void Add(Element element)
		{
			if (element == null)
				return;

			Elements.Add(element);
			element.Parent = this;

			if (Parent != null)
				InsertVisual
					(
					  Elements.Count - 1
					// MT.D , UITableViewRowAnimation.None
					, 1
					);
		}
		//-------------------------------------------------------------------------
		/// <summary>
		///    Add version that can be used with LINQ
		/// </summary>
		/// <param name="elements">
		/// An enumerable list that can be produced by something like:
		///    from x in ... select (Element) new MyElement (...)
		/// </param>
		public int AddAll(IEnumerable<Element> elements)
		{
			int count = 0;
			foreach (var e in elements)
			{
				Add(e);
				count++;
			}
			return count;
		}
		//-------------------------------------------------------------------------
		/// <summary>
		///    This method is being obsoleted, use AddAll to add an IEnumerable<Element> instead.
		/// </summary>
		[Obsolete("Please use AddAll since this version will not work in future versions of MonoTouch when we introduce 4.0 covariance")]
		public int Add(IEnumerable<Element> elements)
		{
			return AddAll(elements);
		}
		//-------------------------------------------------------------------------
		/// <summary>
		/// Use to add a UIView to a section, it makes the section opaque, to
		/// get a transparent one, you must manually call UIViewElement
		public void Add
			(
			  // MT.D UIView view
			  FrameworkElement view
			)
		{
			if (view == null)
				return;
			Add
				(
				  // new UIViewElement(null, view, false)
				  view
				);
		}

		//-------------------------------------------------------------------------
		/// <summary>
		///   Adds the UIViews to the section.
		/// </summary>
		/// <param name="views">
		/// An enumarable list that can be produced by something like:
		///    from x in ... select (UIView) new UIFoo ();
		/// </param>
		public void Add
			(
			// IEnumerable<UIView> views
			IEnumerable<FrameworkElement> views
			)
		{
			foreach (var v in views)
				Add(v);
		}
		//-------------------------------------------------------------------------
		/// <summary>
		/// Inserts a series of elements into the Section using the specified animation
		/// </summary>
		/// <param name="idx">
		/// The index where the elements are inserted
		/// </param>
		/// <param name="anim">
		/// The animation to use
		/// </param>
		/// <param name="newElements">
		/// A series of elements.
		/// </param>
		public void Insert
			(
			  int idx
			// , UITableViewRowAnimation anim	//MT.D
			, DoubleAnimation anim				// ???
			, params Element[] newElements)
		{
			if (newElements == null)
				return;

			int pos = idx;
			foreach (var e in newElements)
			{
				Elements.Insert(pos++, e);
				e.Parent = this;
			}
			var root = Parent as RootElement;
			if 
				(
				Parent != null 
				&& 
				// e.TableView != null		// MT.D
				root.StackPanel != null
				)
			{
				//if (anim == UITableViewRowAnimation.None)
				if (anim == anim)
				{
					// e.TableView.ReloadData();	// MT.D
					root.StackPanel.UpdateLayout();
				}
				else
				{
					// InsertVisual(idx, anim, newElements.Length);	// MT.D
					InsertVisual(idx, newElements.Length);
				}
			}
		}
		//-------------------------------------------------------------------------
		public int Insert
			(
			  int idx
			// , UITableViewRowAnimation anim	// MT.D
			, IEnumerable<Element> newElements
			)
		{
			if (newElements == null)
				return 0;

			int pos = idx;
			int count = 0;
			foreach (var e in newElements)
			{
				Elements.Insert(pos++, e);
				e.Parent = this;
				count++;
			}
			var root = Parent as RootElement;
			// if (e != null && e.TableView != null)	// MT.D
			if (root != null && root.StackPanel != null)
			{
				// if (anim == UITableViewRowAnimation.None)	// MT.D
				{
					// e.TableView.ReloadData();	// MT.D
					root.StackPanel.UpdateLayout();
				}
				// else
				// {
				// 	// InsertVisual(idx, anim, pos - idx);		// MT.D
				// }
			}
			return count;
		}
		//-------------------------------------------------------------------------
		public void Insert(int index, params Element[] newElements)
		{
			Insert
				(
				  index
				// , UITableViewRowAnimation.None	// MT.D
				, newElements
				);
		}
		//-------------------------------------------------------------------------
		void InsertVisual
			(
			  int idx
			// , UITableViewRowAnimation anim	// MT.D
			, int count
			)
		{
			var root = Parent as RootElement;

			// if (e == null || e.TableView == null)
			// 	return;
			if (root == null || root.StackPanel == null)
				return;


			int sidx = root.IndexOf(this);
			// MT.D var paths = new NSIndexPath[count];
			// MT.D for (int i = 0; i < count; i++)
			// MT.D 	paths[i] = NSIndexPath.FromRowSection(idx + i, sidx);

			//  MT.D e.TableView.InsertRows(paths, anim);
			root.StackPanel.Children.Add
				(
				  new TextBlock()
				  {
					  Text = "Adasdadad"
				  }
				);
		}
		//-------------------------------------------------------------------------
		public void Remove(Element e)
		{
			if (e == null)
				return;
			for (int i = Elements.Count; i > 0; )
			{
				i--;
				if (Elements[i] == e)
				{
					RemoveRange(i, 1);
					return;
				}
			}
		}
		//-------------------------------------------------------------------------
		public void Remove(int idx)
		{
			RemoveRange(idx, 1);
		}
		//-------------------------------------------------------------------------
		/// <summary>
		/// Removes a range of elements from the Section
		/// </summary>
		/// <param name="start">
		/// Starting position
		/// </param>
		/// <param name="count">
		/// Number of elements to remove from the section
		/// </param>
		// MT.D public void RemoveRange(int start, int count)
		// MT.D {
		// MT.D 	RemoveRange(start, count, UITableViewRowAnimation.Fade);
		// MT.D }
		//-------------------------------------------------------------------------
		/// <summary>
		/// Remove a range of elements from the section with the given animation
		/// </summary>
		/// <param name="start">
		/// Starting position
		/// </param>
		/// <param name="count">
		/// Number of elements to remove form the section
		/// </param>
		/// <param name="anim">
		/// The animation to use while removing the elements
		/// </param>
		public void RemoveRange(int start, int count
			// MT.D , UITableViewRowAnimation anim
			)
		{
			if (start < 0 || start >= Elements.Count)
				return;
			if (count == 0)
				return;

			var root = Parent as RootElement;

			if (start + count > Elements.Count)
				count = Elements.Count - start;

			Elements.RemoveRange(start, count);

			// MT.D if (e == null || e.TableView == null)
			if (root == null || root.StackPanel == null)
				return;

			int sidx = root.IndexOf(this);
			// MT.D var paths = new NSIndexPath[count];
			// MT.D for (int i = 0; i < count; i++)
			// MT.D 	paths[i] = NSIndexPath.FromRowSection(start + i, sidx);
			// MT.D e.TableView.DeleteRows(paths, anim);
			root.StackPanel.Children.Clear();
		}
		//-------------------------------------------------------------------------
		public void Clear()
		{
			if (Elements != null)
			{
				foreach (var e in Elements)
					e.Dispose();
			}
			Elements = new List<Element>();

			var root = Parent as RootElement;
			// if (e != null && e.TableView != null)
			//	e.TableView.ReloadData();

			if (root != null && root.StackPanel != null)
			{
				// e.TableView.ReloadData();	// MT.D
				root.StackPanel.UpdateLayout();
			}
		}
		//-------------------------------------------------------------------------
		public int Count
		{
			get
			{
				return Elements.Count;
			}
		}
		//-------------------------------------------------------------------------
		public Element this[int idx]
		{
			get
			{
				return Elements[idx];
			}
		}
		//-------------------------------------------------------------------------
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
			System.Diagnostics.Debug.WriteLine("SectionElement.GetControl() ");

			StackPanel sp_section = new StackPanel()
			{
			  Orientation = System.Windows.Controls.Orientation.Vertical
			, Name = "SectionElement"
			};

			TextBlock tb = new TextBlock()
			{
				Text = this.Caption
			};
			
			sp_section.Children.Add(tb);

			foreach (Element e in this.Elements)
			{
				FrameworkElement fe = e.GetControl();

				sp_section.Children.Add(fe);

				System.Diagnostics.Debug.WriteLine("\t element = {0}", e.ToString());
				System.Diagnostics.Debug.WriteLine("\t framework_element = {0}", fe.ToString());
			}


			return sp_section;
		}
	}
}