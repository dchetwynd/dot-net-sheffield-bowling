using System;

namespace BowlingKata
{
    public class InvalidRollException :Exception
    {
        public InvalidRollException(string message) : base(message)
        {
            
        }
    }
}