using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Model;

namespace TicTacToe.ViewModel
{
    public class GameViewModel
    {
        public GameViewModel(Player player1, Player player2)
        {
            Player1 = player1;
            Player2 = player2;
        }
        public ScoreViewModel ScoreVM { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }

        public void StartNewGame()
        {
            ScoreVM = new(Player1, Player2);
        }
    }
}
