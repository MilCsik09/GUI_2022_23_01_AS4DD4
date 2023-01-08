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

        public Ammo CurrentAmmo
        {
            get { return logic.GetCurrentAmmo; }            
        }

        public Armor CurrentArmor
        {
            get { return logic.GetCurrentArmor; }
        }

        public Weapon CurrentWeapon
        {
            get { return logic.GetCurrentWeapon; }
        }

        public Potion CurrentPotion
        {
            get { return logic.GetCurrentPotion; }
        }

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

        public ShopWindowViewModel(IShopLogic logic)
        {

            this.logic = logic;
            logic.LoadAssets();
            logic.LoadPlayer(MainWindow.Player.Name);
                        
            Ammos = new ObservableCollection<Ammo>(logic.AmmoList);
            Armors = new ObservableCollection<Armor>(logic.ArmorList);
            Potions = new ObservableCollection<Potion>(logic.PotionList);
            Weapons = new ObservableCollection<Weapon>(logic.WeaponList);
            
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
                );
            SellArmorCommand = new RelayCommand(
                () => { logic.SellArmor(); }                
                );
            SellPotionCommand = new RelayCommand(
                () => { logic.SellPotion(); }                
                );

            SellWeaponCommand = new RelayCommand(
                () => { logic.SellWeapon(); }                
                );


            Messenger.Register<ShopWindowViewModel, string, string>(this, "ShopInfo", (recipient, msg) =>
            {
                OnPropertyChanged("CurrentAmmo");
                OnPropertyChanged("CurrentArmor");
                OnPropertyChanged("CurrentWeapon");
                OnPropertyChanged("CurrentPotion");
                OnPropertyChanged("Money");

            });

        }

    }
}
