using TicTacToe.Model;

namespace TicTacToe.Common.Messages
{
    public sealed record ScoreUpdateMessage
    {
        public Player? Player { get; set; }
    }
}
