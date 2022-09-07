using System.Windows;

namespace TicTacToe.Common.Messages
{
    public sealed record GameVisibilityChangedMessage
    {
        public Visibility GameVisibility { get; set; }
    }
}
