using System;
using System.Collections.Generic;
using System.Text;

namespace Art_00.classes.model
{
    public class User
    {
        // Instance Variables
        public int userId { get; private set; }
        public string position { get; private set; }
        public string username { get; private set; }


        // Constructors
        public User()
        {
            this.userId = 0;
            this.position = null;
            this.username = null;
        }

        public User(int userId, string position, string username)
        {
            this.userId = userId;
            this.position = position;
            this.username = username;
        }
    }
}
