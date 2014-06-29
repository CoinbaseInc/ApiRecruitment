using System;
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
                restaurantsResult.Add(MapSimpleRestaurant(restaurant));
            }
            return restaurantsResult;
        }

        private Restaurant MapSimpleRestaurant(JToken jsonRestaurant)
        {
            return new Restaurant
            {
                Name = Convert.ToString(jsonRestaurant["Name"]),
                CuisineTypes = Convert.ToString(jsonRestaurant["CuisineTypes"].First["Name"]),
                RatingStars = Convert.ToDecimal(jsonRestaurant["RatingStars"]),
                NumberOfRantings = Convert.ToInt32(jsonRestaurant["NumberOfRatings"])
            };
        }
    }
}
