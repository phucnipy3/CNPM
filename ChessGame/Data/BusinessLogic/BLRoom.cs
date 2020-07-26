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
        public static async Task<List<RoomInfomationModel>> GetRoomsAsync(int gameId, string search)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var data = db.Rooms.AsQueryable();

                if (!string.IsNullOrEmpty(search))
                    data = data.Where(x => x.Id.ToString().Contains(search));

                data = data.Where(x => x.GameId == gameId);

                return await data.Select(x => new RoomInfomationModel()
                {
                    RoomId = x.Id,
                    GameId = x.Id,
                    FirstPlayer = x.FirstPlayerId.HasValue ? new UserModel()
                    {
                        Id = x.FirstPlayer.Id,
                        Name = x.FirstPlayer.Name,
                        Avatar = x.FirstPlayer.Avatar,
                        Email = x.FirstPlayer.Email,
                        Phone = x.FirstPlayer.Phone,
                        Experience = x.FirstPlayer.Experience ?? 0,
                        Permission = x.FirstPlayer.Permission ?? 2,
                    } : null,
                    SecondPlayer = x.SecondPlayerId.HasValue ? new UserModel()
                    {
                        Id = x.SecondPlayer.Id,
                        Name = x.SecondPlayer.Name,
                        Avatar = x.SecondPlayer.Avatar,
                        Email = x.SecondPlayer.Email,
                        Phone = x.SecondPlayer.Phone,
                        Experience = x.SecondPlayer.Experience ?? 0,
                        Permission = x.SecondPlayer.Permission ?? 2,
                    } : null
                }).ToListAsync();
            }
        }

        public static async Task<RoomInfomationModel> CreateRoom(int userId, int gameId)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                Room room = new Room();
                room.FirstPlayerId = userId;
                room.GameId = gameId;
                room.Active = true;
                room.Status = true;
                db.Rooms.Add(room);
                await db.SaveChangesAsync();

                return await db.Rooms.Where(x => x.Id == room.Id).Select(x => new RoomInfomationModel()
                {
                    RoomId = x.Id,
                    GameId = x.Id,
                    FirstPlayer = x.FirstPlayerId.HasValue ? new UserModel()
                    {
                        Id = x.FirstPlayer.Id,
                        Name = x.FirstPlayer.Name,
                        Avatar = x.FirstPlayer.Avatar,
                        Email = x.FirstPlayer.Email,
                        Phone = x.FirstPlayer.Phone,
                        Experience = x.FirstPlayer.Experience ?? 0,
                        Permission = x.FirstPlayer.Permission ?? 2,
                    } : null
                }).FirstOrDefaultAsync();
            }
        }

        public static async Task<RoomInfomationModel> JoinRoom(int userId, int roomId)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                Room room = await db.Rooms.Where(x => x.Id == roomId && x.Status == true).FirstOrDefaultAsync();
                if (room == null)
                    return null;

                if (room.FirstPlayerId.HasValue && room.SecondPlayerId.HasValue)
                    return null;

                if (room.FirstPlayerId.HasValue)
                    room.SecondPlayerId = userId;
                else room.FirstPlayerId = userId;

                await db.SaveChangesAsync();

                return await db.Rooms.Where(x => x.Id == room.Id).Select(x => new RoomInfomationModel()
                {
                    RoomId = x.Id,
                    GameId = x.Id,
                    FirstPlayer = x.FirstPlayerId.HasValue ? new UserModel()
                    {
                        Id = x.FirstPlayer.Id,
                        Name = x.FirstPlayer.Name,
                        Avatar = x.FirstPlayer.Avatar,
                        Email = x.FirstPlayer.Email,
                        Phone = x.FirstPlayer.Phone,
                        Experience = x.FirstPlayer.Experience ?? 0,
                        Permission = x.FirstPlayer.Permission ?? 2,
                    } : null,
                    SecondPlayer = x.SecondPlayerId.HasValue ? new UserModel()
                    {
                        Id = x.SecondPlayer.Id,
                        Name = x.SecondPlayer.Name,
                        Avatar = x.SecondPlayer.Avatar,
                        Email = x.SecondPlayer.Email,
                        Phone = x.SecondPlayer.Phone,
                        Experience = x.SecondPlayer.Experience ?? 0,
                        Permission = x.SecondPlayer.Permission ?? 2,
                    } : null
                }).FirstOrDefaultAsync();
            }
        }
    }
}
