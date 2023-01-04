using GUI_2022_23_01_AS4DD4.Logic.Classes;
using GUI_2022_23_01_AS4DD4.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GUI_2022_23_01_AS4DD4.WPF.Viewmodels
{
    public class ShopWindowViewModel : ObservableRecipient
    {

        private ShopLogic logic = new ShopLogic();


        public ObservableCollection<Ammo> Ammos { get; set; }
        public ObservableCollection<Armor> Armors { get; set; }
        public ObservableCollection<Potion> Potions { get; set; }
        public ObservableCollection<Weapon> Weapons { get; set; }
        public int Money { get; set; }

        //public Ammo currentAmmo { get; set; }     //lejjebb a propertyknél
        //public Armor currentArmor { get; set; }
        //public Weapon currentWeapon { get; set; }
        public ObservableCollection<Potion> PlayerPotions { get; set; }


        //ctor
        public ShopWindowViewModel()
        {
            logic.LoadAssets();
            logic.LoadPlayer("Barna");          //DEBUG

            //player = logic.player;

            //current equipment
            currentAmmo = logic.player.Ammo;
            currentArmor = logic.player.Armor;
            currentWeapon = logic.player.Weapon;
            PlayerPotions = new ObservableCollection<Potion>(logic.player.Potions);


            Ammos = new ObservableCollection<Ammo>(logic.AmmoList);
            Armors = new ObservableCollection<Armor>(logic.ArmorList);
            Potions = new ObservableCollection<Potion>(logic.PotionList);
            Weapons = new ObservableCollection<Weapon>(logic.WeaponList);
            Money = logic.player.Money;

            
            BuyAmmoCommand = new RelayCommand(() => { logic.BuyAmmo(selectedAmmo); });
            BuyArmorCommand = new RelayCommand(() => { logic.BuyArmor(selectedArmor); });
            BuyPotionCommand = new RelayCommand(() => { logic.BuyPotion(selectedPotion); });
            BuyWeaponCommand = new RelayCommand(() => { logic.BuyWeapon(selectedWeapon); });

            SellAmmoCommand = new RelayCommand(() => { logic.SellAmmo(currentAmmo); });
            SellArmorCommand = new RelayCommand(() => { logic.SellArmor(currentArmor); });
            SellPotionCommand = new RelayCommand(() => { logic.SellPotion(selectedPlayerPotion); });
            SellWeaponCommand = new RelayCommand(() => { logic.SellWeapon(currentWeapon); });


        }


        //ammo
        private Ammo selectedAmmo;

        public Ammo SelectedAmmo
        {
            get { return selectedAmmo; }
            set { selectedAmmo = value; }
        }

        //armor
        private Armor selectedArmor;

        public Armor SelectedArmor
        {
            get { return selectedArmor; }
            set { selectedArmor = value; }
        }

        //potion
        private Potion selectedPotion;

        public Potion SelectedPotion
        {
            get { return selectedPotion; }
            set { selectedPotion = value; }
        }

        //weapon
        private Weapon selectedWeapon;

        public Weapon SelectedWeapon
        {
            get { return selectedWeapon; }
            set { selectedWeapon = value; }
        }

        //current ammo
        private Ammo currentAmmo;

        public Ammo CurrentAmmo
        {
            get { return currentAmmo; }
            set { currentAmmo = value; }
        }

        //current armor
        private Armor currentArmor;

        public Armor CurrentArmor
        {
            get { return currentArmor; }
            set { currentArmor = value; }
        }

        //current weapon
        private Weapon currentWeapon;

        public Weapon CurrentWeapon
        {
            get { return currentWeapon; }
            set { currentWeapon = value; }
        }

        //current potions - selected item
        private Potion selectedPlayerPotion;

        public Potion SelectedPlayerPotion
        {
            get { return selectedPlayerPotion; }
            set { selectedPlayerPotion = value; }
        }

        //icommands
        public ICommand BuyAmmoCommand { get; set; }
        public ICommand BuyArmorCommand { get; set; }
        public ICommand BuyPotionCommand { get; set; }
        public ICommand BuyWeaponCommand { get; set; }

        public ICommand SellAmmoCommand { get; set; }
        public ICommand SellArmorCommand { get; set; }
        public ICommand SellPotionCommand { get; set; }
        public ICommand SellWeaponCommand { get; set; }



    }
}
