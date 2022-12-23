using System.CodeDom;

namespace GUI_2022_23_01_AS4DD4.Models
{
    public class Ammo
    {

        public string Name { get; set; }
        public int Damage { get; set; }
        public int Number { get; set; }
        public int Price { get; set; }
        public Ammo(string name, int damage, int number, int price)
        {
            Name = name;
            Damage = damage;
            Number = number;
            Price = price;
        }

        public Ammo()
        {

        }
    }
}