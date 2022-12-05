using GUI_2022_23_01_AS4DD4.Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GUI_2022_23_01_AS4DD4
{
    public class Display : FrameworkElement
    {
        Size size;
        Random r = new Random();

        IShooterModel model;

        public void SetupModel(IShooterModel model)
        {
            this.model = model;
            this.model.Changed += (sender, eventargs) => this.InvalidateVisual();
        }

        public void SetupSizes(Size size)
        {
            this.size = size;
            this.InvalidateVisual();

        }

        public void Resize(Size size)
        {
            this.size = size;
            InvalidateVisual();
        }

        public Brush BackgroundBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine(@"..\..\..\Images", "Background.jpg"), UriKind.RelativeOrAbsolute)));
            }
        }

        //protected override void OnRender(DrawingContext drawingContext)
        //{
        //    base.OnRender(drawingContext);

        //    //Example for testing renderer
        ////    if (size.Width > 0 && size.Height > 0)
        ////    {
        ////        int row = r.Next(10, 30);
        ////        int column = r.Next(10, 30);

        ////        double rectWidth = size.Width / column;
        ////        double rectHeight = size.Height / row;

        ////        for (int i = 0; i < row; i++)
        ////        {
        ////            for (int j = 0; j < column; j++)
        ////            {
        ////                drawingContext.DrawRectangle(
        ////                    new SolidColorBrush(Color.FromRgb((byte)r.Next(0, 255), (byte)r.Next(0, 255), (byte)r.Next(0, 255))),
        ////                    new Pen(Brushes.Black, 0),
        ////                    new Rect(j * rectWidth, i * rectHeight, rectWidth, rectHeight));
        ////            }
        ////        }

        ////    }
        //}
    }
}
