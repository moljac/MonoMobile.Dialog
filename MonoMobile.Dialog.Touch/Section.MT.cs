//
// Elements.cs: defines the various components of our view
//
// Author:
//   Miguel de Icaza (miguel@gnome.org)
//
// Copyright 2010, Novell, Inc.
//
// Code licensed under the MIT X11 license
//
// TODO: StyledStringElement: merge with multi-line?
// TODO: StyledStringElement: add image scaling features?
// TODO: StyledStringElement: add sizing based on image size?
// TODO: Move image rendering to StyledImageElement, reason to do this: the image loader would only be imported in this case, linked out otherwise
//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using System.Drawing;
using MonoTouch.Foundation;
using MonoMobile.Dialog.Utilities;
using MonoTouch.CoreAnimation;

namespace MonoMobile.Dialog
{
	/// <summary>
	/// Sections contain individual Element instances that are rendered by MonoTouch.Dialog
	/// </summary>
	/// <remarks>
	/// Sections are used to group elements in the screen and they are the
	/// only valid direct child of the RootElement.    Sections can contain
	/// any of the standard elements, including new RootElements.
	/// 
	/// RootElements embedded in a section are used to navigate to a new
	/// deeper level.
	/// 
	/// You can assign a header and a footer either as strings (Header and Footer)
	/// properties, or as UIViews to be shown (HeaderView and FooterView).   Internally
	/// this uses the same storage, so you can only show one or the other.
	/// </remarks>
	public partial class Section 
		: 
		  Element
		, IEnumerable
		, IEnumerable<Element>	// // mc++ added
	{


		// mc++ commonization object header, footer;

		// X corresponds to the alignment, Y to the height of the password
		public SizeF EntryAlignment;

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
		public Section(string caption)
			: base(caption)
		{
		}
		//-------------------------------------------------------------------------
		public Section(UIView header)
			: base(null)
		{
			HeaderView = header;
		}
		//-------------------------------------------------------------------------
		public Section(UIView header, UIView footer)
			: base(null)
		{
			HeaderView = header;
			FooterView = footer;
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


		/// <summary>
		/// The section's header view.  
		/// </summary>
		public UIView HeaderView
		{
			get
			{
				return header as UIView;
			}
			set
			{
				header = value;
			}
		}

		/// <summary>
		/// The section's footer view.
		/// </summary>
		public UIView FooterView
		{
			get
			{
				return footer as UIView;
			}
			set
			{
				footer = value;
			}
		}


		# region    Collection
		//-------------------------------------------------------------------------
		/// <summary>
		/// Adds a new child Element to the Section
		/// </summary>
		/// <param name="element">
		/// An element to add to the section.
		/// </param>
		public void Add(Element element)
		{
			if (element == null)
				return;

			Elements.Add(element);
			element.Parent = this;

			if (Parent != null)
				InsertVisual(Elements.Count - 1, UITableViewRowAnimation.None, 1);
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
		public void Add(UIView view)
		{
			if (view == null)
				return;
			Add(new UIViewElement(null, view, false));
		}

		//-------------------------------------------------------------------------
		/// <summary>
		///   Adds the UIViews to the section.
		/// </summary>
		/// <param name="views">
		/// An enumarable list that can be produced by something like:
		///    from x in ... select (UIView) new UIFoo ();
		/// </param>
		public void Add(IEnumerable<UIView> views)
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
		public void Insert(int idx, UITableViewRowAnimation anim, params Element[] newElements)
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
			if (Parent != null && root.TableView != null)
			{
				if (anim == UITableViewRowAnimation.None)
					root.TableView.ReloadData();
				else
					InsertVisual(idx, anim, newElements.Length);
			}
		}
		//-------------------------------------------------------------------------
		public int Insert(int idx, UITableViewRowAnimation anim, IEnumerable<Element> newElements)
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
			if (root != null && root.TableView != null)
			{
				if (anim == UITableViewRowAnimation.None)
					root.TableView.ReloadData();
				else
					InsertVisual(idx, anim, pos - idx);
			}
			return count;
		}
		//-------------------------------------------------------------------------
		public void Insert(int index, params Element[] newElements)
		{
			Insert(index, UITableViewRowAnimation.None, newElements);
		}
		//-------------------------------------------------------------------------
		void InsertVisual(int idx, UITableViewRowAnimation anim, int count)
		{
			var root = Parent as RootElement;

			if (root == null || root.TableView == null)
				return;

			int sidx = root.IndexOf(this);
			var paths = new NSIndexPath[count];
			for (int i = 0; i < count; i++)
				paths[i] = NSIndexPath.FromRowSection(idx + i, sidx);

			root.TableView.InsertRows(paths, anim);
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
		public void RemoveRange(int start, int count)
		{
			RemoveRange(start, count, UITableViewRowAnimation.Fade);
		}
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
		public void RemoveRange(int start, int count, UITableViewRowAnimation anim)
		{
			if (start < 0 || start >= Elements.Count)
				return;
			if (count == 0)
				return;

			var root = Parent as RootElement;

			if (start + count > Elements.Count)
				count = Elements.Count - start;

			Elements.RemoveRange(start, count);

			if (root == null || root.TableView == null)
				return;

			int sidx = root.IndexOf(this);
			var paths = new NSIndexPath[count];
			for (int i = 0; i < count; i++)
				paths[i] = NSIndexPath.FromRowSection(start + i, sidx);
			root.TableView.DeleteRows(paths, anim);
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
			if (root != null && root.TableView != null)
				root.TableView.ReloadData();
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
	

		public override UITableViewCell GetCell(UITableView tv)
		{
			var cell = new UITableViewCell(UITableViewCellStyle.Default, "");
			cell.TextLabel.Text = "Section was used for Element";

			return cell;
		}
	}
}