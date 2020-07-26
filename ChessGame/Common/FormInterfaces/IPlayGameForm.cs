using Common.Models;
using System.Drawing;

namespace Common.FormInterfaces
{
    public interface IPlayGameForm
    {
        void RefreshCurrentRoom(RoomInfomationModel roomInfo);
        void RefreshBoard(Bitmap bitmap);
        void RefreshBoard();
    }
}
