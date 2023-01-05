using GUI_2022_23_01_AS4DD4.Logic.Classes;
using GUI_2022_23_01_AS4DD4.Logic.Interfaces;
using GUI_2022_23_01_AS4DD4.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GUI_2022_23_01_AS4DD4.WPF.Viewmodels
{
    public class ShopWindowViewModel : ObservableRecipient
    {

        //ShopLogic logic = new ShopLogic();
        IShopLogic logic; 

        public ObservableCollection<Ammo> Ammos { get; set; }
        public ObservableCollection<Armor> Armors { get; set; }
        public ObservableCollection<Potion> Potions { get; set; }
        public ObservableCollection<Weapon> Weapons { get; set; }
        public ObservableCollection<Potion> PlayerPotions { get; set; }
        public int Money 
        {
            get
            {
                return logic.GetMoney;
            }
        }

        //public Ammo currentAmmo { get; set; }     //lejjebb a propertyknél
        //public Armor currentArmor { get; set; }
        //public Weapon currentWeapon { get; set; }


        


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

        public Ammo CurrentAmmo
        {
            get { return logic.GetCurrentAmmo; }
            //set
            //{
            //    //logic.SetCurrentAmmo = value;
            //    //(SellAmmoCommand as RelayCommand).NotifyCanExecuteChanged();
            //}
        }

        //current armor

        public Armor CurrentArmor
        {
            get { return logic.GetCurrentArmor; }
        }

        //current weapon

        public Weapon CurrentWeapon
        {
            get { return logic.GetCurrentWeapon; }
        }

        //current potions

        public Potion CurrentPotion
        {
            get { return logic.GetCurrentPotion; }
        }


        //current potions - selected item
        //private Potion selectedPlayerPotion;

        //public Potion SelectedPlayerPotion
        //{
        //    get { return selectedPlayerPotion; }
        //    set
        //    {
        //        SetProperty(ref selectedPlayerPotion, value);
        //        (SellPotionCommand as RelayCommand).NotifyCanExecuteChanged();
        //    }
        //}

        //icommands
        public ICommand BuyAmmoCommand { get; set; }
        public ICommand BuyArmorCommand { get; set; }
        public ICommand BuyPotionCommand { get; set; }
        public ICommand BuyWeaponCommand { get; set; }

        public ICommand SellAmmoCommand { get; set; }
        public ICommand SellArmorCommand { get; set; }
        public ICommand SellPotionCommand { get; set; }
        public ICommand SellWeaponCommand { get; set; }



        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }


        public ShopWindowViewModel()
            : this(IsInDesignMode ? null : Ioc.Default.GetService<IShopLogic>())
        {

        }

        //ctor
        public ShopWindowViewModel(IShopLogic logic)
        {

            this.logic = logic;
            logic.LoadAssets();
            logic.LoadPlayer("Barna");          //DEBUG

            //player = logic.player;

            //current equipment
            //currentAmmo = logic.Player.Ammo;
            //currentArmor = logic.Player.Armor;
            //currentWeapon = logic.Player.Weapon;
            //PlayerPotions = new ObservableCollection<Potion>(logic.Player.Potions);


            Ammos = new ObservableCollection<Ammo>(logic.AmmoList);
            Armors = new ObservableCollection<Armor>(logic.ArmorList);
            Potions = new ObservableCollection<Potion>(logic.PotionList);
            Weapons = new ObservableCollection<Weapon>(logic.WeaponList);
            //Money = logic.Player.Money;


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
                () => { logic.SellAmmo(); }
                //() => { return CurrentAmmo != null; }
                );
            SellArmorCommand = new RelayCommand(
                () => { logic.SellArmor(); }
                //() => { return CurrentArmor != null; }
                );
            SellPotionCommand = new RelayCommand(
                () => { logic.SellPotion(); }
                //() => { logic.SellPotion(selectedPlayerPotion); }
                //() => { return SelectedPlayerPotion != null; }
                );

            SellWeaponCommand = new RelayCommand(
                () => { logic.SellWeapon(); }
                //() => { return CurrentWeapon != null; }
                );


            Messenger.Register<ShopWindowViewModel, string, string>(this, "ShopInfo", (recipient, msg) =>
            {
                OnPropertyChanged("CurrentAmmo");
                OnPropertyChanged("CurrentArmor");
                OnPropertyChanged("CurrentWeapon");
                //OnPropertyChanged("PlayerPotions");
                OnPropertyChanged("CurrentPotion");
                OnPropertyChanged("Money");

            });

        }





 



    }
}
