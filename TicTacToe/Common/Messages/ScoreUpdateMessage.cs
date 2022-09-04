using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Model;

namespace TicTacToe.Common.Messages
{
    public class ScoreUpdateMessage
    {
        public Player Player { get; set; }
    }
}
