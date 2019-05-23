using NUnit.Framework;
using System;
namespace Airport.Csharp.Test
{
    public class WeatherTest
    {
        [Test, Description("Weather has default condition of Clear")]
        public void DefaultCondition()
        {
            Weather weather = new Weather();
            Assert.AreEqual("Clear", weather.condition);
        }

        [Test, Description("Weather condition is Clear is random returns 0")]
        public void ClearCondition()
        {
            var weather = new Weather(0);
            weather.GetCondition();
            Assert.AreEqual("Clear", weather.condition);
        }

        [Test, Description("Weather condition is Stormy is random returns 1")]
        public void StormyCondition()
        {
            var weather = new Weather(1);
            weather.GetCondition();
            Assert.AreEqual("Stormy", weather.condition);
        }
    }
}
