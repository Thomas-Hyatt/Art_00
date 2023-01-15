using System;
using System.Collections.Generic;
using System.Text;

namespace Art_00.classes.model
{
    public class Ticket
    {
        // Instance Variables
        public int ticketId { get; }
        public User submitter { get; }
        public Project mainProject { get; }
        public string ticketDescription { get; }
        public int priority { get;  }
        public DateTime submissionTime { get; }
       

        // Constructor
        public Ticket(int ticketId, User submitter, Project mainProject, string ticketDescription, int priority, DateTime submissionTime)
        {
            this.ticketId = ticketId;
            this.submitter = submitter;
            this.mainProject = mainProject;
            this.ticketDescription = ticketDescription;
            this.priority = priority;
            this.submissionTime = submissionTime;
        }
    }
}
