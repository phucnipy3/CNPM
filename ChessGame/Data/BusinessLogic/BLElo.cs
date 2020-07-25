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
        
        public async Task<List<RankTable>> GetRankTableAsync(int game_ID)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                List<RankTable> lstRank = new List<RankTable>();
                List<Elo> lstElos = await GetEloByGameIDAsync(game_ID);
                
                for (int i = 0; i< lstElos.Count; i++)
                {
                    BLUser bLUser = new BLUser();
                    User user = new User();
                    user = await bLUser.GetJustUserByIDAsync(lstElos[i].UserId.Value);

                    RankTable rankTable = new RankTable();
                    rankTable.rank = i + 1;
                    rankTable.ingame = user.Username;
                    rankTable.point = lstElos[i].EloPoint.GetValueOrDefault();

                    lstRank.Add(rankTable);
                }
                return lstRank;
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
