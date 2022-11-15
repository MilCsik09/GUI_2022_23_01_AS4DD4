using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_2022_23_01_AS4DD4.Models
{
    internal class Enemy
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int DamageToPlayer { get; set; }
        public int[,] Position { get; set; }
        public List<CrossHair> CrossHairs { get; set; }
    }
}
