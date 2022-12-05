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
        public int elapsedSeconds = 0;
        public event EventHandler Changed;
        public event EventHandler GameOver;
        public Player player;
        System.Windows.Size area;
        public void SetupSizes(System.Windows.Size area)
        {
            this.area = area;
        }

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

        public void DamageTaken(Player player) ///TODO armor damage reduction.
        {
            if(elapsedSeconds == player.TimeToShoot)
            {
                if ((player.Health - player.Level.GetCurrentEnemy().DamageToPlayer) <= 0)
                {
                    GameOver?.Invoke(this, new EventArgs());
                }
                else
                {
                    player.Health -= player.Level.GetCurrentEnemy().DamageToPlayer;
                }
                elapsedSeconds = 0;
            }
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
            List<CrossHair> crossHairs = player.Level.GetCurrentEnemy().CrossHairs;
            foreach(CrossHair crossHair in crossHairs)
            {
                if(crossHair.Position.X == x && crossHair.Position.Y == y) ///finish the logic for shoot position && get the position of the mouse.
                {
                    player.Level.GetCurrentEnemy().CrossHairs.Remove(crossHair);
                }
            }
        }

        internal void TimeStep()
        {
            elapsedSeconds++;
            DamageTaken(player);
        }
    }
}
