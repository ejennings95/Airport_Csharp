using System;
namespace Airport.Csharp
{
    public class PlaneAlreadyInFlightException : Exception
    {
        public PlaneAlreadyInFlightException(string message) : base(message)
        {
        }
    }
}
