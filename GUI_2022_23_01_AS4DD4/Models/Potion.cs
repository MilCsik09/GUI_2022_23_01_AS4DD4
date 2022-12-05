namespace GUI_2022_23_01_AS4DD4.Models
{
    public class Potion
    {


        public string Name { get; set; }
        public int HealthRegeneration { get; set; }
        public int Price { get; set; }
        public Potion(string name, int healthRegeneration, int price)
        {
            Name = name;
            HealthRegeneration = healthRegeneration;
            Price = price;
        }
        public Potion()
        {

        }
    }
}