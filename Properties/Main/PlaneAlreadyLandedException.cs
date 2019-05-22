using System;
namespace Airport.Csharp
{
    public class PlaneAlreadyLandedException : Exception
    {
        public PlaneAlreadyLandedException(string message) : base(message)
        {
        }
    }
}
