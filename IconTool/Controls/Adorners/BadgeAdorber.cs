using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace IconTool.Controls
{
    public class BadgeAdorber : BaseAdorner
    {
        private Badge _control;

        public BadgeAdorber(UIElement uIElement) : base(uIElement)
        {

        }

        protected override Size MeasureOverride(Size constraint)
        {
            return base.MeasureOverride(constraint);
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            _control?.ChangeSize(finalSize);
            return base.ArrangeOverride(finalSize);
        }

        public void SetBadge(Badge badge) { 
            _control = badge;
            VisualCollection.Add(_control);
        }
    }
}
