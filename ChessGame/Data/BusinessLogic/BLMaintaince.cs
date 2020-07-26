using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.BusinessLogic
{
    public class BLMaintaince
    {
        public async static Task<bool> AddMaintainceAsync(MaintainceInfomation maintaince )
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                try
                {
                    db.MaintainceInfomations.Add(maintaince);
                    await db.SaveChangesAsync();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
