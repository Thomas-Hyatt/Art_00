using System;
using System.Collections.Generic;
using System.Text;

namespace Art_00.classes.model
{
    public class Position
    {
        // Instance Variables
        public int positionId  { get; }
        public string positionName { get; }

        // Constructor
        public Position(int positionId, string positionName)
        {
            this.positionId = positionId;
            this.positionName = positionName;
        }
    }
}
