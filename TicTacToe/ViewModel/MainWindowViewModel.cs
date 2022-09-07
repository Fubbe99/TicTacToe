using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TicTacToe.Common.Messages;
using TicTacToe.Model;

namespace TicTacToe.ViewModel
{
    public partial class MainWindowViewModel : ObservableRecipient, IRecipient<GameVisibilityChangedMessage>
    {
        string player1IconPath = "\\Common\\Assets\\X15.png";
        string player2IconPath = "\\Common\\Assets\\O15.png";

        [ObservableProperty]
        private Visibility gameVisibility;

        public MainWindowViewModel()
        {
            Player1 = new(1, "Player 1", player1IconPath);
            Player2 = new(2, "Player 2", player2IconPath);

            GameVisibility = Visibility.Collapsed;

            EnterNameVM = new(Player1, Player2);
            GameVM = new(Player1, Player2);
            ScoreVM = new(Player1, Player2);
            WhoseTurnVM = new(Player1);

            Messenger.Register<GameVisibilityChangedMessage>(this);
        }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public GameViewModel GameVM { get; set; }
        public ScoreViewModel ScoreVM { get; set; }
        public WhosTurnViewModel WhoseTurnVM { get; set; }
        public EnterNameViewModel EnterNameVM { get; set; }

        public void Receive(GameVisibilityChangedMessage message)
        {
            GameVisibility = message.GameVisibility;
        }
    }
}
