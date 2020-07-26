using Common.Models;
using System;
using System.Drawing;

namespace GameEngine.Client
{
    public abstract class GameClient
    {
        protected abstract void DrawBoard(IGameMove currentMove);

        public event EventHandler<BoardUpdatedEventArgs> BoardUpdated;

        public virtual void OnBoardUpdated(BoardUpdatedEventArgs e)
        {
            EventHandler<BoardUpdatedEventArgs> handler = BoardUpdated;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }

    public class BoardUpdatedEventArgs : EventArgs
    {
        public Bitmap BoardImage { get; set; }
    }
}
