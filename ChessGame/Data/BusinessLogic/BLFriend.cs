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
    public class BLFriend
    {
        private BLUser bLUser;
        public BLFriend()
        {
            bLUser = new BLUser();
        }
        public async Task<List<Friend>> GetFriendByUserNameAsync(int ID)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                List<Friendship> lstFriendships = db.Friendships.Where(x => x.UserID == ID).ToList();

                List<Friend> lstUsers = new List<Friend>();
                for (int i = 0; i < lstFriendships.Count; i++)
                {
                    User users = new User();
                    users = await bLUser.GetJustUserByIDAsync(lstFriendships[i].FriendID.Value);
                    Friend friend = new Friend();
                    friend.Id = users.ID;
                    friend.Username = users.UserName;
                    friend.Active = users.Active.GetValueOrDefault();
                    lstUsers.Add(friend);
                }
                return lstUsers;
            }
        }

        public async Task<Friendship> GetJustFriendAsync(int user_ID, int friend_ID)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                return await db.Friendships.Where(x => x.UserID == user_ID && x.FriendID == friend_ID).SingleOrDefaultAsync();
            }
        }

        public async Task AddFriendAsync(Friendship friendship)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                db.Friendships.Add(friendship);
                await db.SaveChangesAsync();
            }
        }

        public async Task DeleteFriendAsync(Friendship friendship)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                db.Entry(friendship).State = EntityState.Deleted;

                await db.SaveChangesAsync();
            }
        }
        public async Task DeleteFriendAsync(FriendshipModel friendship)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var friendshipToDelete = await db.Friendships.Where(x => x.FriendID == friendship.FriendId && x.UserID == friendship.UserId).FirstOrDefaultAsync();
                if (friendshipToDelete != null)
                {
                    db.Friendships.Remove(friendshipToDelete);
                    await db.SaveChangesAsync();
                }
            }
        }

        public async Task<bool> ExistsFriendship(int user_ID, int friend_ID)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                return await db.Friendships.AnyAsync(x => x.UserID == user_ID && x.FriendID == friend_ID);
            }
        }
    }
}
