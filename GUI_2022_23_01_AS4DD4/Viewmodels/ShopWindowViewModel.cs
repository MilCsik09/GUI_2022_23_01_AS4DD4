using GUI_2022_23_01_AS4DD4.Logic.Classes;
using GUI_2022_23_01_AS4DD4.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GUI_2022_23_01_AS4DD4.WPF.Viewmodels
{
    public class ShopWindowViewModel : ObservableRecipient
    {

        private ShooterLogic logic = new ShooterLogic();

        public ShopWindowViewModel()
        {
            logic.LoadAssets();
            ObservableCollection<Ammo> Ammos = new ObservableCollection<Ammo>(logic.AmmoList);
            ObservableCollection<Armor> Armors = new ObservableCollection<Armor>(logic.ArmorList);
            ObservableCollection<Potion> Potions = new ObservableCollection<Potion>(logic.PotionList);
            ObservableCollection<Weapon> Weapons = new ObservableCollection<Weapon>(logic.WeaponList);

            BuyAmmoCommand = new RelayCommand(() => { logic.BuyAmmo(selectedAmmo); });

            BuyArmorCommand = new RelayCommand(() => { logic.BuyArmor(selectedArmor); });

            BuyPotionCommand = new RelayCommand(() => { logic.BuyPotion(selectedPotion); });

            BuyWeaponCommand = new RelayCommand(() => { logic.BuyWeapon(selectedWeapon); });


        }

        public ObservableCollection<Ammo> Ammos { get; set; }
        public ObservableCollection<Armor> Armors { get; set; }
        public ObservableCollection<Potion> Potions { get; set; }
        public ObservableCollection<Weapon> Weapons { get; set; }

        private Ammo selectedAmmo;

        public Ammo SelectedAmmo
        {
            get { return selectedAmmo; }
            set { selectedAmmo = value; }
        }

        private Armor selectedArmor;

        public Armor SelectedArmor
        {
            get { return selectedArmor; }
            set { selectedArmor = value; }
        }

        private Potion selectedPotion;

        public Potion SelectedPotion
        {
            get { return selectedPotion; }
            set { selectedPotion = value; }
        }

        private Weapon selectedWeapon;

        public Weapon SelectedWeapon
        {
            get { return selectedWeapon; }
            set { selectedWeapon = value; }
        }

        public ICommand BuyAmmoCommand { get; set; }
        public ICommand BuyArmorCommand { get; set; }
        public ICommand BuyPotionCommand { get; set; }
        public ICommand BuyWeaponCommand { get; set; }




    }
}
