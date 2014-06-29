using System;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace JustEat.RecruitmentTest.App
{
    public class RestaurantMapper : IMapper
    {
        public List<Restaurant> MapToRestaurants(string jsonData)
        {
            if (string.IsNullOrWhiteSpace(jsonData))
            {
                return new List<Restaurant>();
            }

            var data = JObject.Parse(jsonData);
            var restaurantsResult = new List<Restaurant>();
            foreach (var restaurant in data["Restaurants"])
            {
                restaurantsResult.Add(MapToRestaurant(restaurant));
            }
            return restaurantsResult;
        }

        private Restaurant MapToRestaurant(JToken jsonRestaurant)
        {
            return new Restaurant
            {
                Name = Convert.ToString(jsonRestaurant["Name"]),
                CuisineTypes = Convert.ToString(jsonRestaurant["CuisineTypes"].Select(x => x["Name"])),
                RatingStars = Convert.ToDecimal(jsonRestaurant["RatingStars"]),
                NumberOfRantings = Convert.ToInt32(jsonRestaurant["NumberOfRatings"])
            };
        }
    }
}
