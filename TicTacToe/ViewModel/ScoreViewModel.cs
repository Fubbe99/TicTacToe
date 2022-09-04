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
    public partial class ScoreViewModel : ObservableRecipient, IRecipient<ScoreUpdateMessage>
    {
   
        public ScoreViewModel(Player player1, Player player2)
        {
            Player1 = player1;
            Player2 = player2;            
        }

        public Player Player1 { get; set; }
        public Player Player2 { get; set; }

        [ObservableProperty]
        private int drawScore;

        public void Receive(ScoreUpdateMessage message)
        {
            AddScore(message.Player);

        }
        private void AddScore(Player player)
        {
            switch (player.Id)
            {
                case 1:
                    Player1.Score++;
                    break;
                case 2:
                    Player2.Score++;
                    break;
                case 0:
                    drawScore++;
                    break;
                default:
                    break;
            }
        }

    }
}
