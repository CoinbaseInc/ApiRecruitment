using System.Collections.Generic;

namespace JustEat.RecruitmentTest.App
{
    public interface IRestaurantService
    {
        List<Restaurant> GetRestaurantsByCode(string code);
    }
}
