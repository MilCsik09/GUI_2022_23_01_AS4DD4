namespace GUI_2022_23_01_AS4DD4.Models
{
    public class Potion
    {


        public string Name { get; set; }
        public int HealthRegeneration { get; set; }
        public Potion(string name, int healthRegeneration)
        {
            Name = name;
            HealthRegeneration = healthRegeneration;
        }
        public Potion()
        {

        }
    }
}