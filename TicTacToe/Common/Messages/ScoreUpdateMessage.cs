using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Model;

namespace TicTacToe.Common.Messages
{
    internal class ScoreUpdateMessage : ValueChangedMessage<Player>
    {
        public ScoreUpdateMessage(Player player) : base(player)
        {

        }
    }
}
