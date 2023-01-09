using GUI_2022_23_01_AS4DD4.Logic.Classes;
using GUI_2022_23_01_AS4DD4.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for HighscoreWindow.xaml
    /// </summary>
    public partial class HighscoreWindow : Window
    {
        static List<HighscoreEntry> highscores = LoadLogic.LoadHighscore();
        static ObservableCollection<HighscoreEntry> highscoresObservableCollection = new ObservableCollection<HighscoreEntry>(highscores);


        public HighscoreWindow()
        {
            InitializeComponent();
            
        }


    }
}
