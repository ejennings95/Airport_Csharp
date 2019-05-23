using System;
using System.Collections.Generic;

namespace Airport.Csharp
{
    public class Airport
    {
        List<Plane> hangar = new List<Plane>();
        Weather weatherCondition = new Weather();
        public int CapacityOfAirport = 20;

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

        public void SetCapacity(int capacity)
        {
            CapacityOfAirport = capacity;
        }

        public int GetCapacity()
        {
            return CapacityOfAirport;
        }

        public void LandPlane (Plane plane)
        {
            if (IsAirportFull()) throw new AirportIsFullException("This airport is full");
            if (IsStormy()) throw new BadWeatherException("Weather too bad to land");
            if (IsLanded(plane)) throw new PlaneAlreadyLandedException("Plane already landed");
            hangar.Add(plane);
            plane.LandedStatus();
        }

        public void TakeOffPlane(Plane plane)
        {
            if (IsStormy()) throw new BadWeatherException("Weather too bad to take off");
            if (IsFlying(plane)) throw new PlaneAlreadyInFlightException("Plane is already in flight");
            if (!IsPlaneInHanagar(plane)) throw new PlaneNotInHangarException("This plane is not in this airport's hangar");
            hangar.Remove(plane);
            plane.FlyingStatus();
        }

        private bool IsStormy()
        {
            return weatherCondition.GetCondition() == "Stormy" ? true : false;
        }

        private bool IsFlying(Plane plane)
        {
            return plane.GetStatus() == "Flying" ? true : false;
        }

        private bool IsLanded(Plane plane)
        {
            return plane.GetStatus() == "Landed" ? true : false;
        }

        private bool IsAirportFull()
        {
            return GetHangar().Count >= GetCapacity() ? true : false;
        }

        private bool IsPlaneInHanagar(Plane plane)
        {
            return GetHangar().Contains(plane) ? true : false;
        }
    }
}
