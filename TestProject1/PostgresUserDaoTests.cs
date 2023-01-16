using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Art_00;
using Art_00.classes.dao;
using Art_00.classes.model;
using Nito.AsyncEx.Synchronous;

namespace TestProject1
{
    [TestClass]
    public class PostgresUserDaoTests
    {
        [TestMethod]
        public void SeeIfUserGotPosted()
        {
            PostgresUserDao postgresUserDao = new PostgresUserDao();

            User user = new User(5, "memearchitect", "iamadankbouy");

            var task = postgresUserDao.PostUser(user);
            var newUser = task.WaitAndUnwrapException();

            Console.WriteLine(newUser.userId);

            Assert.AreEqual(5, newUser.userId, 0.001, "hahahahaha");
        }
    }
}
