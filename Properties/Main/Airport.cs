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
    }
}
