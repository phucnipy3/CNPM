using Common.Models;
using Data.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Data.BusinessLogic
{
    public class BLRoom
    {
        public static async Task<List<RoomModel>> GetRoomsAsync(int gameId)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var data = await db.Rooms.Where(x => x.GameID == gameId).Select(x => new RoomModel()
                {
                    RoomId = x.ID,
                    GameId = x.ID,
                    FirstPlayerId = x.FirstPlayerID,
                    SecondPlayerId = x.SecondPlayerID
                }).ToListAsync();
                return data;
            }
        }
    }
}
