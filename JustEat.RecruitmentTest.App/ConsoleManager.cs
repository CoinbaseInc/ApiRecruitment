using System;
using System.Collections.Generic;

namespace JustEat.RecruitmentTest.App
{
    public class ConsoleManager : IInputManager, IOutPutManager
    {
        private IRestaurantService _restaurantService;

        public void Start()
        {
            string codeReaded = string.Empty;
            while (!IsFinished(codeReaded))
            {
                codeReaded = ReadCode();
                var restaurants = _restaurantService.GetRestaurantsByCode(codeReaded);
                PrintRestaurants(restaurants);
            }

        }

        public ConsoleManager(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        public string ReadCode()
        {
            Console.Write("Enter the code or write 'QUIT'");
            return Console.ReadLine();
        }

        public void PrintRestaurants(List<Restaurant> restaurants)
        {

        }

        private bool IsFinished(string value)
        {
            return value.ToLower() == "quit" || value.ToUpper() == "Quit";
        }
    }
}
