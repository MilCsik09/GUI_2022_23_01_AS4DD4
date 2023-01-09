using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_2022_23_01_AS4DD4.Models
{
    public class HighscoreEntry
    {
        public string PlayerName { get; set; }
        public int EnemiesKilled { get; set; }
        public string Date { get; set; }

        public HighscoreEntry(string playerName, int enemiesKilled, string date)
        {
            PlayerName = playerName;
            EnemiesKilled = enemiesKilled;
            Date = date;
        }
    }
}
