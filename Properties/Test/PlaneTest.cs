using NUnit.Framework;
using System;
namespace Airport.Csharp.Test
{
    public class PlaneTest
    {
        [Test, Description("Plane is initialised with a Flying status")]
        public void Status()
        {
            Plane plane = new Plane();
            Assert.AreEqual("Flying", plane.GetStatus());
        }

        [Test, Description("Plane can be  set to Landed status")]
        public void LandedStatus()
        {
            Plane plane = new Plane();
            plane.LandedStatus();
            Assert.AreEqual("Landed", plane.GetStatus());
        }

        [Test, Description("Plane can be set to Flying status")]
        public void FlyingStatus()
        {
            Plane plane = new Plane();
            plane.LandedStatus();
            Assert.AreEqual("Landed", plane.GetStatus());
            plane.FlyingStatus();
            Assert.AreEqual("Flying", plane.GetStatus());
        }
    }
}
