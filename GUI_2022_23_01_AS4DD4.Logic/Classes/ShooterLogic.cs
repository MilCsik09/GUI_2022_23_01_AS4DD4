using GUI_2022_23_01_AS4DD4.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using GUI_2022_23_01_AS4DD4.Logic.Interfaces;

namespace GUI_2022_23_01_AS4DD4.Logic.Classes
{
    public class ShooterLogic : IShooterControl, IShooterModel
    {
        public int elapsedSeconds = 0;
        public event EventHandler Changed;
        public event EventHandler GameOver;
        public Player? player;
        public bool Ingame = false;
        public List<Ammo> AmmoList = new List<Ammo>();
        public List<Armor> ArmorList = new List<Armor>();
        public List<Enemy> EnemyList = new List<Enemy>();
        public List<Level> LevelList = new List<Level>();
        public List<Potion> PotionList = new List<Potion>();
        public List<Weapon> WeaponList = new List<Weapon>();



        public void ArmorRegenerate(Armor armor, Player player)
        {
            if (player.Health < 150)
            {
                if (player.Health + armor.Protection <= 150)
                {
                    player.Health += armor.Protection;
                }
                else if (player.Health == 150)
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
            if (elapsedSeconds == player.TimeToShoot)
            {
                if (player.Health - player.Level.GetCurrentEnemy().DamageToPlayer <= 0)
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
            foreach (CrossHair crossHair in crossHairs)
            {
                if (crossHair.Position.X == x && crossHair.Position.Y == y) ///finish the logic for shoot position && get the position of the mouse.
                {
                    player.Level.GetCurrentEnemy().CrossHairs.Remove(crossHair);
                }
            }
        }

        public void NextLevelCheck() //TODO
        {
            if (player.Level.CurrentEnemy == player.Level.Enemy.Count)
            {

            }
        }

        public void SpawnEnemy()
        {

        }

        public void LoadAssets()        //TODO fix - áthelyezés projekt
        {
            AmmoList =
                JsonSerializer.Deserialize<List<Ammo>>(File.ReadAllText(Path.Combine(@"..\..\..\Data\Ammos", "ammos.json")));
            ArmorList =
                JsonSerializer.Deserialize<List<Armor>>(File.ReadAllText(Path.Combine(@"..\..\..\Data\Armors", "armors.json")));
            EnemyList =
                JsonSerializer.Deserialize<List<Enemy>>(File.ReadAllText(Path.Combine(@"..\..\..\Data\Enemies", "enemies.json")));
            LevelList =
                JsonSerializer.Deserialize<List<Level>>(File.ReadAllText(Path.Combine(@"..\..\..\Data\Levels", "levels.json")));
            PotionList =
                JsonSerializer.Deserialize<List<Potion>>(File.ReadAllText(Path.Combine(@"..\..\..\Data\Potions", "potions.json")));
            WeaponList =
                JsonSerializer.Deserialize<List<Weapon>>(File.ReadAllText(Path.Combine(@"..\..\..\Data\Weapons", "weapons.json")));
        }

        public void LoadPlayer(string playerName)
        {

            string fileName = playerName + ".json";
            string path = Path.Combine(@"..\..\..\Data\Players", fileName);

            player =
                JsonSerializer.Deserialize<Player>(File.ReadAllText(path));
        }

        public void CreateNewPlayer()
        {


        }

        public void SavePlayer(Player player)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(player, options);
            string fileName = player.Name + ".json";
            string path = Path.Combine(@"..\..\..\Data\Players", fileName);     //todo fix
            File.WriteAllText(path, jsonString);
        }

        public void TimeStep()        //set to public for debug purposes --- mainwindow
        {
            if (Ingame)
            {
                elapsedSeconds++;
                DamageTaken(player);
                NextLevelCheck();
            }

        }
        public void BuyAmmo(Ammo ammo)
        {
            this.player.Ammo = ammo;
        
        }

        public void BuyArmor(Armor armor)
        {
            this.player.Armor = armor;

        }

        public void BuyPotion(Potion potion)
        {
            this.player.Potion = potion;
            //this.player.Potions.Add(potion);

        }

        public void BuyWeapon(Weapon weapon)
        {
            this.player.Weapon = weapon;

        }
    }
}
