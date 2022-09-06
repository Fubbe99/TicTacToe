using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TicTacToe.Model
{
    [ObservableObject]
    public partial class Square
    {
        [ObservableProperty]
        private int number = 0;

        [ObservableProperty]
        private int idPlaced = 0;

        [ObservableProperty]
        private string? icon;

        public Square(int squareNumber)
        {
            number = squareNumber;
        }
    }
}
