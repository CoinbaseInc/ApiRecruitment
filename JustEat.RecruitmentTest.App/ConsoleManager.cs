using System;
using System.Linq;
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
            Console.Write("Enter the code or write 'QUIT': ");
            return Console.ReadLine();
        }

        public void PrintRestaurants(List<Restaurant> restaurants)
        {
            var lines = 0;
            restaurants.ForEach(restaurant => {
                PrintSimpleRestaurant(restaurant);
                lines = lines + 4;
                PrintNextScreen(lines);
            });
            Console.WriteLine("                Total of restaurants: " + restaurants.Count + "\n");
        }

        private void PrintNextScreen(int numberOflines) 
        {
            if (numberOflines >= 10)
            {
                numberOflines = 0;
                Console.Write("Press any key to continue ...");
                Console.ReadLine();
            }
        }
        private void PrintSimpleRestaurant(Restaurant restaurant)
        {
            Console.WriteLine("\n Name: " + restaurant.Name);
            Console.WriteLine("\n CuisineTypes: " + restaurant.CuisineTypes);
            Console.WriteLine(string.Format("\n Rating stars: {0} from {1} ratings", restaurant.RatingStars, restaurant.NumberOfRantings));
            Console.WriteLine("\n------------------------------------");
        }

        private bool IsFinished(string value)
        {
            return value.ToLower() == "quit" || value.ToUpper() == "Quit";
        }
    }
}
