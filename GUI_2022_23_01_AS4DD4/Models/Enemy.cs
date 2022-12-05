using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Point = System.Drawing.Point;
using Size = System.Windows.Size;
using System.Text.Json.Serialization;

namespace GUI_2022_23_01_AS4DD4.Models
{
    public class Enemy
    {


        public string Name { get; set; }
        public int Health { get; set; }
        public int DamageToPlayer { get; set; }
        [JsonIgnore]
        public Point Position { get; set; } //nem toltjuk be ezt meg majd random legeneraljuk
        public Size Size { get; set; }
        [JsonIgnore]
        public List<CrossHair> CrossHairs { get; set; } //nem toltjuk be majd kesobb random legeneraljuk
        public int XPGiven { get; set; }
        public int MoneyGiven { get; set; }

        public Enemy()
        {

        }

        public Enemy(string name, int health, int damageToPlayer, Size size, int xPGiven, int moneyGiven)
        {
            Name = name;
            Health = health;
            DamageToPlayer = damageToPlayer;
            Size = size;
            XPGiven = xPGiven;
            MoneyGiven = moneyGiven;
        }
    }
}
