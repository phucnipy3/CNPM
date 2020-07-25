using Common.Models;
using Data.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Data.BusinessLogic
{
    public class BLGame
    {
        public async Task<List<GameModel>> GetGamesAsync()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                return await db.Games.Where(x => x.Status == true).Select(x => new GameModel() 
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description
                }).ToListAsync();
            }
        }

        public async Task<Game> GetJustGameByNameAsync(string name)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                return await db.Games.Where(x => x.Name == name).FirstOrDefaultAsync();
            }
        }
    }
}
