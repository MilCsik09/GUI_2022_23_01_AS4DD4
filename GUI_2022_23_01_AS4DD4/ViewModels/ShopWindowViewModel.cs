using GUI_2022_23_01_AS4DD4.Logic;
using GUI_2022_23_01_AS4DD4.Models;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GUI_2022_23_01_AS4DD4.ViewModels
{
    public class ShopWindowViewModel
    {
        ShopLogic shopLogic = new ShopLogic();
        Player? player;

        //collection-ök
        public List<Ammo>? Ammos { get; set; }
        public List<Armor>? Armors { get; set; }
        public List<Potion>? Potions { get; set; }
        public List<Weapon>? Weapons { get; set; }


        //kijelölt ammo
        private Ammo selectedAmmo;

        public Ammo SelectedAmmo
        {
            get { return selectedAmmo; }
            set { selectedAmmo = value; }
        }

        //kijelölt armor
        private Armor selectedArmor;

        public Armor SelectedArmor
        {
            get { return selectedArmor; }
            set { selectedArmor = value; }
        }

        //kijelölt potion
        private Potion selectedPotion;

        public Potion SelectedPotion
        {
            get { return selectedPotion; }
            set { selectedPotion = value; }
        }

        //kijelölt weapon
        private Weapon selectedWeapon;

        public Weapon SelectedWeapon
        {
            get { return selectedWeapon; }
            set { selectedWeapon = value; }
        }








        //ICommandok
        public ICommand BuyAmmoCommand { get; set; }
        public ICommand SellAmmoCommand { get; set; }        
        public ICommand BuyArmorCommand { get; set; }
        public ICommand SellArmorCommand { get; set; }
        public ICommand BuyPotionCommand { get; set; }
        public ICommand SellPotionCommand { get; set; }
        public ICommand BuyWeaponCommand { get; set; }
        public ICommand SellWeaponCommand { get; set; }


        //ctor
        public ShopWindowViewModel()
        {
            player = shopLogic.player;

            Ammos = shopLogic.AmmoList;
            Armors = shopLogic.ArmorList;
            Potions = shopLogic.PotionList;
            Weapons = shopLogic.WeaponList;

            //ammo megvétel
            BuyAmmoCommand = new RelayCommand(
                () => { shopLogic.BuyAmmo(SelectedAmmo); }
            );
        }

        

    }
}
