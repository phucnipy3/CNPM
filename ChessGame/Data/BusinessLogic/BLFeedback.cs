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

        public async Task<bool> AddFeedbackAsync(Feedback feedback)
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

        public async Task<List<CheckFeedback>> CheckFeedbackAsync()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                List<CheckFeedback> lstcheckFeedbacks = new List<CheckFeedback>();

                List<Feedback> feedbacks = await GetAllFeedbackAsync();

                for (int i=0; i< feedbacks.Count; i++)
                {
                    BLUser bLUser = new BLUser();
                    User user = await bLUser.GetJustUserByIDAsync(feedbacks[i].UserID.Value);
                    CheckFeedback checkFeedback = new CheckFeedback();
                    checkFeedback.sender = user.Name;
                    checkFeedback.content = feedbacks[i].Content;

                    lstcheckFeedbacks.Add(checkFeedback);

                }
                return lstcheckFeedbacks;

            }
        }

        public async Task<List<Feedback>> GetAllFeedbackAsync()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                return await db.Feedbacks.Where(x => x.Status == true).ToListAsync();
            }
        }
    }
}
