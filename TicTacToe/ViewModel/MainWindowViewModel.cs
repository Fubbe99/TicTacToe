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
        public MainWindowViewModel()
        {
            Player1 = new(1, "Player 1");//todo make names user settable
            Player2 = new(2, "Player 2");
            
            GameVM = new(Player1, Player2);
            ScoreVM = new(Player1, Player2);
        }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public GameViewModel GameVM { get; set; }
        public ScoreViewModel ScoreVM { get; set; }
    }
}
