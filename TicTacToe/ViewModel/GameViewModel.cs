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
    public partial class GameViewModel : ObservableRecipient
    {
        private const int maxSquaresPossible = 9;

        public GameViewModel(Player playerOne, Player playerTwo)
        {
            Player1 = playerOne;
            Player2 = playerTwo;
            currentPlayer = Player1;

            InitializeSquares();
            playEnabled = true;
        }
       
        public ScoreViewModel ScoreVM { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
       
        [ObservableProperty]
        private Player currentPlayer;
        public List<Square> SquaresPlayed { get; set; } = new List<Square>();

        [ObservableProperty]
        private bool playEnabled;

        [ObservableProperty]
        private Square square1;
        [ObservableProperty]
        private Square square2;
        [ObservableProperty]
        private Square square3;
        [ObservableProperty]
        private Square square4;
        [ObservableProperty]
        private Square square5;
        [ObservableProperty]
        private Square square6;
        [ObservableProperty]
        private Square square7;
        [ObservableProperty]
        private Square square8;
        [ObservableProperty]
        private Square square9;

        private void InitializeSquares()
        {
            SquaresPlayed.Clear();
            Square1 = new(1);
            Square2 = new(2);
            Square3 = new(3);
            Square4 = new(4);
            Square5 = new(5);
            Square6 = new(6);
            Square7 = new(7);
            Square8 = new(8);
            Square9 = new(9);
        }


        [RelayCommand]
        public void StartNewGame()
        {
            currentPlayer = Player1;
            InitializeSquares();
            PlayEnabled = true;
        }

        [RelayCommand]
        private void MakeMove(Square square)
        {
            if (SquaresPlayed.Contains(square))
            {
                return;
            }
            square.IdPlaced = currentPlayer.Id;
            SquaresPlayed.Add(square);
            square.Icon = CurrentPlayer.Icon;

            CheckIfGameHasEnded();

            CurrentPlayer = CurrentPlayer == Player1 ? Player2 : Player1;
        }

        private void CheckIfGameHasEnded()
        {
            if (SquaresPlayed.Count == maxSquaresPossible)
            {
                GameEnded(new(0, "Draw"));
                return;
            }


            if (square1.IdPlaced != 0 && square1.IdPlaced == square2.IdPlaced && square1.IdPlaced == square3.IdPlaced)
            {
                GameEnded(currentPlayer);
                return;
            }
            if (square4.IdPlaced != 0 && square4.IdPlaced == square5.IdPlaced && square4.IdPlaced == square6.IdPlaced)
            {
                GameEnded(currentPlayer);
                return;
            }
            if (square7.IdPlaced != 0 && square7.IdPlaced == square8.IdPlaced && square7.IdPlaced == square9.IdPlaced)
            {
                GameEnded(currentPlayer);
                return;
            }
            if (square1.IdPlaced != 0 && square1.IdPlaced == square5.IdPlaced && square1.IdPlaced == square9.IdPlaced)
            {
                GameEnded(currentPlayer);
                return;
            }
            if (square7.IdPlaced != 0 && square7.IdPlaced == square5.IdPlaced && square7.IdPlaced == square3.IdPlaced)
            {
                GameEnded(currentPlayer);
                return;
            }
        }

        private void GameEnded(Player playerWhoWon)
        {
            Messenger.Send(new ScoreUpdateMessage { Player = playerWhoWon });

            PlayEnabled = false;

        }
    }
}
