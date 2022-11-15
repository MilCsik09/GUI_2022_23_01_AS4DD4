using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_2022_23_01_AS4DD4.Models
{
    internal class Player
    {
        public int Health { get; set; }
        public string Name { get; set; }
        public int Level { get; set; } = 1;
        public int Experience { get; set; } = 0;
        public int ExperienceNeeded { get; set; } = 400;

        public Weapon Weapon { get; set; }
        
        public List<Potion> Potions { get; set; }

        public Ammo Ammo { get; set; }
        public Armor Armor { get; set; }
        



    }
}
