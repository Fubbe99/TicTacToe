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
    public partial class EnterNameViewModel : ObservableRecipient
    {
        [ObservableProperty]
        private Player player1;
        [ObservableProperty]
        private Player player2;
        [ObservableProperty]
        private Visibility isDialogOpen;

        public EnterNameViewModel(Player player1, Player player2)
        {
            IsDialogOpen = Visibility.Visible;
            Player1 = player1;
            Player2 = player2;
        }

        [RelayCommand]
        public void StartupComplete()
        {
            IsDialogOpen = Visibility.Collapsed;
            Messenger.Send(new GameVisibilityChangedMessage { GameVisibility = Visibility.Visible });
        }
    }
}
