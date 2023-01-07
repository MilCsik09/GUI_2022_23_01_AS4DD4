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

namespace GUI_2022_23_01_AS4DD4.WPF.Windows
{
    /// <summary>
    /// Interaction logic for LoadWindow.xaml
    /// </summary>
    public partial class LoadWindow : Window
    {

        
        public LoadWindow()
        {
            InitializeComponent();
        }

        private void create_Click(object sender, RoutedEventArgs e)
        {
            CreateWindow cw = new CreateWindow();
            cw.ShowDialog();
        }





        //private void Window_Loaded(object? sender, EventArgs e)
        //{

        //    display.SetupSizes(new Size(grid.ActualWidth, grid.ActualHeight));

        //}

        //public void SetupSizes(Size size)
        //{
        //    this.size = size;
        //    this.InvalidateVisual();

        //}

        //public void Resize(Size size)
        //{
        //    this.size = size;
        //    InvalidateVisual();
        //}

        //private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        //{
        //    if (grid.ActualWidth > 0 && grid.ActualHeight > 0)
        //    {
        //        display.Resize(new Size()
        //        {
        //            Width = grid.ActualWidth,
        //            Height = grid.ActualHeight
        //        });
        //    }

        //}
    }
}
