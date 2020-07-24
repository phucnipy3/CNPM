using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Data.BusinessLogic
{
    public class BLNotification
    {
        public async Task AddNotificationAsync (Notification notification)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                db.Notifications.Add(notification);
                await db.SaveChangesAsync();
            }
        }
    }
}
