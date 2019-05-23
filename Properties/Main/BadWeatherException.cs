using System;
namespace Airport.Csharp
{
    public class BadWeatherException : Exception
    {
        public BadWeatherException(string message) : base(message)
        {
        }
    }
}
