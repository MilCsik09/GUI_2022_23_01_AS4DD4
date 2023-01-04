using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace GUI_2022_23_01_AS4DD4.Models
{
    public class Potion : ObservableObject
    {

        private string name;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }
        private int healthRegeneration;
        public int HealthRegeneration
        {
            get { return healthRegeneration; }
            set { SetProperty(ref healthRegeneration, value); }
        }
        private int price;
        public int Price
        {
            get { return price; }
            set { SetProperty(ref price, value); }
        }
        //public Potion(string name, int healthRegeneration, int price)
        //{
        //    Name = name;
        //    HealthRegeneration = healthRegeneration;
        //    Price = price;
        //}
        public Potion()
        {

        }
    }
}