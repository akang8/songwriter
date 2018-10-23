using SongWriter.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SongWriter.Logic.Services.Abstractions
{
    public interface IUserService
    {
        int Register(string userName, string password);

        void UpdatePassword(string userName, string oldPassword, string newPassword);

        int Remove(string userName);

        bool Authenticate(string userName, string password);

        User GetItem(int id);

        User GetItem(string name);
    }
}
