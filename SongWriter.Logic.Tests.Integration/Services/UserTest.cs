using Microsoft.VisualStudio.TestTools.UnitTesting;
using SongWriter.TestSupport;
using System;
using System.Collections.Generic;
using System.Text;

namespace SongWriter.Logic.Tests.Integration.Services
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void CanAccessUserService()
        {
            var context = Provider.GetContext();

            Assert.IsNotNull(context.Users);
        }

        [TestMethod]
        public void CanCallRegister()
        {
            var context = Provider.GetContext();

            context.Users.Register(RandomValueGenerator.AlphaNumericText(5, 10), RandomValueGenerator.AlphaNumericText(10, 20));
        }

        [TestMethod]
        public void CanRegisterUser()
        {
            var context = Provider.GetContext();

            var userName = RandomValueGenerator.AlphaNumericText(5, 10);
            var password = RandomValueGenerator.AlphaNumericText(10, 20);

            var id = context.Users.Register(userName, password);

            Assert.AreNotEqual(0, id);
        }

        [TestMethod]
        public void CanGetUserCorrectly()
        {
            var context = Provider.GetContext();

            var userName = RandomValueGenerator.AlphaNumericText(5, 10);
            var password = RandomValueGenerator.AlphaNumericText(10, 20);

            var id = context.Users.Register(userName, password);

            var user = context.Users.GetItem(id);

            Assert.IsNotNull(user);
            Assert.AreEqual(id, user.Id);
            Assert.AreEqual(userName, user.Name);
        }

        [TestMethod]
        public void CanGetUserByNameCorrectly()
        {
            var context = Provider.GetContext();

            var userName = RandomValueGenerator.AlphaNumericText(5, 10);
            var password = RandomValueGenerator.AlphaNumericText(10, 20);

            var id = context.Users.Register(userName, password);

            var user = context.Users.GetItem(userName);

            Assert.IsNotNull(user);
            Assert.AreEqual(id, user.Id);
            Assert.AreEqual(userName, user.Name);
        }

        [TestMethod]
        public void CanAuthenticateUserWithCorrectPassword()
        {
            var context = Provider.GetContext();

            var userName = RandomValueGenerator.AlphaNumericText(5, 10);
            var password = RandomValueGenerator.AlphaNumericText(10, 20);

            var id = context.Users.Register(userName, password);

            var result = context.Users.Authenticate(userName, password);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanRejectUserWithIncorrectPassword()
        {
            var context = Provider.GetContext();

            var userName = RandomValueGenerator.AlphaNumericText(5, 10);
            var password = RandomValueGenerator.AlphaNumericText(10, 20);

            var id = context.Users.Register(userName, password);

            var result = context.Users.Authenticate(userName, RandomValueGenerator.AlphaNumericText(10, 20));

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CanUpdatePassword()
        {
            var context = Provider.GetContext();

            var userName = RandomValueGenerator.AlphaNumericText(5, 10);
            var password = RandomValueGenerator.AlphaNumericText(10, 20);
            var newPassword = RandomValueGenerator.AlphaNumericText(10, 20);

            var id = context.Users.Register(userName, password);

            // Pretend to sign in
            Provider.SimulateLogin(id, userName);

            context.Users.UpdatePassword(password, newPassword);

            var result = context.Users.Authenticate(userName, newPassword);

            Assert.IsTrue(result);
        }

    }
}
