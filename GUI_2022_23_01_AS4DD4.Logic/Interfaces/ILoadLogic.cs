using GUI_2022_23_01_AS4DD4.Models;
using System.Collections.Generic;

namespace GUI_2022_23_01_AS4DD4.Logic.Interfaces
{
    public interface ILoadLogic
    {
        Player Player { get; set; }
        IList<string> PlayerList { get; set; }

        void LoadAssets();
        Player LoadPlayer(string playerName);
        void SavePlayer(Player player);
        void DeletePlayer(string playerName);
    }
}