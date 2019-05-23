using System;
using System.Collections.Generic;

namespace Airport.Csharp
{
    public class Airport
    {
        List<Plane> hangar = new List<Plane>();
        Weather weatherCondition = new Weather();

        public Airport()
        {
        }

        public Airport(Weather weather)
        {
            weatherCondition = weather;
        }

        public List<Plane> GetHangar()
        {
            return hangar;
        }

        public void LandPlane (Plane plane)
        {
            if(weatherCondition.GetCondition() == "Stormy")
            {
                throw new BadWeatherException("Weather too bad to land");
            }
            if (plane.GetStatus() == "Landed")
            {
                throw new PlaneAlreadyLandedException("Plane already laneded");
            } else
            {
                hangar.Add(plane);
            }
        }

        public void TakeOffPlane(Plane plane)
        {
            if (weatherCondition.GetCondition() == "Stormy")
            {
                throw new BadWeatherException("Weather too bad to take off");
            }
            if (plane.GetStatus() == "Flying")
            {
                throw new PlaneAlreadyInFlightException("Plane is already in flight");
            }
            if (!GetHangar().Contains(plane)) 
            {
                throw new PlaneNotInHangarException("This plane is not in this airport's hangar");
            } else
            {
                hangar.Remove(plane);
            }
        }
    }
}
