using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using PensjonatApp;
using System.Windows.Media;
using System.Windows.Controls;

namespace PensjonatApp.ValidationEx
{
	class ValidationHelper
	{
		public static bool isValid(DependencyObject parent)
		{
			if (Validation.GetHasError(parent))
				return false;

			DependencyObject child;
			// Validate all the bindings on the children
			for (int i = 0; i != VisualTreeHelper.GetChildrenCount(parent); ++i)
			{
				child = VisualTreeHelper.GetChild(parent, i);
				if (!isValid(child)) { return false; }
			}

			return true;
		}
		public static void forceUpdate(DependencyObject parent)
		{
			DependencyObject child;
			System.Windows.Data.BindingExpression bind;
			for (int i = 0; i != VisualTreeHelper.GetChildrenCount(parent); ++i)
			{
				child = VisualTreeHelper.GetChild(parent, i);
				if (child is FrameworkElement)
				{
					bind = ((FrameworkElement)child).GetBindingExpression(TextBox.TextProperty);
					if (bind != null)
						bind.UpdateSource();
				}
				forceUpdate(child);
			}
		}
	}
}
