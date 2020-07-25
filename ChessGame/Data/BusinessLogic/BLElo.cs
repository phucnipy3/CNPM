using Common.Models;
using Data.Common;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.BusinessLogic
{
    public class BLElo
    {
        
        public async static Task<List<RankTable>> GetRankTableAsync(RankConditionModel rankCondition)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var model = await db.Elos.Where(x => x.GameId == rankCondition.GameId).Select(y => new RankTable
                {
                    Id = y.User.Id,
                    Ingame = y.User.Username,
                    Point = y.EloPoint ?? 0
                }).OrderByDescending(z => z.Point).Take(10).ToListAsync();

                if(!model.Select(x => x.Id).Contains(rankCondition.UserId))
                {
                    model.Add(await db.Elos.Where(x => x.GameId == rankCondition.GameId && x.UserId == rankCondition.UserId).Select(y => new RankTable
                    {
                        Id = y.User.Id,
                        Ingame = y.User.Username,
                        Point = y.EloPoint ?? 0
                    }).FirstOrDefaultAsync());
                }

                return model;
            }
        }

        public async Task<List<Elo>> GetEloByGameIDAsync(int game_ID)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                return await db.Elos.Where(x => x.GameId == game_ID).OrderByDescending(x=>x.EloPoint).ToListAsync();
            }
        }
    }
}
