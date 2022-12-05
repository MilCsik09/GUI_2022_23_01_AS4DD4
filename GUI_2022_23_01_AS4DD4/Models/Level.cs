using System.Collections.Generic;

namespace GUI_2022_23_01_AS4DD4.Models
{
    public class Level
    {
        public string Name { get; set; }
        public List<Enemy> Enemy { get; set; }
        public int CurrentEnemy;
        public Level(string name, List<Enemy> enemy)
        {
            name = name;
            Enemy = enemy;
            CurrentEnemy = 0;
        }
        public Level()
        {

        }

        public Enemy GetCurrentEnemy()
        {
            return Enemy[CurrentEnemy];
        }
    }
}