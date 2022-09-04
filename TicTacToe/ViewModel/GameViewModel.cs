using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Common.Messages;
using TicTacToe.Model;

namespace TicTacToe.ViewModel
{
    public partial class GameViewModel : ObservableRecipient
    {
        public GameViewModel(Player player1, Player player2)
        {
            Player1 = player1;
            Player2 = player2;
        }
        public ScoreViewModel ScoreVM { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public Player CurrentPlayer { get; set; }

        public void StartNewGame()
        {
            ScoreVM = new(Player1, Player2);
            CurrentPlayer = Player1;
        }

        [RelayCommand]
        private void MakeMove()
        {
            CurrentPlayer = CurrentPlayer==Player1 ? Player2 : Player1;

        }

        private void GameEnded()
        {
            Messenger.Send(new ScoreUpdateMessage { Player = CurrentPlayer });
        }
    }
}
