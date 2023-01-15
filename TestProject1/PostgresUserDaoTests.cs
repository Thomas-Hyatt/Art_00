using Microsoft.VisualStudio.TestTools.UnitTesting;
using Art_00;
using Art_00.classes.dao;

namespace TestProject1
{
    [TestClass]
    public class PostgresUserDaoTests
    {
        [TestMethod]
        public void SeeIfUserGotPosted()
        {
            PostgresUserDao postgresUserDao = new PostgresUserDao();
        }
    }
}
