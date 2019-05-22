﻿using Moq;
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

        [Test, Description("Cannot land plane if it is already landed")]
        [ExpectedException(typeof(PlaneAlreadyLandedException))]
        public void UnableLandLandedPlane()
        {
            Mock<Plane> plane = new Mock<Plane>();
            plane.Setup(x => x.GetStatus()).Returns("Landed");
            Airport Heathrow = new Airport();
            Heathrow.LandPlane(plane.Object);
        }

        [Test, Description("Can take off plane if in airport hangar")]
        public void TakeOffPlane()
        {
            var plane = Mock.Of<Plane>();
            Airport Heathrow = new Airport();
            Heathrow.LandPlane(plane);
            Assert.AreEqual(1, Heathrow.GetHangar().Count);
            Heathrow.TakeOffPlane(plane);
            Assert.AreEqual(0, Heathrow.GetHangar().Count);
        }

        [Test, Description("Cannot take off plane if not in airport hangar")]
        [ExpectedException(typeof(PlaneNotInHangarException))]
        public void UnableToTakeOffPlane()
        {
            var plane = Mock.Of<Plane>();
            Airport Heathrow = new Airport();
            Airport Gatwick = new Airport();
            Heathrow.LandPlane(plane);
            Assert.AreEqual(1, Heathrow.GetHangar().Count);
            Gatwick.TakeOffPlane(plane);
        }

        [Test, Description("Cannot take off plane if it is already in flight")]
        [ExpectedException(typeof(PlaneAlreadyInFlightException))]
        public void UnableTakeOffFlyingPlane()
        {
            Mock<Plane> plane = new Mock<Plane>();
            plane.Setup(x => x.GetStatus()).Returns("Flying");
            Airport Heathrow = new Airport();
            Heathrow.TakeOffPlane(plane.Object);
        }
    }
}
