using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Model;

namespace TicTacToe.ViewModel
{
    internal class GameViewModel
    {
        public GameViewModel()
        {

        }
        public ScoreViewModel ScoreVM { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }

        public void StartNewGame()
        {
            Player1 = new(1, "Player 1");//todo make names user settable
            Player2 = new(2, "Player 2");
            ScoreVM = new();


        }
    }
}
