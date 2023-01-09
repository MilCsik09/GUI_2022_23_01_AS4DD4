using GUI_2022_23_01_AS4DD4.Logic;
using GUI_2022_23_01_AS4DD4.Logic.Classes;
using GUI_2022_23_01_AS4DD4.Logic.Interfaces;
using GUI_2022_23_01_AS4DD4.Models;
using GUI_2022_23_01_AS4DD4.Windows;
using GUI_2022_23_01_AS4DD4.WPF.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private static List<HighscoreEntry> highscores = LoadLogic.LoadHighscore();

        public static List<HighscoreEntry> Highscores
        {
            get { return highscores; }
            set { highscores = value; }
        }


        private Player player;

       public static Player Player
        {
            get { return ((MainWindow)Application.Current.MainWindow).player; }
            set { ((MainWindow)Application.Current.MainWindow).player = value; }
        }

        public MainWindow(Player player)
        {
            InitializeComponent();
            this.player = player;
            SetBackground();
        }

        private void SetBackground()
        {
            ImageBrush myBrush = new ImageBrush(new BitmapImage(new Uri(Path.Combine(@"..\..\..\Images", "Background.jpg"), UriKind.RelativeOrAbsolute)));

            grid.Background = myBrush;
        }

        private void load_Click(object sender, RoutedEventArgs e)
        {

            Window current = Application.Current.MainWindow;
            LoadWindow lw = new LoadWindow();
            current.Close();            
            App.Current.MainWindow = lw;
            lw.Show();

            
            
        }
        private void create_Click(object sender, RoutedEventArgs e)
        {
            LoadLogic ll = new LoadLogic();
            MainWindow.Player = ll.LoadPlayer(player.Name);
            GameWindow gw = new GameWindow();            
            gw.Show();            
        }


        private void shop_Click(object sender, RoutedEventArgs e)
        {
            ShopWindow sw = new ShopWindow();
            sw.Show();
        }
        private void save_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("AUTOSAVE ALREADY ENABLED! YOU CAN'T TURN IT OFF!", ":)", MessageBoxButton.OK);
            
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {            
            Close();
        }

        private void highscore_Click(object sender, RoutedEventArgs e)
        {
            HighscoreWindow hw = new HighscoreWindow();
            hw.Show();
        }
    }
}
