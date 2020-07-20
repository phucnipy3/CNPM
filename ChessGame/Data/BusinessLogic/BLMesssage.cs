using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.BusinessLogic
{
    public class BLMesssage
    {
        public async Task<bool> AddMessageAsync(Message message)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                try
                {
                    db.Messages.Add(message);
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

