using Common.Constants;
using Common.Enums;
using GameEngine.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
            CaroMove move = new CaroMove { Chessman = chessman, X = x, Y = y };

            // coordinate, turn
            //if(move valid)



            if (MakeMove(move))
            {
                move.GameEnded = true;
            };

            OnNewMoveMaked(new NewMoveMakedEventArgs { Move = move });
            DrawBoard(move);
        }

        public void MakeOpponentMove(CaroMove move)
        {
            
            // coordinate, turn
            //if(move valid)
            //else throw

            if (MakeMove(move) != move.GameEnded)
            {
                throw new InvalidOperationException("Invalid move");
            }
            DrawBoard(move);
        }

        private bool MakeMove(CaroMove move)
        {
            board[move.Y, move.X] = move.Chessman;

            //check win
            return false; //win or not;
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


}
