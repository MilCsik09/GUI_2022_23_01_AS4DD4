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
using System.Windows.Controls;
using GUI_2022_23_01_AS4DD4.Windows;

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


        public void DrawSign(DrawingContext dc)
        {
            dc.DrawRectangle(SignBrush, null, new Rect( size.Width-100, size.Height-100, size.Width/4, size.Height/4 ));      //kinda reszponzív
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
                DrawSign(dc);
                // Load the bandit and crosshair images
                var banditImage = new BitmapImage(new Uri(Path.Combine(@"..\..\..\Images", "Bandit.png"), UriKind.RelativeOrAbsolute));
                var crosshairImage = new BitmapImage(new Uri(Path.Combine(@"..\..\..\Images", "Crosshair.png"), UriKind.RelativeOrAbsolute));

                // Generate a random position for the bandit image within the bounds of the grid
                Random rnd = new Random();
                double x = rnd.Next(0, (int)(GameWindow.Grid.ActualWidth - (banditImage.Width*1.3)));
                double y = rnd.Next(0, (int)(GameWindow.Grid.ActualHeight - (banditImage.Height*1.3)));

                // Draw the bandit image at the random position
                dc.DrawImage(banditImage, new Rect(x, y, banditImage.Width, banditImage.Height));
                Point banditPosition = new Point(x, y);

                // Generate random positions for the crosshair images within the bounds of the bandit image
                for (int i = 0; i < 5; i++)
                {
                    x = rnd.Next(0, (int)(banditImage.Width*0.45));
                    y = rnd.Next(0, (int)(banditImage.Height*0.7));
                    dc.DrawImage(crosshairImage, new Rect(x + banditPosition.X + 50, y + banditPosition.Y, crosshairImage.Width * 0.25, crosshairImage.Height * 0.25));
                }
            
        }


    }
}
