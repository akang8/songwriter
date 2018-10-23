using SongWriter.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SongWriter.Logic.Services.Abstractions
{
    public interface IUserService
    {
        int Register(string userName, string password);

        /// <summary>
        /// Update user name
        /// </summary>
        /// <remarks>
        /// Assumes user service knows current user
        /// </remarks>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        void UpdatePassword(string oldPassword, string newPassword);

        bool Authenticate(string userName, string attemptedPassword);

        User GetItem(int id);

        User GetItem(string userName);
    }
}
