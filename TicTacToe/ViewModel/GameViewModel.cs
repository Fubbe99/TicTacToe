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
            PlayerToStart = Player1;
            CurrentPlayer = Player1;

            Messenger.Send(new NextTurnMessage { Player = CurrentPlayer });

            InitializeSquares();
            PlayEnabled = true;
        }

        public ScoreViewModel ScoreVM { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public Player PlayerToStart { get; set; }

        [ObservableProperty]
        private Player currentPlayer;
        public List<Square> SquaresPlayed { get; set; } = new List<Square>();

        [ObservableProperty]
        private bool playEnabled;

        [ObservableProperty]
        private Square? square1;
        [ObservableProperty]
        private Square? square2;
        [ObservableProperty]
        private Square? square3;
        [ObservableProperty]
        private Square? square4;
        [ObservableProperty]
        private Square? square5;
        [ObservableProperty]
        private Square? square6;
        [ObservableProperty]
        private Square? square7;
        [ObservableProperty]
        private Square? square8;
        [ObservableProperty]
        private Square? square9;

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
            ChangeStartingPlayer();

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

            if (GameHasEnded())
            {
                GameEnded(CurrentPlayer);
            }
            else
            {
                ChangeCurrentPlayer();
            }
        }

        //Todo why not possible to pass in Player to method under? Check does not work then as equality fails. Out of scope?
        private void ChangeCurrentPlayer()
        {
            CurrentPlayer = CurrentPlayer == Player1 ? Player2 : Player1;
            Messenger.Send(new NextTurnMessage { Player = CurrentPlayer });
        }
        private void ChangeStartingPlayer()
        {
            PlayerToStart = PlayerToStart == Player1 ? Player2 : Player1;
            CurrentPlayer = PlayerToStart;
            Messenger.Send(new NextTurnMessage { Player = CurrentPlayer });
        }

        private static bool SquareNotZeroAndEqualToOtherSquares(Square sq, params Square[] otherSquares)
        {
            if (sq.IdPlaced == 0) return false;

            return otherSquares.All(v => v.IdPlaced.Equals(sq.IdPlaced));
        }

        private bool GameHasEnded()
        {
            //Horisontally
            if (SquareNotZeroAndEqualToOtherSquares(square1, square2, square3)
                || SquareNotZeroAndEqualToOtherSquares(square4, square5, square6)
                || SquareNotZeroAndEqualToOtherSquares(square7, square8, square9))
            {
                return true;
            }

            //Vertically
            if (SquareNotZeroAndEqualToOtherSquares(square1, square4, square7)
                    || SquareNotZeroAndEqualToOtherSquares(square2, square5, square8)
                    || SquareNotZeroAndEqualToOtherSquares(square3, square6, square9))
            {
                return true;
            }

            //Diagonally
            if (SquareNotZeroAndEqualToOtherSquares(square1, square5, square9)
                       || SquareNotZeroAndEqualToOtherSquares(square3, square5, square7))
            {
                return true;
            }

            //Draw
            if (SquaresPlayed.Count == maxSquaresPossible)
            {
                currentPlayer = new Player(0, "Draw");
                return true;
            }

            return false;
        }

        private void GameEnded(Player playerWhoWon)
        {
            Messenger.Send(new ScoreUpdateMessage { Player = playerWhoWon });
            Messenger.Send(new NextTurnMessage { Player = null });

            PlayEnabled = false;
        }
    }
}
