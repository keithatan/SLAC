using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Virtual_Lab;

namespace Virtual_Lab
{
    public class Utils
    {
        public static Size CalculateResizeToFit(Size imageSize, Size boxSize)
        {

            var WidthScale = boxSize.Width / (double)imageSize.Width;
            var HeightScale = boxSize.Height / (double)imageSize.Height;
            var Scale = Math.Min(WidthScale, HeightScale);
            return new Size(
                (int)Math.Round((boxSize.Width * Scale)),
                (int)Math.Round((boxSize.Height * Scale))
                );
        }
    }
}
