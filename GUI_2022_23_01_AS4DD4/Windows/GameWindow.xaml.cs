using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using GUI_2022_23_01_AS4DD4;
using GUI_2022_23_01_AS4DD4.Logic.Classes;
using GUI_2022_23_01_AS4DD4.Models;
using GUI_2022_23_01_AS4DD4.WPF;
using GUI_2022_23_01_AS4DD4.WPF.Windows;
using Path = System.IO.Path;

namespace GUI_2022_23_01_AS4DD4.Windows
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        
        public static Grid Grid
        {
            get { return ((MainWindow)Application.Current.MainWindow).grid; }
            set { ((MainWindow)Application.Current.MainWindow).grid = value; }
        }
        public static DispatcherTimer dt { get; set; }

        public bool isRunning = false;
        

        private void GameDisplay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close();
                MainWindow.Player.Health = 100;
                LoadLogic ll = new LoadLogic();
                ll.SavePlayer(MainWindow.Player);
                dt.Stop();
            }
            else if (e.Key == Key.Enter && !isRunning)
            {
                dt = new DispatcherTimer();
                isRunning = true;
                display.InvalidateVisual();
                if (MainWindow.Player.Ammo == null)
                {
                    GameWindow.dt.Interval = TimeSpan.FromMilliseconds(100);
                }
                else
                {
                    dt.Interval = TimeSpan.FromMilliseconds(1000);
                }                
                dt.Tick += display.Timer;
                dt.Start();
            }else if(e.Key == Key.H && isRunning && display.healRemaining > 0)
            {
                display.healRemaining -= 1;
                MainWindow.Player.Health += MainWindow.Player.Potion.HealthRegeneration;
                MainWindow.Player.Potion = null;
                display.InvalidateVisual();
            }
        }

        private void GameDisplay_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (isRunning)
            {
                Point mousePosition = e.GetPosition(display);

                for (int i = 0; i < display.crosshairPositions.Count; i++)
                {
                    Point crosshairPosition = display.crosshairPositions[i];
                    Rect crosshairBounds = new Rect(crosshairPosition.X, crosshairPosition.Y, display.crosshairImage.Width * 0.25, display.crosshairImage.Height * 0.25);
                    if (crosshairBounds.Contains(mousePosition) && (MainWindow.Player.Ammo != null))
                    {
                        display.crosshairPositions.RemoveAt(i);
                        display.moneyEarned += 1;
                        MainWindow.Player.Money += 1;
                        MainWindow.Player.Ammo.Number -= 1;
                        break;
                    }
                    if((i == display.crosshairPositions.Count - 1) && (MainWindow.Player.Ammo != null))
                    {
                        if (MainWindow.Player.Armor != null)
                        {
                            MainWindow.Player.Health -= (int)(10 * MainWindow.Player.Armor.DamageReducton);
                        }
                        else
                        {
                            MainWindow.Player.Health -= (10);
                        }

                        MainWindow.Player.Ammo.Number -= 1;
                    }                                        
                }
                if (MainWindow.Player.Health <= 0)
                {
                    display.gameover = true;
                    isRunning = false;
                }
                if (MainWindow.Player.Ammo != null)
                {
                    if (MainWindow.Player.Ammo.Number <= 0)
                    {
                        MainWindow.Player.Ammo = null;
                        dt.Interval = TimeSpan.FromMilliseconds(100);
                    }
                }

                display.InvalidateVisual();
            }
            
        }


        public GameWindow()
        {            
            InitializeComponent();
            SetBackground();




        }
        private void SetBackground()
        {
            ImageBrush myBrush = new ImageBrush(new BitmapImage(new Uri(Path.Combine(@"..\..\..\Images", "Background.jpg"), UriKind.RelativeOrAbsolute)));

            this.Background = myBrush;
        }


        private void Window_Loaded(object? sender, EventArgs e)
        {
            ////logic.GameOver += Logic_GameOver;
            ////display.SetupModel(logic);

            
            //display.SetupSizes(new Size(grid.ActualWidth, grid.ActualHeight));
            //logic.SetupSizes((new System.Windows.Size((int)grid.ActualWidth, (int)grid.ActualHeight)));
        }
        private void Logic_GameOver(object? sender, EventArgs e)
        {
            var result = MessageBox.Show("Game over");
            if (result == MessageBoxResult.OK)
            {
                this.Close();
            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            /*if (grid.ActualWidth > 0 && grid.ActualHeight > 0)
            {
                display.Resize(new Size()
                {
                    Width = grid.ActualWidth,
                    Height = grid.ActualHeight
                });
            }*/

        }

        
    }
}
