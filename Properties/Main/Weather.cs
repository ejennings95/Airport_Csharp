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

        private void SetCondition()
        {
           condition = randomNumber == 0 ? "Clear" : "Stormy";
        }
    }
}
