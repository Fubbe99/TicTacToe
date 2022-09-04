using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Model;

namespace TicTacToe.ViewModel
{
    public partial class MainWindowViewModel
    {
        string player1IconPath = "\\Common\\Assets\\X15.png";
        string player2IconPath = "\\Common\\Assets\\O15.png";

        public MainWindowViewModel()
        {
            Player1 = new(1, "Player 1", player1IconPath);
            Player2 = new(2, "Player 2", player2IconPath);
            
            GameVM = new(Player1, Player2);
            ScoreVM = new(Player1, Player2);
        }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public GameViewModel GameVM { get; set; }
        public ScoreViewModel ScoreVM { get; set; }
    }
}
