using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows;
using GUI_2022_23_01_AS4DD4.Models;
using System.IO;

namespace GUI_2022_23_01_AS4DD4
{
    class JSONConverter
    {

        public static List<Ammo> AmmoList = new List<Ammo>();
        public static List<Armor> ArmorList = new List<Armor>();
        public static List<Enemy> EnemyList = new List<Enemy>();
        public static List<Level> LevelList = new List<Level>();
        public static List<Potion> PotionList = new List<Potion>();
        public static List<Weapon> WeaponList = new List<Weapon>();


        static Armor armor = new Armor();
        static Enemy bandit = new Enemy();
        static Level level = new Level();
        static Player player = new Player();
        static Ammo standard = new Ammo();
        static Potion minor = new Potion();
        static Weapon pistol = new Weapon();
        
        public static void Convert()
        {
            armor.Name = "Light";
            armor.Protection = 10;
            armor.DamageReducton = 5;

            bandit.Name = "Bandit";
            bandit.Health = 100;
            bandit.DamageToPlayer = 12;
            bandit.Size = new Size(20, 20);
            bandit.XPGiven = 50;

            level.Enemy = new List<Enemy> { bandit, bandit };

            standard.Name = "Standard";
            standard.Damage = 5;
            standard.Number = 30;

            minor.Name = "Minor";
            minor.HealthRegeneration = 25;

            pistol.Name = "Pistol";
            pistol.BaseDamage = 20;


            player.Health = 100;
            player.Name = "Barna";
            player.Level = level;
            player.Experience = 0;
            player.ExperienceNeeded = 200;
            player.Weapon = pistol;
            player.Potions = new List<Potion> { minor, minor };
            player.Ammo = standard;
            player.Armor = armor;
            player.TimeToShoot = 20;

            AmmoList.Add(standard);
            ArmorList.Add(armor);
            EnemyList.Add(bandit);
            LevelList.Add(level);
            PotionList.Add(minor);
            WeaponList.Add(pistol);


            var options = new JsonSerializerOptions { WriteIndented = true };
            string playerJson = JsonSerializer.Serialize(player, options);
            string path = Path.Combine(@"..\..\..\Data\Players", player.Name + ".json");
            File.WriteAllText(path, playerJson);

            string armorJson = JsonSerializer.Serialize(ArmorList, options);
            string armorpath = Path.Combine(@"..\..\..\Data\Armors", "armors.json");
            File.WriteAllText(armorpath, armorJson);

            string banditJson = JsonSerializer.Serialize(EnemyList, options);
            string banditpath = Path.Combine(@"..\..\..\Data\Enemies", "enemies.json");
            File.WriteAllText(banditpath, banditJson);

            string levelJson = JsonSerializer.Serialize(LevelList, options);
            string levelpath = Path.Combine(@"..\..\..\Data\Levels", "levels.json");
            File.WriteAllText(levelpath, levelJson);

            string ammoJson = JsonSerializer.Serialize(AmmoList, options);
            string ammopath = Path.Combine(@"..\..\..\Data\Ammos", "ammos.json");
            File.WriteAllText(ammopath, ammoJson);

            string potionJson = JsonSerializer.Serialize(PotionList, options);
            string potionpath = Path.Combine(@"..\..\..\Data\Potions", "potions.json");
            File.WriteAllText(potionpath, potionJson);

            string weaponJson = JsonSerializer.Serialize(WeaponList, options);
            string weaponpath = Path.Combine(@"..\..\..\Data\Weapons", "weapons.json");
            File.WriteAllText(weaponpath, weaponJson);




        }
    }
}
