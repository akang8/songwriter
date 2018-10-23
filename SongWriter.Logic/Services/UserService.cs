using SongWriter.Logic.Models;
using SongWriter.Logic.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SongWriter.Logic.Services
{
    public class UserService : IUserService
    {
        public bool Authenticate(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public User GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public User GetItem(string name)
        {
            throw new NotImplementedException();
        }

        public int Register(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public int Remove(string userName)
        {
            throw new NotImplementedException();
        }

        public void UpdatePassword(string userName, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }
    }
}
