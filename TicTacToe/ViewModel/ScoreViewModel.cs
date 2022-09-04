using CommunityToolkit.Mvvm.ComponentModel;
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
    internal partial class ScoreViewModel : ObservableObject
    {
        public ScoreViewModel()
        {
            WeakReferenceMessenger.Default.Register<ScoreUpdateMessage>(this, (r, m) =>
                {
                    AddScore(m.Value);
                });

        }
        [ObservableProperty]
        private int player1Score;

        [ObservableProperty]
        private int player2Score;

        [ObservableProperty]
        private int drawScore;

        private void AddScore(Player player)
        {
            switch (player.Id)
            {
                case 1:
                    player1Score++;
                    break;
                case 2:
                    player2Score++;
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
