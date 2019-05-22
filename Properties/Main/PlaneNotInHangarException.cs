using System;
namespace Airport.Csharp
{
    public class PlaneNotInHangarException : Exception
    {
        public PlaneNotInHangarException(string message) : base(message)
        {
        }
    }
}
