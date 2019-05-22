using NUnit.Framework;
using System;
namespace Airport.Csharp.Test
{
    public class AirportTest
    {
        [Test, Description("Hangar is initalised with no planes")]
        public void Hangar()
        {
            Airport Heathrow = new Airport();
            Assert.AreEqual(0, Heathrow.GetHangar().Count);
        }
    }
}
