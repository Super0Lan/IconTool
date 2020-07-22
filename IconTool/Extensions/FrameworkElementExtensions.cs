using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace IconTool.Extensions
{
    public static class FrameworkElementExtensions
    {
        public static bool IsContains(this DependencyObject parent, DependencyObject element) {
            if (parent == null || element == null) {
                return false;
            }
            if (parent == element) {
                return true;
            }
            bool res = false;
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++) {
                DependencyObject visual = VisualTreeHelper.GetChild(parent, i);
                if (visual.IsContains(element)) {
                    return true;
                }
            }
            return res;
        }
    }
}
