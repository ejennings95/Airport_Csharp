using System;
namespace Airport.Csharp
{
    public class AirportIsFullException : Exception
    {
        public AirportIsFullException(string message) : base(message)
        {
        }
    }
}
