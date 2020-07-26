using Common.Constants;
using Common.Enums;
using Common.Models;
using System;

namespace GameEngine.Server
{
    public class CaroServer : GameServer
    {
        public RoomInfomationModel Room { get; private set; }
        private CaroChessman[,] board;
        private int lastPlayerId;
        private CaroMove tempMove = null;
        public event EventHandler<GameEndedEventArgs> GameEnded;

        public CaroServer(RoomInfomationModel room)
        {
            Room = room;
            lastPlayerId = -1;
            board = new CaroChessman[CaroConstant.BOARD_SIZE, CaroConstant.BOARD_SIZE];
        }

        public void MakeMove(int senderId, CaroMove move)
        {
            if (lastPlayerId == senderId)
                throw new InvalidOperationException("Conflict sender!");

            if (move.GameEnded && tempMove.GameEnded)
            {
                OnGameEnded(new GameEndedEventArgs() { WinnerId = lastPlayerId, LoserId = senderId, RoomId = Room.RoomId });
                return;
            }    

            if (tempMove != null)
            {
                board[tempMove.Y, tempMove.X] = tempMove.Chessman;
            }

            tempMove = move;
            lastPlayerId = senderId;
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

    public class GameEndedEventArgs : EventArgs
    {
        public int WinnerId { get; set; }
        public int LoserId { get; set; }
        public int RoomId { get; set; }
    }
}
