using GUI_2022_23_01_AS4DD4.Logic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace GUI_2022_23_01_AS4DD4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ShooterLogic logic;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Dt_Tick(object? sender, EventArgs e)
        {
            logic.TimeStep();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            logic = new ShooterLogic();
            logic.GameOver += Logic_GameOver;
            display.SetupModel(logic);

            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromMilliseconds(100);
            dt.Tick += Dt_Tick;
            dt.Start();

            display.SetupSizes(new Size(grid.ActualWidth, grid.ActualHeight));
            logic.SetupSizes((new System.Windows.Size((int)grid.ActualWidth, (int)grid.ActualHeight)));
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

        }
        private void create_Click(object sender, RoutedEventArgs e)
        {

        }

        private void shop_Click(object sender, RoutedEventArgs e)
        {

        }
        private void save_Click(object sender, RoutedEventArgs e)
        {

        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


    }
}
