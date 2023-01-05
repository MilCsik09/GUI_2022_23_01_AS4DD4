using GUI_2022_23_01_AS4DD4.Logic.Interfaces;
using GUI_2022_23_01_AS4DD4.Models;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GUI_2022_23_01_AS4DD4.Logic.Classes
{
    public class ShopLogic : IShopLogic
    {
        IMessenger messenger;
        public Player? player = new Player();
        public List<Ammo>? ammoList = new List<Ammo>();
        public List<Armor>? armorList = new List<Armor>();
        public List<Potion>? potionList = new List<Potion>();
        public List<Weapon>? weaponList = new List<Weapon>();

        public Player Player 
        { 
            get => player; 
            set => player = value; 
        }


        public List<Ammo> AmmoList
        {
            get => ammoList;
            set => ammoList = value;
        }

        public List<Armor> ArmorList
        {
            get => armorList;
            set => armorList = value;
        }

        public List<Potion> PotionList
        {
            get => potionList;
            set => potionList = value;
        }

        public List<Weapon> WeaponList
        {
            get => weaponList;
            set => weaponList = value;
        }

        public ShopLogic(IMessenger messenger)
        {
            this.messenger = messenger;
            LoadAssets();
            //LoadPlayer(player.Name);
        }


        //for UI update
        public int GetMoney
        {
            get
            {
                return Player.Money;
            }
        }
        public Ammo GetCurrentAmmo
        {
            get
            {
                return Player.Ammo;
            }
        }
        public Armor GetCurrentArmor
        {
            get
            {
                return Player.Armor;
            }
        }
        public Potion GetCurrentPotion
        {
            get
            {
                return Player.Potion;
            }
        }
        //public List<Potion> GetCurrentPotions
        //{
        //    get
        //    {
        //        return Player.Potions;
        //    }
        //}
        public Weapon GetCurrentWeapon
        {
            get
            {
                return Player.Weapon;
            }
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
                messenger.Send("Ammo bought", "ShopInfo");
                SavePlayer(player);
                //LoadPlayer(player.Name);
            }

        }

        public void SellAmmo()
        {
            if (player.Ammo != null)
            {
                player.Money += (int)(0.8 * player.Ammo.Price);
                player.Ammo = null;
                messenger.Send("Ammo sold", "ShopInfo");
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
                messenger.Send("Armor bought", "ShopInfo");
                SavePlayer(player);
            }
        }

        public void SellArmor()
        {
            if (player.Armor != null)
            {
                player.Money += (int)(0.8 * player.Armor.Price);
                player.Armor = null;
                messenger.Send("Armor sold", "ShopInfo");
                SavePlayer(player);
            }
        }

        //potion
        public void BuyPotion(Potion potion)
        {
            if (player.Money >= potion.Price)
            {
                player.Potion = potion;
                player.Money -= potion.Price;
                messenger.Send("Potion bought", "ShopInfo");
                SavePlayer(player);
            }
        }

        public void SellPotion()
        {

            if (player.Potion != null)
            {
                player.Money += (int)(0.8 * player.Potion.Price);
                player.Potion = null;
                messenger.Send("Potion sold", "ShopInfo");
                SavePlayer(player);
            }

        }

        //public void BuyPotion(Potion potion)
        //{
        //    if (player.Money >= potion.Price)
        //    {
        //        player.Potions.Add(potion);
        //        player.Money -= potion.Price;
        //        messenger.Send("Potion bought", "ShopInfo");
        //        SavePlayer(player);
        //    }
        //}

        //public void SellPotion(Potion potionToSell)
        //{

        //    if (player.Potions.Contains(potionToSell) && player.Potions.Count > 0)
        //    {
        //        player.Money += (int)(0.8 * potionToSell.Price);
        //        player.Potions.Remove(potionToSell);
        //        messenger.Send("Potion sold", "ShopInfo");
        //        SavePlayer(player);
        //    }

        //}

        //weapon
        public void BuyWeapon(Weapon weapon)
        {
            if (player.Money >= weapon.Price)
            {
                player.Weapon = weapon;
                player.Money -= weapon.Price;
                messenger.Send("Weapon bought", "ShopInfo");
                SavePlayer(player);
            }
        }

        public void SellWeapon()
        {
            if (player.Weapon != null)
            {
                player.Money += (int)(0.8 * player.Weapon.Price);
                player.Weapon = null;
                messenger.Send("Weapon sold", "ShopInfo");
                SavePlayer(player);
            }
        }




    }
}
