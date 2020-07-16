using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace IconTool.Controls
{
    public class LoadingAdorner : BaseAdorner
    {
        private Control _control;

        public LoadingAdorner(UIElement uIElement) : base(uIElement)
        {
            _control = new Control()
            {
                Style = (Style)FindResource("Loading")
            };
            VisualCollection.Add(_control);
        }

        protected override Size MeasureOverride(Size constraint)
        {
            return base.MeasureOverride(constraint);
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            _control.Arrange(new Rect(finalSize));
            return base.ArrangeOverride(finalSize);
        }

        public void SetLoading(bool newValue)
        {
            _control.Visibility = newValue ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
