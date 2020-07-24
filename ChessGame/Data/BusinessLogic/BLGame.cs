using Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.BusinessLogic
{
    public class BLGame
    {
        public async Task<List<Game>> GetAllGameAsync()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                return await db.Games.Where(x=>x.Status == true).ToListAsync();
            }
        }

        public async Task<Game> GetJustGameByNameAsync(string name)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                return await db.Games.Where(x => x.Name == name).SingleOrDefaultAsync();
            }
        }
    }
}
