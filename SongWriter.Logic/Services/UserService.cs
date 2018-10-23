using AutoMapper.QueryableExtensions;
using SongWriter.Logic.Models;
using SongWriter.Logic.Processing.Abstractions;
using SongWriter.Logic.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using data = SongWriter.Data.Models;

namespace SongWriter.Logic.Services
{
    public class UserService : IUserService
    {
        private readonly AppLogicContext context;
        private readonly IHasher hasher;

        public UserService(AppLogicContext context, IHasher hasher)
        {
            this.context = context;
            this.hasher = hasher;
        }

        public bool Authenticate(string userName, string attemptedPassword)
        {
            var attemptedPasswordHash = this.hasher.Hash(attemptedPassword);
            var count = this.context.AppData.Users
                                                .Where(u => u.Name == userName
                                                        && u.Password == attemptedPasswordHash)
                                                .Count();

            // TODO: what to do if there is more than 1 record returned?
            if(count == 1)
            {
                return true;
            }

            return false;
        }

        public User GetItem(int id)
        {
            var user = this.context.AppData.Users
                                                .Where(u => u.Id == id)
                                                .ProjectTo<User>()
                                                .SingleOrDefault();

            return user;
        }

        public User GetItem(string userName)
        {
            var user = this.context.AppData.Users
                                                .Where(u => u.Name == userName)
                                                .ProjectTo<User>()
                                                .SingleOrDefault();

            return user;
        }

        public int Register(string userName, string password)
        {
            var user = new data.User()
            {
                Name = userName,
                Password = this.hasher.Hash(password)
            };

            this.context.AppData.Add(user);
            this.context.AppData.SaveChanges();

            return user.Id;
        }

        public void UpdatePassword(string oldPassword, string newPassword)
        {
            var oldPasswordHashed = this.hasher.Hash(oldPassword);
            var userName = this.context.UserName;
            var user = this.context.AppData.Users
                                                .Where(u => u.Name == userName
                                                        && u.Password == oldPasswordHashed)                                                
                                                .SingleOrDefault();

            // Update password
            user.Password = this.hasher.Hash(newPassword);

            this.context.AppData.SaveChanges();
        }
    }
}
