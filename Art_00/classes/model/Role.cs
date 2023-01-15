using System;
using System.Collections.Generic;
using System.Text;

namespace Art_00.classes.model
{
    public class Role
    {
        // Instance Variables
        public int roleId { get; }
        public string roleName { get; }

        // Constructor
        public Role(int roleId, string roleName)
        {
            this.roleId = roleId;
            this.roleName = roleName;
        }
    }
}
