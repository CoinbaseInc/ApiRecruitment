using System.Collections.Generic;
using System.Net;

namespace JustEat.RecruitmentTest.App
{
    public interface IMapper
    {
        List<Restaurant> MapToRestaurants(string jsonData);
    }
}
