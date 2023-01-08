using GUI_2022_23_01_AS4DD4.Logic.Interfaces;
using GUI_2022_23_01_AS4DD4.Models;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Enumeration;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GUI_2022_23_01_AS4DD4.Logic.Classes
{
    public class LoadLogic : ILoadLogic
    {
        Player player = new Player();
        IMessenger messenger;
        IList<string> playerList;

        public Player Player
        {
            get => player;
            set => player = value;
        }

        public IList<string> PlayerList
        {
            get => playerList;
            set => playerList = value;
        }

        public LoadLogic()
        {

        }

        public LoadLogic(IMessenger messenger)
        {
            this.messenger = messenger;
        }


        public void LoadAssets()
        {
            playerList = new List<string>();
            string[] files = Directory.GetFiles(@"..\..\..\Data\Players");

            foreach (var file in files)
            {
                string fileName = Path.GetFileName(file);
                fileName = fileName.Replace(".json", "");
                playerList.Add(fileName);
            }

        }



        public Player LoadPlayer(string playerName)
        {

            string fileName = playerName + ".json";
            string path = Path.Combine(@"..\..\..\Data\Players", fileName);

            return JsonSerializer.Deserialize<Player>(File.ReadAllText(path));
        }

        public void SavePlayer(Player player)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(player, options);
            string fileName = player.Name + ".json";
            string path = Path.Combine(@"..\..\..\Data\Players", fileName);
            File.WriteAllText(path, jsonString);
        }

        public void DeletePlayer(string playerName)
        {
            string fileName = playerName + ".json";
            string path = Path.Combine(@"..\..\..\Data\Players", fileName);

            File.Delete(path);
            messenger.Send("Player removed", "PlayerInfo");
        }
    }
}


