using System;
using System.Collections.Generic;

namespace Airport.Csharp
{
    public class Airport
    {
        List<Plane> hangar = new List<Plane>();

        public Airport()
        {
        }

        public List<Plane> GetHangar()
        {
            return hangar;
        }

        public void LandPlane (Plane plane)
        {
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
