// Copyright 2010-2011 Miguel de Icaza
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//
using System;
using MonoTouch.Foundation;

namespace MonoMobile.Dialog
{
	/// <summary>
	/// 
	/// </summary>
	/// <see cref="http://stackoverflow.com/questions/6265103/how-to-use-multi-languages-for-iphone-application-using-monotouch"/>
	/// <see cref="http://stackoverflow.com/questions/10166001/monotouch-localization-from-a-common-project"/>
	/// <see cref="http://stackoverflow.com/questions/7352913/monotouch-localized-xibs-nibs-not-placed-in-bundle-correctly"/>
	internal static class LocalizationExtensions
	{
		/// <summary>
		/// Gets the localized text for the specified string.
		/// </summary>
		public static string GetText (this string text)
		{
			if (String.IsNullOrEmpty (text))
				return text;
			return 
				// 2012-09-18 no doc skip this!
				NSBundle.MainBundle.LocalizedString
				(
				  text
				, String.Empty  // table 
				, String.Empty  // comment
				);
		}
	}
}
