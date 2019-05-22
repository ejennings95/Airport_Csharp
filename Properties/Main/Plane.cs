using System;
namespace Airport.Csharp
{
    public class Plane
    {
        string status = "Flying";

        public Plane()
        {
        }

        public virtual string GetStatus()
        {
            return status;
        }

        public void LandedStatus()
        {
            status = "Landed";
        }

        public void FlyingStatus()
        {
            status = "Flying";
        }
    }
}
