using Common.Models;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.BusinessLogic
{
    public class BLMesssage
    {
        public async static Task<bool> AddMessageAsync(SendMessageModel message)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                try
                {
                    int? senderId = await db.Users.Where(x => x.Username == message.SenderName).Select(x => x.Id).FirstOrDefaultAsync();
                    int? receiverId = await db.Users.Where(x => x.Username == message.ReceiverName).Select(x => x.Id).FirstOrDefaultAsync();
                    db.Messages.Add(new Message()
                    {
                        SenderId = senderId,
                        ReceiverId = receiverId,
                        Content = message.Content,
                        SendTime = DateTime.Now
                    }) ;
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

