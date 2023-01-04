using GUI_2022_23_01_AS4DD4.Logic;
using GUI_2022_23_01_AS4DD4.Logic.Classes;
using GUI_2022_23_01_AS4DD4.Logic.Interfaces;
using GUI_2022_23_01_AS4DD4.Windows;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Path = System.IO.Path;

namespace GUI_2022_23_01_AS4DD4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public IShopLogic logic;

        //public Brush BackgroundBrush
        //{
        //    get
        //    {
        //        return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "Background"), UriKind.RelativeOrAbsolute)));
        //        //return new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/;component/Images/Background.jpg"), UriKind.RelativeOrAbsolute));
        //    }
        //}

        public MainWindow()
        {
            InitializeComponent();
            //logic = new ShopLogic();
            //logic.LoadAssets();         //lehet, hogy itt nincs is rá szükség
            SetBackground();
        }
        //private void Dt_Tick(object? sender, EventArgs e)       //a GameWindowban fog kelleni
        //{
        //    logic.TimeStep();
        //}



        private void SetBackground()
        {
            ImageBrush myBrush = new ImageBrush(new BitmapImage(new Uri(Path.Combine(@"..\..\..\Images", "Background.jpg"), UriKind.RelativeOrAbsolute)));

            grid.Background = myBrush;
        }

        private void Window_Loaded(object? sender, EventArgs e)
        {
            ////logic.GameOver += Logic_GameOver;
            ////display.SetupModel(logic);

            //DispatcherTimer dt = new DispatcherTimer();
            //dt.Interval = TimeSpan.FromMilliseconds(100);
            //dt.Tick += Dt_Tick;
            //dt.Start();

            display.SetupSizes(new Size(grid.ActualWidth, grid.ActualHeight));
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
            if (grid.ActualWidth > 0 && grid.ActualHeight > 0)
            {
                display.Resize(new Size()
                {
                    Width = grid.ActualWidth,
                    Height = grid.ActualHeight
                });
            }

        }

        private void load_Click(object sender, RoutedEventArgs e)
        {
            //logic.LoadPlayer("Barna");//TODO change this to read string from GUI
            GameWindow gw = new GameWindow();
            gw.Show();
        }
        private void create_Click(object sender, RoutedEventArgs e)
        {
            GameWindow gw = new GameWindow();            
            gw.Show();
            gw.ContentRendered += Window_Loaded;
        }


        private void shop_Click(object sender, RoutedEventArgs e)
        {
            ShopWindow sw = new ShopWindow();
            sw.Show();
        }
        private void save_Click(object sender, RoutedEventArgs e)
        {
            //logic.SavePlayer(logic.player);

        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


    }
}
