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

        public void ArmorRegenerate(Armor armor)
        {
            throw new NotImplementedException();
        }

        public void DamageTaken()
        {
            throw new NotImplementedException();
        }

        public void Heal(Potion potion)
        {
            throw new NotImplementedException();
        }

        public void Shoot(int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}
