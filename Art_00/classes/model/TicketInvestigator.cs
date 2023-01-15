using System;
using System.Collections.Generic;
using System.Text;

namespace Art_00.classes.model
{
    public class TicketInvestigator
    {
        // Instance Variables
        public User investigator { get; }
        public Ticket ticket { get; }
        public Role role { get; }

        // Constructors
        public TicketInvestigator(User investigator, Ticket ticket, Role role)
        {
            this.investigator = investigator;
            this.ticket = ticket;
            this.role = role;
        }
    }
}
