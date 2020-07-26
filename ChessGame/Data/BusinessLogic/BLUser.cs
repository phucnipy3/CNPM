using Common.Enums;
using Common.Models;
using Data.Common;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.OleDb;
using System.Linq;
using System.Threading.Tasks;

namespace Data.BusinessLogic
{
    public class BLUser
    {
        public async Task<List<User>> GetUsersAsync()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                return await db.Users.Where(x => x.Status == true).ToListAsync();
            }
        }

        //public async Task<int> LoginAsync(string userName, string pass)
        //{
        //    using (DatabaseContext db = new DatabaseContext())
        //    {
        //        string passEncrypt = encryptor.MD5Hash(pass);
        //        if (await db.Users.AnyAsync(x => x.UserName == userName && x.Password == passEncrypt && x.Status == true && x.Permission == 2))
        //        {
        //            return 2; // user
        //        }
        //        else if (await db.Users.AnyAsync(x => x.UserName == userName && x.Password == passEncrypt && x.Status == true && x.Permission == 1))
        //        {
        //            return 1; // admin
        //        }
        //        else
        //        {
        //            return 0;
        //        }                    
        //    }
        //}

        public async Task<UserModel> LoginAsync(string userName, string pass)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                string passEncrypt = Encryptor.MD5Hash(pass);
                var user = await db.Users.Where(x => x.Username == userName && x.Password == passEncrypt).Select(x => new UserModel()
                {
                    Id = x.Id,
                    Username = x.Username,
                    Name = x.Name,
                    Avatar = x.Avatar,
                    Phone = x.Phone,
                    Email = x.Email,
                    Experience = x.Id,
                    Permission = x.Permission ?? 0
                }).FirstOrDefaultAsync();
                return user;
            }
        }

        public async static Task<List<User>> GetAllUserAsync()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                return await db.Users.ToListAsync();
            }
        }

        public async static Task<List<UserModel>> GetAllManageUserAsync()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                //return await db.Users.ToListAsync();
                return await db.Users.Select(x => new UserModel()
                {
                    Id = x.Id,
                    Username = x.Username,
                    Name = x.Name,
                    Avatar = x.Avatar,
                    Phone = x.Phone,
                    Email = x.Email,
                    Experience = x.Experience ?? 0,
                    Permission = x.Permission ?? 0
                }).ToListAsync();
            }
        }


        public async Task<string> GetEmailByUsernameAsync(string username)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                return await db.Users.Where(x => x.Username == username).Select(x => x.Email).FirstOrDefaultAsync();
            }
        }

        public async Task<bool> Exists(string username)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                return await db.Users.AnyAsync(x => x.Username == username);
            }
        }

        public async Task<User> GetJustUserAsync(string username)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                return await db.Users.Where(x => x.Username == username).SingleOrDefaultAsync();
            }
        }

        public async static Task<UserModel> GetJustUserByIDAsync(int ID)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
               // return await db.Users.Where(x => x.Id == ID).SingleOrDefaultAsync();
                return await db.Users.Where(x => x.Id == ID).Select(x => new UserModel()
                {
                    Id = x.Id,
                    Username = x.Username,
                    Name = x.Name,
                    Avatar = x.Avatar,
                    Phone = x.Phone,
                    Email = x.Email,
                    Experience = x.Experience ?? 0,
                    Permission = x.Permission ?? 0
                }).FirstOrDefaultAsync();
            }
        }

        public async Task SignupAsync(User user)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                db.Users.Add(user);
                await db.SaveChangesAsync();
            }
        }

        public async Task SignupAsync(RegisterModel registerModel)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                User newUser = new User();
                newUser.Username = registerModel.Username;
                newUser.Name = registerModel.Username;
                newUser.Password = Encryptor.MD5Hash(registerModel.Password);
                newUser.Experience = 0;
                newUser.Active = false;
                newUser.Status = true;
                newUser.Permission = (int)UserRole.Player;

                db.Users.Add(newUser);
                await db.SaveChangesAsync();
            }
        }

        public async Task ChangeActiveAsync(string userName, bool active)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                User user = await db.Users.Where(x => x.Username == userName).SingleOrDefaultAsync();
                if (user != null)
                {
                    user.Active = active;
                    await db.SaveChangesAsync();
                }
            }
        }

        public async Task ChangeActiveAsync(int userId, bool active)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                User user = await db.Users.Where(x => x.Id == userId).SingleOrDefaultAsync();
                if (user != null)
                {
                    user.Active = active;
                    await db.SaveChangesAsync();
                }
            }
        }

        public async static Task<bool> ChangeStatusAsync(string userName, bool status)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                User user = await db.Users.Where(x => x.Username == userName).FirstOrDefaultAsync();
                if (user != null)
                {
                    user.Status = status;
                    await db.SaveChangesAsync();
                    return true;
                }
                return false;

            }
        }

        public async Task<bool> ChangePasswordAsync(string userName, string newpass)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                try
                {
                    User user = await db.Users.Where(x => x.Username == userName).FirstOrDefaultAsync();
                    user.Password = Encryptor.MD5Hash(newpass);
                    await db.SaveChangesAsync();
                    return true;
                }
                catch
                {
                    return false;
                }
                
            }
        }

        public async static Task<List<ManagerUser>> ManagerUserAsync()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var data = await db.Users.Where(x => x.Permission == (int)UserRole.Player).Select(x => new ManagerUser()
                {
                    ID = x.Id,
                    Ingame = x.Username,
                    Status = x.Status ?? false
                }).ToListAsync();

                return data;
            }
        }

        public async Task<List<InviteUser>> InviteUserAsync(int id)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                List<InviteUser> lstInviteUsers = new List<InviteUser>();
                List<User> lstUsers = await GetAllUserAsync();

                for (int i = 0; i < lstUsers.Count; i++)
                {
                    if (lstUsers[i].Id != id && lstUsers[i].Permission != 1)
                    {
                        InviteUser invite = new InviteUser();
                        invite.ingame = lstUsers[i].Username;

                        lstInviteUsers.Add(invite);
                    }
                }

                return lstInviteUsers;
            }
        }

        public async Task<MessageModel> ChangePassword(ChangePasswordModel changePasswordModel)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                MessageModel messageModel = new MessageModel();
                var user = await db.Users.Where(x => x.Id == changePasswordModel.UserId).FirstOrDefaultAsync();
                if (user != null)
                {
                    if (user.Password == Encryptor.MD5Hash(changePasswordModel.OldPassword))
                    {
                        user.Password = Encryptor.MD5Hash(changePasswordModel.NewPassword);
                        await db.SaveChangesAsync();
                        messageModel.Code = (int)MessageCode.Success;
                        messageModel.Data = "Đổi mật khẩu thành công";
                        return messageModel;
                    }
                    else messageModel.Data = "Mật khẩu cũ không chính xác";
                } 
                else messageModel.Data = "Không tìm thấy tài khoản trên máy chủ";

                messageModel.Code = (int)MessageCode.Error;
                return messageModel;
            }
        }

        public async Task<MessageModel> UpdateProfile(UserModel userModel)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                MessageModel messageModel = new MessageModel();
                var user = await db.Users.Where(x => x.Id == userModel.Id).FirstOrDefaultAsync();
                if (user != null)
                {
                    user.Name = userModel.Name;
                    user.Phone = userModel.Phone;
                    user.Email = userModel.Email;
                    await db.SaveChangesAsync();

                    messageModel.Code = (int)MessageCode.Success;
                    messageModel.Data = userModel;
                    return messageModel;
                }
                else messageModel.Data = "Không tìm thấy tài khoản trên máy chủ";

                messageModel.Code = (int)MessageCode.Error;
                return messageModel;
            }
        }

        public async Task<bool> AddFriend(AddFriendModel addFriendModel)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                int? userId = await db.Users.Where(x => x.Username == addFriendModel.UserName).Select(x => x.Id).FirstOrDefaultAsync();
                int? friendId = await db.Users.Where(x => x.Username == addFriendModel.FriendName).Select(x => x.Id).FirstOrDefaultAsync();

                if (!userId.HasValue || !friendId.HasValue)
                    return false;

                db.Friendships.Add(new Friendship()
                {
                    UserId = userId,
                    FriendId = friendId,
                    AddTime = DateTime.Now
                });

                db.Friendships.Add(new Friendship()
                {
                    UserId = friendId,
                    FriendId = userId,
                    AddTime = DateTime.Now
                });

                await db.SaveChangesAsync();
                return true;
            }
        }
    }
}
