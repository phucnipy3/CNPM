using Common.Constants;
using Common.Enums;
using Common.Models;
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
        private int roomId;

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
        private CaroChessman lastChessman = CaroChessman.X;

        private CaroChessman chessman;

        public Bitmap BoardImage { get; private set; }

        public CaroClient(int boardWidth, int boardHeight, CaroChessman chessman, int roomId)
        {
            this.roomId = roomId;
            board = new CaroChessman[CaroConstant.BOARD_SIZE, CaroConstant.BOARD_SIZE];
            this.boardWidth = boardWidth;
            this.boardHeight = boardHeight;
            cellSize = boardWidth < boardHeight ? (int)boardWidth / CaroConstant.BOARD_SIZE : (int)boardHeight / CaroConstant.BOARD_SIZE;
            xOffset = (boardWidth - CaroConstant.BOARD_SIZE * cellSize) / 2;
            yOffset = (boardHeight - CaroConstant.BOARD_SIZE * cellSize) / 2;
            this.chessman = chessman;

            DrawBoard(new CaroMove { Chessman = CaroChessman.Empty });
        }

        protected override void DrawBoard(IGameMove move)
        {
            CaroMove currentMove = move as CaroMove;
            lastChessman = currentMove.Chessman;
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
            if (lastChessman == CaroChessman.O)
            {
                g.DrawImage(Properties.Resources.CurrentO, currentMove.X * cellSize + xOffset, currentMove.Y * cellSize + yOffset, cellSize, cellSize);
            }
            else if (lastChessman == CaroChessman.X)
            {
                g.DrawImage(Properties.Resources.CurrentX, currentMove.X * cellSize + xOffset, currentMove.Y * cellSize + yOffset, cellSize, cellSize);
            }
            else
            {
                lastChessman = CaroChessman.X;
            }
            BoardImage = b;
            OnBoardUpdated(new BoardUpdatedEventArgs { BoardImage = b });
        }

        public void MakeOwnMove(int x, int y)
        {

            if (lastChessman == chessman)
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

            OnNewMoveMaked(new NewMoveMakedEventArgs { Move = move, RoomId = roomId });
            DrawBoard(move);
        }

        public void MakeOpponentMove(CaroMove move)
        {
            if (move.Chessman != chessman.OppositeChessman())
                throw new InvalidOperationException("Invalid move");

            if (move.Chessman == lastChessman)
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

            if (move.GameEnded)
                OnGameEnded(new GameEndedEventArgs() { RoomId = roomId });
        }

        private List<CaroFactor> factors = new List<CaroFactor>() {
            new CaroFactor { Factors = new List<Point>() { new Point(0, -1), new Point(0, 1) } },
            new CaroFactor { Factors = new List<Point>() { new Point(-1, 0),  new Point(1, 0) } },
            new CaroFactor { Factors = new List<Point>() { new Point(-1, 1), new Point(1, -1) } },
            new CaroFactor { Factors = new List<Point>() { new Point(-1, -1), new Point(1, 1) } }
        };
        private bool MakeMove(CaroMove move)
        {
            board[move.Y, move.X] = move.Chessman;
            lastChessman = move.Chessman;


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

                        if (board[y, x] == lastChessman)
                        {
                            count++;
                        }
                        else
                        {
                            if (board[y, x] == lastChessman.OppositeChessman())
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
        public event EventHandler<GameEndedEventArgs> GameEnded;

        public virtual void OnNewMoveMaked(NewMoveMakedEventArgs e)
        {
            EventHandler<NewMoveMakedEventArgs> handler = NewMoveMaked;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public virtual void OnGameEnded(GameEndedEventArgs e)
        {
            EventHandler<GameEndedEventArgs> handler = GameEnded;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }

    public class NewMoveMakedEventArgs : EventArgs
    {
        public CaroMove Move { get; set; }
        public int RoomId { get; set; }
    }

    public class GameEndedEventArgs : EventArgs
    {
        public int RoomId { get; set; }
    }

    public class CaroFactor
    {
        public List<Point> Factors { get; set; }
    }
}
