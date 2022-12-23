using System;

namespace GUI_2022_23_01_AS4DD4.Models
{
    public class Armor
    {


        public string Name { get; set; }
        public int Protection { get; set; }
        public double DamageReducton { get; set; } //szazaleskos ertek
        public int Price { get; set; }
        public Armor(string name, int protection, double damageReducton, int price)
        {
            Name = name;
            Protection = protection;
            DamageReducton = damageReducton;
            Price = price;
        }
        public Armor()
        {

        }
    }
}