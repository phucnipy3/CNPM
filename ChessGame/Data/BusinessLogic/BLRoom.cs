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
                var data = await db.Rooms.Where(x => x.GameId == gameId).Select(x => new RoomModel()
                {
                    RoomId = x.Id,
                    GameId = x.Id,
                    FirstPlayerId = x.FirstPlayerId,
                    SecondPlayerId = x.SecondPlayerId
                }).ToListAsync();
                return data;
            }
        }
    }
}
