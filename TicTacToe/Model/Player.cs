using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Model
{
    internal partial class Player : ObservableObject
    {
        [ObservableProperty]
        private int id = 0;

        [ObservableProperty]
        private string name = string.Empty;

        public Player(int playerId, string playerName)
        {
           
            Score = new();

            id = playerId;
            name = playerName;
        }

   
        public Score Score { get; set; }
    }
}
