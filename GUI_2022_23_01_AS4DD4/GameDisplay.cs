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
using static System.Net.Mime.MediaTypeNames;
using GUI_2022_23_01_AS4DD4.Logic.Classes;
using System.Security.Cryptography.X509Certificates;

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
            dc.DrawRectangle(SignBrush, null, new Rect( size.Width-100, size.Height-100, size.Width/4, size.Height/4 ));  
        }

        public List<Point> crosshairPositions = new List<Point>();
        public Point banditPosition;
        public BitmapImage banditImage;
        public BitmapImage crosshairImage = new BitmapImage(new Uri(Path.Combine(@"..\..\..\Images", "Crosshair.png"), UriKind.RelativeOrAbsolute));
        public int crosshairNum;
        bool drawn = false;
        public bool gameover = false;
        bool isRunning = false;
        int maxTime = MainWindow.Player.TimeToShoot;
        int timeToShoot;
        public int moneyEarned = 0;
        public int healRemaining = 1;
        public int enemyKilled = 0;
        int maxCross = 3;

        public void StartGame(DrawingContext dc)
        {
            isRunning = true;
            FormattedText startText = new FormattedText("Press ENTER to Start!",
                                                CultureInfo.CurrentCulture,
                                                FlowDirection.LeftToRight,
                                                new Typeface("Arial"),
                                                72,
                                                Brushes.Red);
            dc.DrawText(startText, new Point(GameWindow.Grid.ActualWidth / 2 - startText.Width / 2, GameWindow.Grid.ActualHeight / 4 - startText.Height / 4));

            if (MainWindow.Player.Armor != null)
            {
                MainWindow.Player.Health += MainWindow.Player.Armor.Protection;
            }
            
        }

        public void GenerateEnemy(DrawingContext dc)
        {
                GameWindow.dt.Stop();
                timeToShoot = maxTime;
                GameWindow.dt.Start();

            Random rnd = new Random();
            int enemyRnd = rnd.Next(0, 100);
            if(0<=enemyRnd && enemyRnd < 70)
            {
                banditImage = new BitmapImage(new Uri(Path.Combine(@"..\..\..\Images", "Bandit.png"), UriKind.RelativeOrAbsolute));
            }
            else if(70 <= enemyRnd && enemyRnd <= 80)
            {
                banditImage = new BitmapImage(new Uri(Path.Combine(@"..\..\..\Images", "FKF.png"), UriKind.RelativeOrAbsolute));
            }
            else if (80 <= enemyRnd && enemyRnd <= 90)
            {
                banditImage = new BitmapImage(new Uri(Path.Combine(@"..\..\..\Images", "Policeman.png"), UriKind.RelativeOrAbsolute));
            }
            else
            {
                banditImage = new BitmapImage(new Uri(Path.Combine(@"..\..\..\Images", "Soldier.png"), UriKind.RelativeOrAbsolute));
            }

                crosshairNum = rnd.Next(1, maxCross);
            double x = rnd.Next(0, (int)(GameWindow.Grid.ActualWidth - (banditImage.Width)));
            double y = rnd.Next(0, (int)(GameWindow.Grid.ActualHeight - (banditImage.Height)));


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

            dc.DrawText(hp, new Point(10, GameWindow.Grid.ActualHeight - hp.Height - 10));

        }

        public void TimeDisplay(DrawingContext dc)
        {
            FormattedText time = new FormattedText("Time:" + timeToShoot,
                                                CultureInfo.CurrentCulture,
                                                FlowDirection.LeftToRight,
                                                new Typeface("Arial"),
                                                36,
                                                Brushes.Red);

            dc.DrawText(time, new Point((GameWindow.Grid.ActualWidth - time.Width) / 2, 10));

        }

        public void MoneyEarnedDisplay(DrawingContext dc)
        {
            FormattedText moneyText = new FormattedText("Money Earned:" + moneyEarned,
                                                CultureInfo.CurrentCulture,
                                                FlowDirection.LeftToRight,
                                                new Typeface("Arial"),
                                                36,
                                                Brushes.Red);

            dc.DrawText(moneyText, new Point(10,10));
        }

        public void EnemyDisplay(DrawingContext dc)
        {
            FormattedText enemyText = new FormattedText("Enemy Killed:" + enemyKilled,
                                                CultureInfo.CurrentCulture,
                                                FlowDirection.LeftToRight,
                                                new Typeface("Arial"),
                                                36,
                                                Brushes.Red);

            dc.DrawText(enemyText, new Point(GameWindow.Grid.ActualWidth - enemyText.Width - 10, 10));

        }

        public void AmmoDisplay(DrawingContext dc)
        {
            if(MainWindow.Player.Ammo == null)
            {
                FormattedText ammoText = new FormattedText("Ammo: " + 0,
                                                CultureInfo.CurrentCulture,
                                                FlowDirection.LeftToRight,
                                                new Typeface("Arial"),
                                                36,
                Brushes.Red);

                dc.DrawText(ammoText, new Point(GameWindow.Grid.ActualWidth - ammoText.Width - 10, GameWindow.Grid.ActualHeight - ammoText.Height - 10));
            }
            else
            {
                FormattedText ammoText = new FormattedText("Ammo: " + MainWindow.Player.Ammo.Number,
                                                CultureInfo.CurrentCulture,
                                                FlowDirection.LeftToRight,
                                                new Typeface("Arial"),
                                                36,
                                                Brushes.Red);

                dc.DrawText(ammoText, new Point(GameWindow.Grid.ActualWidth - ammoText.Width - 10, GameWindow.Grid.ActualHeight - ammoText.Height - 10));
            }
            
        }

        public void PotionDisplay(DrawingContext dc)
        {            
            if(healRemaining > 0)
            {
                dc.DrawRectangle(PotionBrush, null, new Rect(new Point(GameWindow.Grid.ActualWidth / 2 - 75, GameWindow.Grid.ActualHeight - 150 - 10), new Size(150, 150)));

            }
        }

        public void Timer(object sender, EventArgs e)
        {
            timeToShoot -= 1;
            if(timeToShoot == 0)
            {
                if(MainWindow.Player.Armor != null)
                {
                    MainWindow.Player.Health -= (int)(20 * MainWindow.Player.Armor.DamageReducton);
                }
                else
                {
                    MainWindow.Player.Health -= (20);
                }
                if(maxTime < 5)
                {
                    maxTime = 5;
                }
                timeToShoot = maxTime;
            }else if(MainWindow.Player.Health <= 0)
            {
                gameover = true;
                isRunning = false;
            }
            InvalidateVisual();
        }

        bool doubleRenderProtection = false;

        protected override void OnRender(DrawingContext dc)
        {
            if (doubleRenderProtection)
            {
                if (!drawn && !isRunning && !gameover)
                {
                    StartGame(dc);
                    PlayerHealthDisplay(dc);
                    AmmoDisplay(dc);
                    if (MainWindow.Player.Potion != null)
                    {
                        healRemaining = 1;
                    }
                    else
                    {
                        healRemaining = 0;
                    }
                }
                else if (!drawn && isRunning && !gameover)
                {
                    GenerateEnemy(dc);
                    PlayerHealthDisplay(dc);
                    TimeDisplay(dc);
                    MoneyEarnedDisplay(dc);
                    AmmoDisplay(dc);
                    PotionDisplay(dc);
                    EnemyDisplay(dc);
                }
                else if (crosshairPositions.Count != 0 && !gameover)
                {
                    dc.DrawImage(banditImage, new Rect(banditPosition.X, banditPosition.Y, banditImage.Width, banditImage.Height));
                    for (int i = 0; i < crosshairPositions.Count; i++)
                    {
                        Point crosshairPosition = crosshairPositions[i];
                        dc.DrawImage(crosshairImage, new Rect(crosshairPosition.X, crosshairPosition.Y, crosshairImage.Width * 0.25, crosshairImage.Height * 0.25));
                    }
                    PlayerHealthDisplay(dc);
                    TimeDisplay(dc);
                    MoneyEarnedDisplay(dc);
                    AmmoDisplay(dc);
                    PotionDisplay(dc);
                    EnemyDisplay(dc);
                }
                else if (!gameover)
                {

                    drawn = false;
                    enemyKilled++;
                    maxCross++;
                    if(enemyKilled % 10 == 0) 
                    {
                        if(maxTime > 1)
                        {
                            maxTime -= 1;

                        }                        
                    }
                    GenerateEnemy(dc);
                    PlayerHealthDisplay(dc);
                    TimeDisplay(dc);
                    moneyEarned += 10;
                    MoneyEarnedDisplay(dc);
                    AmmoDisplay(dc);
                    EnemyDisplay(dc);
                    PotionDisplay(dc);
                    MainWindow.Player.Money += 10;
                    

                }
                else
                {
                    GameWindow.dt.Stop();
                    isRunning = false;
                    MainWindow.Player.TimeToShoot = 5;
                    MainWindow.Highscores.Add(new Models.HighscoreEntry(MainWindow.Player.Name, enemyKilled, DateTime.Now.ToString("yyyy.MM.dd.\tHH:mm ")));
                    LoadLogic.SaveHighscore(MainWindow.Highscores);
                    FormattedText gameOverText = new FormattedText("Game Over \nPress ESC to Exit!\nYou killed: " + enemyKilled + " enemy\nYou earned: " + moneyEarned + " money.",
                                                        CultureInfo.CurrentCulture,
                                                        FlowDirection.LeftToRight,
                                                        new Typeface("Arial"),
                                                        72,
                                                        Brushes.Red);
                    dc.DrawText(gameOverText, new Point(GameWindow.Grid.ActualWidth / 2 - gameOverText.Width / 2, GameWindow.Grid.ActualHeight / 2 - gameOverText.Height / 2));
                }
            }
            if (!doubleRenderProtection)
            {
                doubleRenderProtection = true;
            }            

        }


    }
}
