using System;
using System.Collections.Generic;
using System.Text;

namespace Art_00.classes.model
{
    public class ProjectDeveloper
    {
        // Instance Variables
        public Project project { get; }
        public User developer { get; }
        public Role role { get; }

        // Constructor
        public ProjectDeveloper(Project project, User developer, Role role)
        {
            this.project = project;
            this.developer = developer;
            this.role = role;
        }
    }
}
