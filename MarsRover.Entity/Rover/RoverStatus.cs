using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Entity
{
    public class RoverStatus
    {
        public Position Position = new Position();
        public bool IsError { get; set; }

        public string Message { get; set; }
    }
}
