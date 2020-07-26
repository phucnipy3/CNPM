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
    public class BLFeedback
    {

        public async static Task<bool> AddFeedbackAsync(Feedback feedback)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                try
                {
                    db.Feedbacks.Add(feedback);
                    await db.SaveChangesAsync();
                    return true;
                }
                catch
                {
                    return false;
                }
                
            }
        }

        public async static Task<List<CheckFeedback>> CheckFeedbackAsync()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                List<CheckFeedback> lstcheckFeedbacks = new List<CheckFeedback>();

                List<FeedbackModel> feedbacks = await GetAllFeedbackAsync();

                for (int i=0; i< feedbacks.Count; i++)
                {
                    BLUser bLUser = new BLUser();
                    UserModel user = await BLUser.GetJustUserByIDAsync(feedbacks[i].UserId.Value);
                    CheckFeedback checkFeedback = new CheckFeedback();
                    checkFeedback.sender = user.Name;
                    checkFeedback.content = feedbacks[i].Content;

                    lstcheckFeedbacks.Add(checkFeedback);

                }
                return lstcheckFeedbacks;

            }
        }

        public async static Task<List<FeedbackModel>> GetAllFeedbackAsync()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                //return await db.Feedbacks.Where(x => x.Status == true).ToListAsync();
                return await db.Feedbacks.Where(x => x.Status == true).Select(x => new FeedbackModel()
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    Email = x.Email,
                    Content = x.Content,
                    SendTime = x.SendTime,
                    Seen = x.Seen,
                    Status = x.Status,
                }).ToListAsync();
            }
        }
    }
}
