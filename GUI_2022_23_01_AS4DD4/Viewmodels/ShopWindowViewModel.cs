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


            BuyAmmoCommand = new RelayCommand(
                () => { logic.BuyAmmo(selectedAmmo); },
                () => { return selectedAmmo != null; }
                );
            BuyArmorCommand = new RelayCommand(
                () => { logic.BuyArmor(selectedArmor); },
                () => { return selectedArmor != null; }
                );
            BuyPotionCommand = new RelayCommand(
                () => { logic.BuyPotion(selectedPotion); },
                () => { return selectedPotion != null; }
                );
            BuyWeaponCommand = new RelayCommand(
                () => { logic.BuyWeapon(selectedWeapon); },
                () => { return selectedWeapon != null; }
                );

            SellAmmoCommand = new RelayCommand(
                () => { logic.SellAmmo(currentAmmo); },
                () => { return currentAmmo != null; }
                );
            SellArmorCommand = new RelayCommand(
                () => { logic.SellArmor(currentArmor); },
                () => { return currentArmor != null; }
                );
            SellPotionCommand = new RelayCommand(
                () => { logic.SellPotion(selectedPlayerPotion); },
                () => { return selectedPlayerPotion != null; }
                );
            SellWeaponCommand = new RelayCommand(
                () => { logic.SellWeapon(currentWeapon); },
                () => { return currentWeapon != null; }
                );


        }


        //ammo
        private Ammo selectedAmmo;

        public Ammo SelectedAmmo
        {
            get { return selectedAmmo; }
            set 
            {
                SetProperty(ref selectedAmmo, value);
                (BuyAmmoCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        //armor
        private Armor selectedArmor;

        public Armor SelectedArmor
        {
            get { return selectedArmor; }
            set
            {
                SetProperty(ref selectedArmor, value);
                (BuyArmorCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        //potion
        private Potion selectedPotion;

        public Potion SelectedPotion
        {
            get { return selectedPotion; }
            set
            {
                SetProperty(ref selectedPotion, value);
                (BuyPotionCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        //weapon
        private Weapon selectedWeapon;

        public Weapon SelectedWeapon
        {
            get { return selectedWeapon; }
            set 
            {
                SetProperty(ref selectedWeapon, value);
                (BuyWeaponCommand as RelayCommand).NotifyCanExecuteChanged();
            }
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
            set 
            {
                SetProperty(ref selectedPlayerPotion, value);
                (SellPotionCommand as RelayCommand).NotifyCanExecuteChanged();
            }
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
