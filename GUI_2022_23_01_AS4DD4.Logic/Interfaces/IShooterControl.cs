using GUI_2022_23_01_AS4DD4.Models;
using System;

namespace GUI_2022_23_01_AS4DD4.Logic.Interfaces
{
    public interface IShooterControl
    {
        public void Shoot(int x, int y, Player player);
        public void Heal(Potion potion, Player player);
        public void ArmorRegenerate(Armor armor, Player player);
        public void DamageTaken(Player player);



    }
}