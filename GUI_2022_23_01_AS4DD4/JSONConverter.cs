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

            var options = new JsonSerializerOptions { WriteIndented = true };
            string playerJson = JsonSerializer.Serialize(player, options);
            string path = Path.Combine(@"..\..\..\Data\Players", player.Name + ".json");
            File.WriteAllText(path, playerJson);

            string armorJson = JsonSerializer.Serialize(armor, options);
            string armorpath = Path.Combine(@"..\..\..\Data\Armors", armor.Name + ".json");
            File.WriteAllText(armorpath, armorJson);

            string banditJson = JsonSerializer.Serialize(bandit, options);
            string banditpath = Path.Combine(@"..\..\..\Data\Enemies", bandit.Name + ".json");
            File.WriteAllText(banditpath, banditJson);

            string levelJson = JsonSerializer.Serialize(level, options);
            string levelpath = Path.Combine(@"..\..\..\Data\Levels", "1.json");
            File.WriteAllText(levelpath, levelJson);

            string ammoJson = JsonSerializer.Serialize(standard, options);
            string ammopath = Path.Combine(@"..\..\..\Data\Ammos", standard.Name + ".json");
            File.WriteAllText(ammopath, ammoJson);

            string potionJson = JsonSerializer.Serialize(minor, options);
            string potionpath = Path.Combine(@"..\..\..\Data\Potions", minor.Name + ".json");
            File.WriteAllText(potionpath, potionJson);

            string weaponJson = JsonSerializer.Serialize(pistol, options);
            string weaponpath = Path.Combine(@"..\..\..\Data\Weapons", pistol.Name + ".json");
            File.WriteAllText(weaponpath, weaponJson);




        }
    }
}
