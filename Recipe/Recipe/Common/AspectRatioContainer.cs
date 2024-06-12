using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Common
{
    public class AspectRatioContainer : ContentView
    {
        public static readonly BindableProperty AspectRatioProperty =
            BindableProperty.Create(nameof(AspectRatio), typeof(double), typeof(AspectRatioContainer), 1.0);

        public double AspectRatio
        {
            get => (double)GetValue(AspectRatioProperty);
            set => SetValue(AspectRatioProperty, value);
        }

        protected override SizeRequest OnMeasure(double widthConstraint, double heightConstraint)
        {
            double width = widthConstraint;
            double height = width * AspectRatio;

            return new SizeRequest(new Size(width, height));
        }
    }
}
