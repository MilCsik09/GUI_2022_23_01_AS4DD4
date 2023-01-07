using GUI_2022_23_01_AS4DD4.Logic.Classes;
using GUI_2022_23_01_AS4DD4.Models;
using GUI_2022_23_01_AS4DD4.WPF.Viewmodels;
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
    /// Interaction logic for CreateWindow.xaml
    /// </summary>
    public partial class CreateWindow : Window
    {
        LoadLogic logic = new LoadLogic();
        public CreateWindow()
        {
            InitializeComponent();
            var vm = new CreateWindowViewModel();
            //vm.Setup();
            this.DataContext = vm;
        }

        private void Vm_EditedDone(object? sender, EventArgs e)
        {
            this.DialogResult = true;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Window current = Application.Current.MainWindow;
            Player newPlayer = new Player();
            if(nameTextBox.Text == "")
            {
                newPlayer.Name = "Anonymus";
            }
            else 
            {
                newPlayer.Name = nameTextBox.Text;
            }
            
            nameTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            MainWindow mw = new MainWindow(newPlayer);
            current.Close();
            App.Current.MainWindow = mw;
            mw.Show();
            logic.SavePlayer(newPlayer);




            this.DialogResult = true;
        }
    }
}
