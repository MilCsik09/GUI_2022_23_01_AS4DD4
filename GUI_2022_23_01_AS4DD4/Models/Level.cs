﻿using System.Collections.Generic;

namespace GUI_2022_23_01_AS4DD4.Models
{
    public class Level
    {

        public List<Enemy> Enemy { get; set; }
        public int CurrentEnemy;
        public Level(List<Enemy> enemy)
        {
            Enemy = enemy;
            CurrentEnemy = 0;
        }

        public Enemy GetCurrentEnemy()
        {
            return Enemy[CurrentEnemy];
        }
    }
}