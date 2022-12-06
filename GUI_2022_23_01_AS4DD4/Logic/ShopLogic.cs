using GUI_2022_23_01_AS4DD4.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GUI_2022_23_01_AS4DD4.Logic
{
    public class ShopLogic
    {
        public Player? player;
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

        //ammo
        public void BuyAmmo(Ammo ammo)
        {
            if (player.Money >= ammo.Price)
            {
                player.Ammo = ammo;
            }

        }

        public void SellAmmo(Ammo ammo)
        {
            player.Money += (int)(0.8 * ammo.Price);
            player.Ammo = null;
        }

        //armor
        public void BuyArmor(Armor armor)
        {
            if (player.Money >= armor.Price)
            {
                player.Armor = armor;
            }
        }

        public void SellArmor(Armor armor)
        {
            player.Money += (int)(0.8 * armor.Price);
            player.Armor = null;
        }

        //potion
        public void BuyPotion(Potion potion)
        {
            if (player.Money >= potion.Price)
            {
                player.Potions.Add(potion);
            }
        }

        public void SellPotion(Potion potion)
        {
            player.Money += (int)(0.8 * potion.Price);
            player.Potions.Remove(potion);
        }

        //weapon
        public void BuyWeapon(Weapon weapon)
        {
            if (player.Money >= weapon.Price)
            {
                player.Weapon = weapon;
            }
        }

        public void SellWeapon(Weapon weapon)
        {
            player.Money += (int)(0.8 * weapon.Price);
            player.Weapon = null;
        }

    }
}
