using System;
using System.Collections.Generic;
using System.Text;

namespace _2.PointInRectangle
{
    public class Rectangle
    {
        public Point TopLeft { get; set; }
        public Point BottomRight { get; set; }

        public Rectangle(Point topLeft, Point bottomRight)
        {
            this.TopLeft = topLeft;
            this.BottomRight = bottomRight;
        }

        public bool Contains(Point point)
        {
            if (point.X >= this.TopLeft.X &&
                point.X <= this.BottomRight.X &&
                point.Y >= this.TopLeft.Y &&
                point.Y <= this.BottomRight.Y)
            {
                return true;
            }

            return false;
        }
    }
}
