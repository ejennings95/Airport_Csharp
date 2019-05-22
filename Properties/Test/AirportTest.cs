using Moq;
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

        [Test, Description("Can land plane in airport")]
        public void LandPlane()
        {
            var plane = Mock.Of<Plane>();
            Airport Heathrow = new Airport();
            Heathrow.LandPlane(plane);
            Assert.AreEqual(1, Heathrow.GetHangar().Count);
        }
    }
}
