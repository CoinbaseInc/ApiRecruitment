using System;

namespace JustEat.RecruitmentTest.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var restaurantMapper = new RestaurantMapper();
            var webRequestManager = new WebRequestManager();
            var restaurantService = new RestaurantService(webRequestManager, restaurantMapper);
            var consoleManager = new ConsoleManager(restaurantService);

            consoleManager.Start();
        }
    }
}
