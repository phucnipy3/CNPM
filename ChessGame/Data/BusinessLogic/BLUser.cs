﻿using Common.Enums;
using Common.Models;
using Data.Common;
using Data.Entities;
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
                var user = await db.Users.Where(x => x.UserName == userName && x.Password == passEncrypt).Select(x => new UserModel()
                {
                    Id = x.ID,
                    Username = x.UserName,
                    Name = x.Name,
                    Avatar = x.Avatar,
                    Phone = x.Phone,
                    Email = x.Email,
                    Experience = x.ID,
                    Permission = x.Permission ?? 0
                }).FirstOrDefaultAsync();
                return user;
            }
        }

        public async Task<List<User>> GetAllUserAsync()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                return await db.Users.ToListAsync();
            }
        }

        public async Task<string> GetEmailByUsernameAsync(string username)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                return await db.Users.Where(x => x.UserName == username).Select(x => x.Email).FirstOrDefaultAsync();
            }
        }

        public async Task<bool> Exists(string username)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                return await db.Users.AnyAsync(x => x.UserName == username);
            }
        }

        public async Task<User> GetJustUserAsync(string username)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                return await db.Users.Where(x => x.UserName == username).SingleOrDefaultAsync();
            }
        }

        public async Task<User> GetJustUserByIDAsync(int ID)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                return await db.Users.Where(x => x.ID == ID).SingleOrDefaultAsync();
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
                newUser.UserName = registerModel.Username;
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
                User user = await db.Users.Where(x => x.UserName == userName).SingleOrDefaultAsync();
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
                User user = await db.Users.Where(x => x.ID == userId).SingleOrDefaultAsync();
                if (user != null)
                {
                    user.Active = active;
                    await db.SaveChangesAsync();
                }
            }
        }

        public async Task ChangeStatusAsync(string userName, bool status)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                User user = await db.Users.Where(x => x.UserName == userName).SingleOrDefaultAsync();
                if (user != null)
                {
                    user.Status = status;
                    await db.SaveChangesAsync();
                }

            }
        }

        public async Task ChangePasswordAsync(string userName, string newpass)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                User user = await db.Users.Where(x => x.UserName == userName).FirstOrDefaultAsync();
                user.Password = Encryptor.MD5Hash(newpass);
                await db.SaveChangesAsync();
            }
        }

        public async Task<List<ManagerUser>> ManagerUserAsync(int id)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                List<ManagerUser> lstManagerUsers = new List<ManagerUser>();
                List<User> lstUsers = await GetAllUserAsync();

                for (int i = 0; i < lstUsers.Count; i++)
                {
                    if (lstUsers[i].ID != id && lstUsers[i].Permission != 1)
                    {
                        ManagerUser managerUser = new ManagerUser();
                        managerUser.ID = lstUsers[i].ID;
                        managerUser.Ingame = lstUsers[i].UserName;
                        managerUser.Status = lstUsers[i].Status.GetValueOrDefault();

                        lstManagerUsers.Add(managerUser);
                    }
                }

                return lstManagerUsers;
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
                    if (lstUsers[i].ID != id && lstUsers[i].Permission != 1)
                    {
                        InviteUser invite = new InviteUser();
                        invite.ingame = lstUsers[i].UserName;

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
                var user = await db.Users.Where(x => x.ID == changePasswordModel.UserId).FirstOrDefaultAsync();
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
                var user = await db.Users.Where(x => x.ID == userModel.Id).FirstOrDefaultAsync();
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
    }
}
