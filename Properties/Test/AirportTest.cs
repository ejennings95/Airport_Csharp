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
            Mock<Weather> weather = new Mock<Weather>();
            weather.Setup(x => x.GetCondition()).Returns("Clear");
            var plane = Mock.Of<Plane>();
            Airport Heathrow = new Airport(weather.Object);
            Heathrow.LandPlane(plane);
            Assert.AreEqual(1, Heathrow.GetHangar().Count);
        }

        [Test, Description("Cannot land plane if it is already landed")]
        [ExpectedException(typeof(PlaneAlreadyLandedException))]
        public void UnableLandLandedPlane()
        {
            Mock<Weather> weather = new Mock<Weather>();
            weather.Setup(x => x.GetCondition()).Returns("Clear");
            Mock<Plane> plane = new Mock<Plane>();
            plane.Setup(x => x.GetStatus()).Returns("Landed");
            Airport Heathrow = new Airport(weather.Object);
            Heathrow.LandPlane(plane.Object);
        }

        [Test, Description("Can take off plane if in airport hangar")]
        public void TakeOffPlane()
        {
            Mock<Weather> weather = new Mock<Weather>();
            weather.Setup(x => x.GetCondition()).Returns("Clear");
            var plane = Mock.Of<Plane>();
            Airport Heathrow = new Airport(weather.Object);
            Heathrow.LandPlane(plane);
            Assert.AreEqual(1, Heathrow.GetHangar().Count);
            Heathrow.TakeOffPlane(plane);
            Assert.AreEqual(0, Heathrow.GetHangar().Count);
        }

        [Test, Description("Cannot take off plane if not in airport hangar")]
        [ExpectedException(typeof(PlaneNotInHangarException))]
        public void UnableToTakeOffPlane()
        {
            Mock<Weather> weather = new Mock<Weather>();
            weather.Setup(x => x.GetCondition()).Returns("Clear");
            var plane = Mock.Of<Plane>();
            Airport Heathrow = new Airport(weather.Object);
            Airport Gatwick = new Airport(weather.Object);
            Heathrow.LandPlane(plane);
            Assert.AreEqual(1, Heathrow.GetHangar().Count);
            Gatwick.TakeOffPlane(plane);
        }

        [Test, Description("Cannot take off plane if it is already in flight")]
        [ExpectedException(typeof(PlaneAlreadyInFlightException))]
        public void UnableTakeOffFlyingPlane()
        {
            Mock<Weather> weather = new Mock<Weather>();
            weather.Setup(x => x.GetCondition()).Returns("Clear");
            Mock<Plane> plane = new Mock<Plane>();
            plane.Setup(x => x.GetStatus()).Returns("Flying");
            Airport Heathrow = new Airport(weather.Object);
            Heathrow.TakeOffPlane(plane.Object);
        }

        [Test, Description("Cannot take off if the weather is stormy")]
        [ExpectedException(typeof(BadWeatherException))]
        public void UnableTakeOffInStormyWeather()
        {
            Mock<Weather> weather = new Mock<Weather>();
            weather.Setup(x => x.GetCondition()).Returns("Stormy");
            Mock<Plane> plane = new Mock<Plane>();
            plane.Setup(x => x.GetStatus()).Returns("Landed");
            Airport Heathrow = new Airport(weather.Object);
            Heathrow.TakeOffPlane(plane.Object);
        }

        [Test, Description("Cannot land plane in full airport")]
        [ExpectedException(typeof(AirportIsFullException))]
        public void UnableToLandInFullAirport()
        {
            Mock<Weather> weather = new Mock<Weather>();
            weather.Setup(x => x.GetCondition()).Returns("Clear");
            Mock<Plane> plane = new Mock<Plane>();
            plane.Setup(x => x.GetStatus()).Returns("Flying");
            Mock<Plane> plane2 = new Mock<Plane>();
            plane2.Setup(x => x.GetStatus()).Returns("Flying");
            Airport Heathrow = new Airport(weather.Object);
            Heathrow.SetCapacity(1);
            Heathrow.LandPlane(plane.Object);
            Heathrow.LandPlane(plane2.Object);
        }

    }
}
