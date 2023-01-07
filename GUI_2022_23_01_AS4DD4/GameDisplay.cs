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
using System.Windows.Input;
using System.Globalization;

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

        public List<Point> crosshairPositions = new List<Point>();
        public Point banditPosition;
        public BitmapImage banditImage = new BitmapImage(new Uri(Path.Combine(@"..\..\..\Images", "Bandit.png"), UriKind.RelativeOrAbsolute));
        public BitmapImage crosshairImage = new BitmapImage(new Uri(Path.Combine(@"..\..\..\Images", "Crosshair.png"), UriKind.RelativeOrAbsolute));
        bool drawn = false;
        bool gameover = false;


        public void GenerateEnemy(DrawingContext dc)
        {
            
            // Generate a random position for the bandit image within the bounds of the grid
            Random rnd = new Random();
            double x = rnd.Next(0, (int)(GameWindow.Grid.ActualWidth - (banditImage.Width * 1.3)));
            double y = rnd.Next(0, (int)(GameWindow.Grid.ActualHeight - (banditImage.Height * 1.3)));

            // Draw the bandit image at the random position
            dc.DrawImage(banditImage, new Rect(x, y, banditImage.Width, banditImage.Height));
            banditPosition = new Point(x, y);

            // Generate random positions for the crosshair images within the bounds of the bandit image
            for (int i = 0; i < 1; i++)
            {
                x = rnd.Next(0, (int)(banditImage.Width * 0.45));
                y = rnd.Next(0, (int)(banditImage.Height * 0.7));
                Point crosshairPosition = new Point(x + banditPosition.X + 50, y + banditPosition.Y);
                crosshairPositions.Add(crosshairPosition);
                dc.DrawImage(crosshairImage, new Rect(crosshairPosition.X, crosshairPosition.Y, crosshairImage.Width * 0.25, crosshairImage.Height * 0.25));
            }
            drawn = true;
        }
        

        protected override void OnRender(DrawingContext dc)
        {
            if (!drawn)
            {
                GenerateEnemy(dc);
            }
            else if (crosshairPositions.Count != 0)
            {
                dc.DrawImage(banditImage, new Rect(banditPosition.X, banditPosition.Y, banditImage.Width, banditImage.Height));
                for (int i = 0; i<crosshairPositions.Count; i++)
                {
                    Point crosshairPosition = crosshairPositions[i];
                    dc.DrawImage(crosshairImage, new Rect(crosshairPosition.X, crosshairPosition.Y, crosshairImage.Width * 0.25, crosshairImage.Height * 0.25));
                }
            }
            else
            {
                
                    gameover = true;
                    FormattedText gameOverText = new FormattedText("Game Over",
                                                        CultureInfo.CurrentCulture,
                                                        FlowDirection.LeftToRight,
                                                        new Typeface("Arial"),
                                                        136,
                                                        Brushes.Red);

                    dc.DrawText(gameOverText, new Point(GameWindow.Grid.ActualWidth / 4 - gameOverText.Width / 4, GameWindow.Grid.ActualHeight / 4 - gameOverText.Height / 4));
                
            }
            
            

        }

        



    }
}
