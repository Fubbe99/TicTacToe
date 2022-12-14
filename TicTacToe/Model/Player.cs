using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Model
{
    [ObservableObject]
    public partial class Player
    {
        [ObservableProperty]
        private int id = 0;

        [ObservableProperty]
        private string name = string.Empty;

        [ObservableProperty]
        private int score = 0;

        [ObservableProperty]
        private string? icon;

        public Player(int playerId, string playerName, string? iconName = null)
        {
            Id = playerId;
            Name = playerName;
            Icon = iconName;
        }
    }
}
