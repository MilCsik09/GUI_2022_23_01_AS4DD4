using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.CodeDom;

namespace GUI_2022_23_01_AS4DD4.Models
{
    public class Ammo : ObservableObject
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }
        private int damage;
        public int Damage
        {
            get { return damage; }
            set { SetProperty(ref damage, value); }
        }
        private int number;
        public int Number
        {
            get { return number; }
            set { SetProperty(ref number, value); }
        }
        private int price;
        public int Price
        {
            get { return price; }
            set { SetProperty(ref price, value); }
        }         
        
        public Ammo()
        {

        }
    }
}