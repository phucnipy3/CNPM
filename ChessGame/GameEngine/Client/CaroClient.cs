using Common.Constants;
using Common.Enums;
using GameEngine.Models;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace GameEngine.Client
{
    public class CaroClient : GameClient
    {
        private CaroChessman[,] board;
        private int boardWidth;
        private int boardHeight;

        private int cellSize;
        public int CellSize
        {
            get
            {
                return cellSize;
            }
        }

        private int xOffset;
        private int yOffset;
        private CaroChessman currentChessman = CaroChessman.Empty;

        private CaroChessman chessman;

        public Bitmap BoardImage { get; private set; }

        public CaroClient(int boardWidth, int boardHeight, CaroChessman chessman)
        {
            board = new CaroChessman[CaroConstant.BOARD_SIZE, CaroConstant.BOARD_SIZE];
            this.boardWidth = boardWidth;
            this.boardHeight = boardHeight;
            cellSize = boardWidth < boardHeight ? (int)boardWidth / CaroConstant.BOARD_SIZE : (int)boardHeight / CaroConstant.BOARD_SIZE;
            int xOffset = (boardWidth - CaroConstant.BOARD_SIZE * cellSize) / 2;
            int yOffset = (boardHeight - CaroConstant.BOARD_SIZE * cellSize) / 2;
            this.chessman = chessman;

            DrawBoard(new CaroMove { Chessman = CaroChessman.Empty });
        }

        protected override void DrawBoard(IGameMove move)
        {
            CaroMove currentMove = move as CaroMove;
            currentChessman = currentMove.Chessman;
            Bitmap b = new Bitmap(boardWidth, boardHeight);
            Graphics g = Graphics.FromImage(b);

            for (int y = 0; y < CaroConstant.BOARD_SIZE; y++)
                for (int x = 0; x < CaroConstant.BOARD_SIZE; x++)
                {
                    Bitmap image = Properties.Resources.Empty;

                    if (board[y, x] == CaroChessman.O)
                    {
                        image = Properties.Resources.O;
                    }
                    else if (board[y, x] == CaroChessman.X)
                    {
                        image = Properties.Resources.X;
                    }
                    g.DrawImage(image, x * cellSize + xOffset, y * cellSize + yOffset, cellSize, cellSize);
                }
            if (currentChessman == CaroChessman.O)
            {
                g.DrawImage(Properties.Resources.CurrentO, currentMove.X * cellSize + xOffset, currentMove.Y * cellSize + yOffset, cellSize, cellSize);
            }
            else if (currentChessman == CaroChessman.X)
            {
                g.DrawImage(Properties.Resources.CurrentX, currentMove.X * cellSize + xOffset, currentMove.Y * cellSize + yOffset, cellSize, cellSize);
            }

            BoardImage = b;
            OnBoardUpdated(new BoardUpdatedEventArgs { BoardImage = b });
        }

        public void MakeOwnMove(int x, int y)
        {

            if (currentChessman == chessman)
                return;

            if (OutSideBoard(x, y))
                return;

            if (board[y, x] != CaroChessman.Empty)
                return;

            CaroMove move = new CaroMove { Chessman = chessman, X = x, Y = y };

            if (MakeMove(move))
            {
                move.GameEnded = true;
            };

            OnNewMoveMaked(new NewMoveMakedEventArgs { Move = move });
            DrawBoard(move);
        }

        public void MakeOpponentMove(CaroMove move)
        {
            if (move.Chessman != chessman.OppositeChessman())
                throw new InvalidOperationException("Invalid move");

            if (move.Chessman == currentChessman)
                throw new InvalidOperationException("Invalid move");

            if (OutSideBoard(move.X, move.Y))
                throw new InvalidOperationException("Invalid move");

            if (board[move.Y, move.Y] != CaroChessman.Empty)
                throw new InvalidOperationException("Invalid move");

            if (MakeMove(move) != move.GameEnded)
            {
                throw new InvalidOperationException("Invalid move");
            }
            DrawBoard(move);
        }



        private CaroFactor[] factors = {
            new CaroFactor { Factors = { new Point(0, -1), new Point(0, 1) } },
            new CaroFactor { Factors = { new Point(-1, 0),  new Point(1, 0) } },
            new CaroFactor { Factors = { new Point(-1, 1), new Point(1, -1) } },
            new CaroFactor { Factors = { new Point(-1, -1), new Point(1, 1) } }
        };
        private bool MakeMove(CaroMove move)
        {
            board[move.Y, move.X] = move.Chessman;
            currentChessman = move.Chessman;


            foreach (var factor in factors)
            {
                int count = 1;
                int otherCount = 0;

                foreach (var point in factor.Factors)

                    for (int i = 1; i <= 5; i++)
                    {
                        int x = move.X + i * point.X;
                        int y = move.Y + i * point.Y;

                        if (OutSideBoard(x, y))
                            break;

                        if (board[y, x] == currentChessman)
                        {
                            count++;
                        }
                        else
                        {
                            if (board[y, x] == currentChessman.OppositeChessman())
                            {
                                otherCount++;
                            }
                            break;
                        }
                    }
                if (count > 5 || (count == 5 && otherCount < 2))
                    return true;
            }

            return false;
        }



        private bool OutSideBoard(int x, int y)
        {
            return x < 0 || x >= CaroConstant.BOARD_SIZE || y < 0 || y >= CaroConstant.BOARD_SIZE;

        }

        public event EventHandler<NewMoveMakedEventArgs> NewMoveMaked;

        public virtual void OnNewMoveMaked(NewMoveMakedEventArgs e)
        {
            EventHandler<NewMoveMakedEventArgs> handler = NewMoveMaked;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }

    public class NewMoveMakedEventArgs : EventArgs
    {
        public CaroMove Move { get; set; }
    }

    public class CaroFactor
    {
        public List<Point> Factors { get; set; }
    }
}
