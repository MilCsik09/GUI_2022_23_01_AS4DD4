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
using GUI_2022_23_01_AS4DD4;
using GUI_2022_23_01_AS4DD4.Models;
using GUI_2022_23_01_AS4DD4.WPF;
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

        private void GameDisplay_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point mousePosition = e.GetPosition(display);

            for (int i = 0; i < display.crosshairPositions.Count; i++)
            {
                Point crosshairPosition = display.crosshairPositions[i];
                Rect crosshairBounds = new Rect(crosshairPosition.X, crosshairPosition.Y, display.crosshairImage.Width * 0.25, display.crosshairImage.Height * 0.25);
                if (crosshairBounds.Contains(mousePosition))
                {
                    display.crosshairPositions.RemoveAt(i);
                    break;
                }
            }

            // Invalidate the display to redraw it
            display.InvalidateVisual();
        }


        //Display display = new Display();

        //GameDisplay display = new GameDisplay();          //xaml-ben beállítva

        public GameWindow()
        {            
            InitializeComponent();
            SetBackground();


            //display.DrawSign(grid);
            //display.DrawEnemy();



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

            //DispatcherTimer dt = new DispatcherTimer();
            //dt.Interval = TimeSpan.FromMilliseconds(100);
            //dt.Tick += Dt_Tick;
            //dt.Start();
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
