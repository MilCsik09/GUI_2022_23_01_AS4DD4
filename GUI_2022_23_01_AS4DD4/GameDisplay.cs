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
        public int crosshairNum;
        bool drawn = false;
        public bool gameover = false;
        bool isRunning = false;
        int maxTime = 7;
        int timeToShoot;
        public int moneyEarned = 0;

        public void StartGame(DrawingContext dc)
        {
            isRunning = true;
            FormattedText startText = new FormattedText("Press ENTER to Start!",
                                                CultureInfo.CurrentCulture,
                                                FlowDirection.LeftToRight,
                                                new Typeface("Arial"),
                                                136,
                                                Brushes.Red);

            dc.DrawText(startText, new Point(GameWindow.Grid.ActualWidth / 4 - startText.Width / 4, GameWindow.Grid.ActualHeight / 4 - startText.Height / 4));
        }

        public void GenerateEnemy(DrawingContext dc)
        {
            GameWindow.dt.Stop();            
            timeToShoot = maxTime;
            GameWindow.dt.Start();

            Random rnd = new Random();
            crosshairNum = rnd.Next(1, 10);
            double x = rnd.Next(0, (int)(GameWindow.Grid.ActualWidth - (banditImage.Width * 1.3)));
            double y = rnd.Next(0, (int)(GameWindow.Grid.ActualHeight - (banditImage.Height * 1.3)));


            dc.DrawImage(banditImage, new Rect(x, y, banditImage.Width, banditImage.Height));
            banditPosition = new Point(x, y);


            for (int i = 0; i < crosshairNum; i++)
            {
                x = rnd.Next(0, (int)(banditImage.Width * 0.45));
                y = rnd.Next(0, (int)(banditImage.Height * 0.7));
                Point crosshairPosition = new Point(x + banditPosition.X + 50, y + banditPosition.Y);                
                crosshairPositions.Add(crosshairPosition);
                dc.DrawImage(crosshairImage, new Rect(crosshairPosition.X, crosshairPosition.Y, crosshairImage.Width * 0.25, crosshairImage.Height * 0.25));
            }
            drawn = true;
        }

        public void PlayerHealthDisplay(DrawingContext dc)
        {
            FormattedText hp = new FormattedText("Health:" + MainWindow.Player.Health,
                                                CultureInfo.CurrentCulture,
                                                FlowDirection.LeftToRight,
                                                new Typeface("Arial"),
                                                36,
                                                Brushes.Red);

            dc.DrawText(hp, new Point(0,0));

        }

        public void TimeDisplay(DrawingContext dc)
        {
            FormattedText time = new FormattedText("Time:" + timeToShoot,
                                                CultureInfo.CurrentCulture,
                                                FlowDirection.LeftToRight,
                                                new Typeface("Arial"),
                                                36,
                                                Brushes.Red);

            dc.DrawText(time, new Point(720, 0));

        }

        public void MoneyEarnedDisplay(DrawingContext dc)
        {
            isRunning = true;
            FormattedText moneyText = new FormattedText("Money Earned:" + moneyEarned,
                                                CultureInfo.CurrentCulture,
                                                FlowDirection.LeftToRight,
                                                new Typeface("Arial"),
                                                36,
                                                Brushes.Red);

            dc.DrawText(moneyText, new Point(0,720));
        }

        public void AmmoDisplay(DrawingContext dc)
        {
            isRunning = true;
            FormattedText ammoText = new FormattedText("Ammo: " + MainWindow.Player.Ammo.Number,
                                                CultureInfo.CurrentCulture,
                                                FlowDirection.LeftToRight,
                                                new Typeface("Arial"),
                                                36,
                                                Brushes.Red);

            dc.DrawText(ammoText, new Point(720, 720));
        }


        public void Timer(object sender, EventArgs e)
        {
            timeToShoot -= 1;
            if(timeToShoot == 0)
            {
                MainWindow.Player.Health -= (int)(20 * MainWindow.Player.Armor.DamageReducton);
                timeToShoot = maxTime;
            }
            InvalidateVisual();
        }

        protected override void OnRender(DrawingContext dc)
        {
            if (!drawn && !isRunning && !gameover)
            {
                StartGame(dc);
                PlayerHealthDisplay(dc);
                AmmoDisplay(dc);
            }
            else if (!drawn && isRunning && !gameover)
            {
                GenerateEnemy(dc);
                PlayerHealthDisplay(dc);
                TimeDisplay(dc);
                MoneyEarnedDisplay(dc);
                AmmoDisplay(dc);
            }
            else if (crosshairPositions.Count != 0 && !gameover)
            {
                dc.DrawImage(banditImage, new Rect(banditPosition.X, banditPosition.Y, banditImage.Width, banditImage.Height));
                for (int i = 0; i<crosshairPositions.Count; i++)
                {
                    Point crosshairPosition = crosshairPositions[i];
                    dc.DrawImage(crosshairImage, new Rect(crosshairPosition.X, crosshairPosition.Y, crosshairImage.Width * 0.25, crosshairImage.Height * 0.25));
                }
                PlayerHealthDisplay(dc);
                TimeDisplay(dc);
                MoneyEarnedDisplay(dc);
                AmmoDisplay(dc);
            }
            else if(!gameover)
            {

                drawn = false;
                GenerateEnemy(dc);
                PlayerHealthDisplay(dc);
                TimeDisplay(dc);
                moneyEarned += 10;
                MoneyEarnedDisplay(dc);
                AmmoDisplay(dc);
                MainWindow.Player.Money += 10;

            }
            else
            {
                isRunning = false;
                FormattedText gameOverText = new FormattedText("Game Over \nPress ESC to Exit!",
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
