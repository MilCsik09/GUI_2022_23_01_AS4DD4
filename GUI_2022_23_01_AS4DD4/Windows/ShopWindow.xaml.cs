using GUI_2022_23_01_AS4DD4.Logic.Classes;
using GUI_2022_23_01_AS4DD4.Logic.Interfaces;
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

namespace GUI_2022_23_01_AS4DD4.Windows
{
    /// <summary>
    /// Interaction logic for ShopWindow.xaml
    /// </summary>
    public partial class ShopWindow : Window
    {
        public ShopWindow()
        {
            InitializeComponent();
        }

        private void SellPotion_Click(object sender, RoutedEventArgs e)
        {
            PlayerpotionsListBox.Items.Refresh();
        }

        private void BuyPotion_Click(object sender, RoutedEventArgs e)
        {
            PlayerpotionsListBox.Items.Refresh();
        }
    }
}
