using GUI_2022_23_01_AS4DD4.Logic.Classes;
using GUI_2022_23_01_AS4DD4.Models;
using GUI_2022_23_01_AS4DD4.WPF.Viewmodels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Path = System.IO.Path;

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
            this.DataContext = vm;
        }

        private void Vm_EditedDone(object? sender, EventArgs e)
        {
            this.DialogResult = true;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string path = Path.Combine(@"..\..\..\Data\Levels", "levels.json");
            List<Level> levels;
            levels = JsonSerializer.Deserialize<Level[]>(File.ReadAllText(path)).ToList<Level>();

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

            newPlayer.Level = levels[0];

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
