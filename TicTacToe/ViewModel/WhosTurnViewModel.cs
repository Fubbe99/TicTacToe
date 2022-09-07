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
    public partial class WhosTurnViewModel : ObservableRecipient, IRecipient<NextTurnMessage>
    {
        [ObservableProperty]
        private Player? nextPlayer;

        public WhosTurnViewModel(Player player1)
        {
            NextPlayer = player1;

            Messenger.Register<NextTurnMessage>(this);
        }

        public void Receive(NextTurnMessage message)
        {
            NextPlayer = message.Player;
        }
    }
}
