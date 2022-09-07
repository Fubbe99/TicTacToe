using TicTacToe.Model;

namespace TicTacToe.Common.Messages
{
    public sealed record NextTurnMessage
    {
        public Player? Player { get; set; }
    }
}
