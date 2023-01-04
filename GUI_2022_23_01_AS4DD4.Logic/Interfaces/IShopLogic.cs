﻿using GUI_2022_23_01_AS4DD4.Models;
using System.Collections.Generic;

namespace GUI_2022_23_01_AS4DD4.Logic.Interfaces
{
    public interface IShopLogic
    {
        Player Player { get; }
        List<Ammo> AmmoList { get; }
        List<Armor> ArmorList { get; }
        List<Potion> PotionList { get; }
        List<Weapon> WeaponList { get; }


        void BuyAmmo(Ammo ammo);
        void BuyArmor(Armor armor);
        void BuyPotion(Potion potion);
        void BuyWeapon(Weapon weapon);
        void LoadAssets();
        void LoadPlayer(string playerName);
        void SavePlayer(Player player);
        void SellAmmo(Ammo ammo);
        void SellArmor(Armor armor);
        void SellPotion(Potion potion);
        void SellWeapon(Weapon weapon);
    }
}