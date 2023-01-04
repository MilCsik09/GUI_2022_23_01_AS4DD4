using GUI_2022_23_01_AS4DD4.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GUI_2022_23_01_AS4DD4.Logic.Classes
{
    public class ShopLogic
    {
        public Player? player = new Player();
        public List<Ammo>? AmmoList = new List<Ammo>();
        public List<Armor>? ArmorList = new List<Armor>();
        public List<Potion>? PotionList = new List<Potion>();
        public List<Weapon>? WeaponList = new List<Weapon>();

        public ShopLogic()
        {
            LoadAssets();
            //LoadPlayer(player.Name);
        }



        public void LoadAssets()
        {
            AmmoList =
                JsonSerializer.Deserialize<List<Ammo>>(File.ReadAllText(Path.Combine(@"..\..\..\Data\Ammos", "ammos.json")));
            ArmorList =
                JsonSerializer.Deserialize<List<Armor>>(File.ReadAllText(Path.Combine(@"..\..\..\Data\Armors", "armors.json")));
            PotionList =
                JsonSerializer.Deserialize<List<Potion>>(File.ReadAllText(Path.Combine(@"..\..\..\Data\Potions", "potions.json")));
            WeaponList =
                JsonSerializer.Deserialize<List<Weapon>>(File.ReadAllText(Path.Combine(@"..\..\..\Data\Weapons", "weapons.json")));
        }

        public void LoadPlayer(string playerName)
        {

            string fileName = playerName + ".json";
            string path = Path.Combine(@"..\..\..\Data\Players", fileName);

            player =
                JsonSerializer.Deserialize<Player>(File.ReadAllText(path));
        }

        public void SavePlayer(Player player)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(player, options);
            string fileName = player.Name + ".json";
            string path = Path.Combine(@"..\..\..\Data\Players", fileName);
            File.WriteAllText(path, jsonString);
        }

        //ammo
        public void BuyAmmo(Ammo ammo)
        {
            if (player.Money >= ammo.Price)
            {
                player.Ammo = ammo;
                player.Money -= ammo.Price;
                SavePlayer(player);
                //LoadPlayer(player.Name);
            }

        }

        public void SellAmmo(Ammo ammo)
        {
            if (ammo != null)
            {
                player.Money += (int)(0.8 * ammo.Price);
                player.Ammo = null;
                SavePlayer(player);
            }
        }

        //armor
        public void BuyArmor(Armor armor)
        {
            if (player.Money >= armor.Price)
            {
                player.Armor = armor;
                player.Money -= armor.Price;
                SavePlayer(player);
            }
        }

        public void SellArmor(Armor armor)
        {
            if (armor != null)
            {
                player.Money += (int)(0.8 * armor.Price);
                player.Armor = null;
                SavePlayer(player);
            }
        }

        //potion
        public void BuyPotion(Potion potion)
        {
            if (player.Money >= potion.Price)
            {
                player.Potions.Add(potion);
                player.Money -= potion.Price;
                SavePlayer(player);
            }
        }

        public void SellPotion(Potion potion)
        {
            if (potion != null)
            {
                player.Money += (int)(0.8 * potion.Price);
                player.Potions.Remove(potion);
                SavePlayer(player);
            }
        }

        //weapon
        public void BuyWeapon(Weapon weapon)
        {
            if (player.Money >= weapon.Price)
            {
                player.Weapon = weapon;
                player.Money -= weapon.Price;
                SavePlayer(player);
            }
        }

        public void SellWeapon(Weapon weapon)
        {
            if (weapon != null)
            {
                player.Money += (int)(0.8 * weapon.Price);
                player.Weapon = null;
                SavePlayer(player);
            }
        }

    }
}
