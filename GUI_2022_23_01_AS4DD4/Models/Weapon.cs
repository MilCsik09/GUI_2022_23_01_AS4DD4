namespace GUI_2022_23_01_AS4DD4.Models
{
    public class Weapon
    {


        public string Name { get; set; }
        public int BaseDamage { get; set; }

        public Weapon(string name, int baseDamage)
        {
            Name = name;
            BaseDamage = baseDamage;
        }
        public Weapon()
        {

        }
    }
}