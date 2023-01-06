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
using GUI_2022_23_01_AS4DD4.WPF;

namespace GUI_2022_23_01_AS4DD4.Windows
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        //Display display = new Display();

        //GameDisplay display = new GameDisplay();          //xaml-ben beállítva

        public GameWindow()
        {
            InitializeComponent();
            
            //grid.Background = display.BackgroundBrush;
            //display.DrawSign(grid);
            //display.DrawEnemy();



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

         



    }
}
