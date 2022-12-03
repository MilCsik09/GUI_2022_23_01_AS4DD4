using GUI_2022_23_01_AS4DD4.Models;
using System;

namespace GUI_2022_23_01_AS4DD4.Logic
{
    public interface IShooterControl
    {
        public void Shoot(int x, int y);
        public void Heal(Potion potion);
        public void ArmorRegenerate(Armor armor);
        public void DamageTaken();


        
    }
}