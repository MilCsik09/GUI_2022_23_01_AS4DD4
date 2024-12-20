﻿using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace GUI_2022_23_01_AS4DD4.Models
{
    public class Potion : ObservableObject
    {

        private string name;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        private int healthRegeneration;
        public int HealthRegeneration
        {
            get { return healthRegeneration; }
            set { SetProperty(ref healthRegeneration, value); }
        }

        private int price;
        public int Price
        {
            get { return price; }
            set { SetProperty(ref price, value); }
        }
        private bool isInfinite;
        public bool IsInfinite
        {
            get { return isInfinite; }
            set { SetProperty(ref isInfinite, value); }
        }

        public Potion()
        {

        }
    }
}