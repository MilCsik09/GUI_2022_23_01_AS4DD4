using System.Drawing;
using System.Windows;
using Point = System.Drawing.Point;
using Size = System.Windows.Size;

namespace GUI_2022_23_01_AS4DD4.Models
{
    public class CrossHair
    {

        public Point Position { get; set; }
        public Size Size { get; set; }
        public CrossHair(Point position, Size size)
        {
            Position = position;
            Size = size;
        }
        public CrossHair()
        {

        }
    }
}