using Common.Constants;
using Common.Enums;
using GameEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.GameLogic.Caro
{
    public class Caro
    {
        private CaroChessman[,] board;
        public CaroChessman Chessman { get; private set; }
        private class Addition
        {
            public int X { get; set; }
            public int Y { get; set; }
        }
        private Addition[] additionVertical = new Addition[]
        {
            new Addition{ X= 0, Y= -4},
            new Addition{ X= 0, Y= -3},
            new Addition{ X= 0, Y= -2},
            new Addition{ X= 0, Y= -1},
            new Addition{ X= 0, Y= 0},
            new Addition{ X= 0, Y= 1},
            new Addition{ X= 0, Y= 2},
            new Addition{ X= 0, Y= 3},
            new Addition{ X= 0, Y= 4},
        };

        public Caro(CaroChessman chessman)
        {
            board = new CaroChessman[CaroConstant.BOARD_SIZE, CaroConstant.BOARD_SIZE];
            Chessman = chessman;
        }

        public bool MakeMove(Move move)
        {
            if (!MoveValid(move))
                throw new ArgumentException("Move is empty or invalid");
            board[move.X, move.Y] = move.CaroChessman;
            return HasWinner(move);
        }

        private bool HasWinner(Move move)
        {
            int count = 0;
            int maxCount = 0;
            int block = 0;
            foreach (var addition in additionVertical)
            {
                int x = move.X + addition.X;
                int y = move.Y + addition.Y;
                if (x < 0 || x >= CaroConstant.BOARD_SIZE)
                {
                    count = 0;
                    block = 0;
                }
                if (y < 0 || y >= CaroConstant.BOARD_SIZE)
                {
                    block = 0;
                    count = 0;
                }
                if (move.CaroChessman != board[x, y])
                {
                    count = 0;
                    if((int)move.CaroChessman == -(int)board[x, y])
                    {
                        block = 1;
                    }
                    else
                    {
                        block = 0;
                    }
                }
                if (move.CaroChessman == board[x, y])
                {
                    count++;
                    if(count == 5)
                    {

                    }    
                    if (count > maxCount)
                        maxCount = count;
                    
                }
            }
            if (maxCount >= 5)
                return true;
            return false;
        }

        private bool MoveValid(Move move)
        {
            if (move.X < 0 || move.X >= CaroConstant.BOARD_SIZE)
                return false;
            if (move.Y < 0 || move.Y >= CaroConstant.BOARD_SIZE)
                return false;
            if (board[move.X, move.Y] != CaroChessman.Empty)
                return false;
            return true;
        }
    }
}
