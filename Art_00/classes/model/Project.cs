using System;
using System.Collections.Generic;
using System.Text;

namespace Art_00.classes.model
{
    public class Project
    {
        // Instance Variables
        public int projectId { get; }
        public string projectDescription { get; }
        public Phase phase { get; }
        public User leader { get; }

        // Constructor
        public Project(int projectId, string projectDescription, Phase phase, User leader)
        {
            this.projectId = projectId;
            this.projectDescription = projectDescription;
            this.phase = phase;
            this.leader = leader;
        }
    }
}
