using GUI_2022_23_01_AS4DD4.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.IO;

namespace GUI_2022_23_01_AS4DD4
{
    public class GameDisplay : FrameworkElement
    {
        Size size;
        static Random r = new Random();

        IShooterModel model;
        IShooterControl control;



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

        public Brush EnemyBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine(@"..\..\..\Images", "Bandit.png"), UriKind.RelativeOrAbsolute)));
            }
        }

        public Brush CrossHairBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine(@"..\..\..\Images", "Crosshair.png"), UriKind.RelativeOrAbsolute)));
            }
        }

        public Brush PotionBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine(@"..\..\..\Images", "Potion.png"), UriKind.RelativeOrAbsolute)));
            }
        }

        public Brush SignBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine(@"..\..\..\Images", "Sign.png"), UriKind.RelativeOrAbsolute)));
            }
        }


        public void DrawBackground(DrawingContext dc)
        {
            dc.DrawRectangle(BackgroundBrush, null, new Rect(0, 0, size.Width, size.Height));
        }

        public void DrawSign(DrawingContext dc)
        {
            dc.DrawRectangle(SignBrush, null, new Rect( (size.Width / 16) * 13, (size.Height / 9) * 6, size.Width/6, size.Height/6 ));      //kinda reszponzív
        }

        public void DrawEnemy(DrawingContext dc)        //random position az ablakban, ha legyőztük, akkor eltűnik és kirajzolja a következőt a listából
        {
            //int enemyPositionX = r.Next(0, (int)size.Width);
            //int enemyPositionY = r.Next(0, (int)size.Height);

            Point enemyPosition = new Point(r.Next(0, (int)size.Width), r.Next(0, (int)size.Height));

            dc.DrawRectangle(EnemyBrush, null, new Rect(enemyPosition.X, enemyPosition.Y, size.Width / 16, size.Height / 16));
        }

        public void DrawCrossHair(DrawingContext dc)        //segédmetódus a DrawEnemyhez, playeren belül relatív random pozíció
        {
            //dc.DrawRectangle(CrossHairBrush, null, new Rect(model.Enemy.Position.X + r.Next(0, 100), model.Enemy.Position.Y + r.Next(0, 100), 50, 50));
        }







        protected override void OnRender(DrawingContext dc)
        {

            base.OnRender(dc);
            if (size.Width > 0 && size.Height > 0)
            {

                

                DrawBackground(dc);
                DrawSign(dc);
                //DrawEnemy(dc);
                //DrawCrossHair(dc);
                
            }
            

        }



    }
}
