using System;
namespace Airport.Csharp
{
    public class Weather
    {
        public string condition = "Clear";
        public int randomNumber = new Random().Next(0, 2);

        public Weather()
        {
        }

        public Weather(int number)
        {
            randomNumber = number;
        }

        public virtual string GetCondition()
        {
            SetCondition();
            return condition;
        }

        public void SetCondition()
        {
            if (randomNumber == 0)
            {
                condition = "Clear";
            } else
            {
                condition = "Stormy";
            }
        }
    }
}
