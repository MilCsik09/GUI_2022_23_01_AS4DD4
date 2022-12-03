using GUI_2022_23_01_AS4DD4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_2022_23_01_AS4DD4.Logic
{
    public class ShooterLogic : IShooterControl, IShooterModel
    {
        public event EventHandler Changed;
        public event EventHandler GameOver;

        public void ArmorRegenerate(Armor armor, Player player)
        {
            if (player.Health < 150)
            {
                if (player.Health + armor.Protection <= 150)
                {
                    player.Health += armor.Protection;
                }
                else if(player.Health == 150)
                {

                }
                else
                {
                    player.Health = 150;
                }
            }
        }

        public void DamageTaken(Player player) ///TODO Milan
        {
            throw new NotImplementedException();
        }

        public void Heal(Potion potion, Player player)
        {
            if (player.Health < 100)
            {
                if (player.Health + potion.HealthRegeneration <= 100)
                {
                    player.Health += potion.HealthRegeneration;
                }
                else if (player.Health == 100)
                {

                }
                else
                {
                    player.Health = 100;
                }
            }
        }

        public void Shoot(int x, int y, Player player) ///Milan TODO
        {
            throw new NotImplementedException();
        }
    }
}
