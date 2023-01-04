using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GUI_2022_23_01_AS4DD4.Models
{
    public class Player : ObservableObject
    {


        public int Health { get; set; }
        public string Name { get; set; }
        public Level Level { get; set; }
        public int Experience { get; set; } = 0;
        public int ExperienceNeeded { get; set; } = 400;

        public Weapon Weapon { get; set; }
        
        public List<Potion> Potions { get; set; }
        public Ammo Ammo { get; set; }
        public Armor Armor { get; set; }
        private int money;
        public int Money
        {
            get { return money; }
            set { SetProperty(ref money, value); }
        }

        public int TimeToShoot { get; set; } = 10;


        //public Player(int health, string name, Level level, int experience, int experienceNeeded, Weapon weapon, List<Potion> potions, Ammo ammo, Armor armor, int money)
        //{
        //    Health = health;
        //    Name = name;
        //    Level = level;
        //    Experience = experience;
        //    ExperienceNeeded = experienceNeeded;
        //    Weapon = weapon;
        //    Potions = potions;
        //    Ammo = ammo;
        //    Armor = armor;
        //    Money = money;
        //}

        public Player()
        {

        }


    }
}
