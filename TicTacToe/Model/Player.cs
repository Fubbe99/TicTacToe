using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Model
{
    public partial class Player : ObservableObject
    {
        [ObservableProperty]
        private int id = 0;

        [ObservableProperty]
        private string name = string.Empty;

        [ObservableProperty]
        private int score = 0;

        public Player(int playerId, string playerName)
        {
            id = playerId;
            name = playerName;
        }
    }
}
