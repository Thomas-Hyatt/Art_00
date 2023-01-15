using System;
using System.Collections.Generic;
using System.Text;

namespace Art_00.classes.model
{
    public class Phase
    {
        // Instance Variables
        public int phaseId { get; }
        public string phaseName { get; }

        // Constructor
        public Phase(int phaseId, string phaseName)
        {
            this.phaseId = phaseId;
            this.phaseName = phaseName;
        }
    }
}
