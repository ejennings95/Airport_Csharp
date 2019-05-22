using System;
namespace Airport.Csharp
{
    public class Weather
    {
        public string condition = "Clear"; 

        public Weather()
        {
        }

        public string GetCondition()
        {
            SetCondition();
            return condition;
        }

        public void SetCondition()
        {
            if (Random() == 0)
            {
                condition = "Clear";
            }
            else
            {
                condition = "Stormy";
            }
        }

        public virtual int Random()
        {
            var rnd = new Random().Next(0, 2);
            return rnd;
        }
    }
}
