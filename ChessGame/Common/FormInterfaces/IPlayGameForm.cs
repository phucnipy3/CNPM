using Common.Models;
using System.Drawing;
using System.Threading.Tasks;

namespace Common.FormInterfaces
{
    public interface IPlayGameForm
    {
        void RefreshCurrentRoom(RoomInfomationModel roomInfo);
        Task RefreshCurrentRoomAsync();
        void RefreshBoard(Bitmap bitmap);
        void RefreshBoard();
        void AppendMessage(string message);
    }
}
