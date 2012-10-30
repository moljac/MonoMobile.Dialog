using System;

namespace MonoMobile.Dialog
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, Inherited = false)]
    public partial class EntryAttribute : Attribute
    {
        public string Placeholder;

        public EntryAttribute() : this(null)
        {
        }

        public EntryAttribute(string placeholder)
        {
            Placeholder = placeholder;
        }
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, Inherited = false)]
    public partial class DateAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, Inherited = false)]
    public partial class TimeAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, Inherited = false)]
    public partial class CheckboxAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, Inherited = false)]
    public partial class MultilineAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, Inherited = false)]
    public partial class HtmlAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, Inherited = false)]
    public partial class SkipAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, Inherited = false)]
    public partial class StringAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, Inherited = false)]
    public partial class PasswordAttribute : EntryAttribute
    {
        public PasswordAttribute(string placeholder) : base(placeholder)
        {
        }
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, Inherited = false)]
    public partial class AlignmentAttribute : Attribute
    {
        public AlignmentAttribute(object alignment)
        {
            Alignment = alignment;
        }
        public object Alignment;
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, Inherited = false)]
    public partial class RadioSelectionAttribute : Attribute
    {
        public string Target;

        public RadioSelectionAttribute(string target)
        {
            Target = target;
        }
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, Inherited = false)]
    public partial class OnTapAttribute : Attribute
    {
        public string Method;

        public OnTapAttribute(string method)
        {
            Method = method;
        }
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, Inherited = false)]
    public partial class CaptionAttribute : Attribute
    {
        public string Caption;

        public CaptionAttribute(string caption)
        {
            Caption = caption;
        }
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, Inherited = false)]
    public partial class SectionAttribute : Attribute
    {
        public string Caption, Footer;

        public SectionAttribute()
        {
        }

        public SectionAttribute(string caption)
        {
            Caption = caption;
        }

        public SectionAttribute(string caption, string footer)
        {
            Caption = caption;
            Footer = footer;
        }
    }

    public partial class RangeAttribute : Attribute
    {
        public int High;
        public int Low;
        public bool ShowCaption;

        public RangeAttribute(int low, int high)
        {
            Low = low;
            High = high;
        }
    }
}