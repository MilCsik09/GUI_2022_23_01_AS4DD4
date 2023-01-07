using GUI_2022_23_01_AS4DD4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_2022_23_01_AS4DD4.WPF.Viewmodels
{
    public class CreateWindowViewModel
    {
        
        
        public Player NewPlayer { get; set; }

        //public void Setup(Player player)
        //{
        //    this.NewPlayer = player;
        //}

        public void Setup()
        {
            this.NewPlayer = new Player();
        }


        public CreateWindowViewModel()
        {

        }

    }
}
