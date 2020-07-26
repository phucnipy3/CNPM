using Common.Models;
using Data.Common;
using Data.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
        public async Task<List<Friend>> GetFriendByUserNameAsync(int id)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var model = await db.Friendships.Where(x => x.UserId == id).Select(y => new Friend
                {
                    Id = y.FriendId.Value,
                    State = y.Friend.Active.Value ? "Hoạt động" : "Ngoại tuyến",
                    Username = y.Friend.Username
                }).ToListAsync();

                return model;
            }
        }

        public async Task<Friendship> GetJustFriendAsync(int user_ID, int friend_ID)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                return await db.Friendships.Where(x => x.UserId == user_ID && x.FriendId == friend_ID).SingleOrDefaultAsync();
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
                var friendshipToDelete = await db.Friendships.Where(x => (x.FriendId == friendship.FriendId && x.UserId == friendship.UserId) || (x.FriendId == friendship.UserId && x.UserId == friendship.FriendId)).ToListAsync();
                if (friendshipToDelete != null)
                {
                    db.Friendships.RemoveRange(friendshipToDelete);
                    await db.SaveChangesAsync();
                }
            }
        }

        public async Task<bool> ExistsFriendship(int user_ID, int friend_ID)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                return await db.Friendships.AnyAsync(x => x.UserId == user_ID && x.FriendId == friend_ID); 
            } 
        }

        public static async Task<bool> IsFriendsAsync(int id1, int id2)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                return await db.Friendships.AnyAsync(x => x.UserId == id1 && x.FriendId == id2) || await db.Friendships.AnyAsync(x => x.UserId == id2 && x.FriendId == id1);
            }
        }
    }
}
