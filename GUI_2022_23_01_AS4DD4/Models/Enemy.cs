using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Point = System.Drawing.Point;
using Size = System.Windows.Size;

namespace GUI_2022_23_01_AS4DD4.Models
{
    internal class Enemy
    {


        public string Name { get; set; }
        public int Health { get; set; }
        public int DamageToPlayer { get; set; }
        public Point Position { get; set; }
        public Size Size { get; set; }
        public List<CrossHair> CrossHairs { get; set; }
        public Enemy(string name, int health, int damageToPlayer, Point position, Size size, List<CrossHair> crossHairs)
        {
            Name = name;
            Health = health;
            DamageToPlayer = damageToPlayer;
            Position = position;
            Size = size;
            CrossHairs = crossHairs;
        }
        public Enemy()
        {

        }
    }
}
