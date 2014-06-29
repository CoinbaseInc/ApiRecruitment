using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JustEat.RecruitmentTest.App.Tests
{
    [TestClass]
    public class MapperTests
    {
        private IMapper _mapper;

        [TestInitialize]
        public void setUp()
        {
            _mapper = new RestaurantMapper();
        }

        [TestMethod]
        public void Mapper_return_list_of_restaurant_from_string_json()
        {
            var jsonRestaurant = "{'ShortResultText': 'SE18',"
                                + "'Restaurants': ["
                                + "{"
                                    + "'Id': 12237,"
                                    + "'Name': 'Name',"
                                    + "'CuisineTypes': ["
                                    + "    {"
                                    + "        'Name': 'CuisineTypes',"
                                    + "    }"
                                    + "],"
                                    + "'RatingStars': 5.34,"
                                    + "'NumberOfRatings': 120"
                                    + "}]}";
            var restaurantExpected = new List<Restaurant>{new Restaurant { Name = "Name", CuisineTypes = "CuisineTypes", RatingStars = (decimal)5.34, NumberOfRantings = 120 }};

            var restaurantResult = _mapper.MapToRestaurants(jsonRestaurant);

            Assert.AreEqual(restaurantExpected[0].Name, restaurantResult[0].Name);
            Assert.AreEqual(restaurantExpected[0].RatingStars, restaurantResult[0].RatingStars);
            Assert.AreEqual(restaurantExpected[0].NumberOfRantings, restaurantResult[0].NumberOfRantings);
        }

        [TestMethod]
        public void Mapper_return_empty_list_when_there_is_no_restaurants_in_the_json()
        {
            var restaurantResult = _mapper.MapToRestaurants("{\"ShortResultText\":\"\",\"Restaurants\":[]}");

            Assert.IsNotNull(restaurantResult);
            Assert.IsInstanceOfType(restaurantResult, typeof(List<Restaurant>));
            Assert.AreEqual(0, restaurantResult.Count);
        }

        [TestMethod]
        public void Mapper_return_empty_list_when_json_is_empty()
        {
            var restaurantResult = _mapper.MapToRestaurants(string.Empty);
            
            Assert.IsNotNull(restaurantResult);
            Assert.IsInstanceOfType(restaurantResult, typeof(List<Restaurant>));
            Assert.AreEqual(0, restaurantResult.Count);
        }
    }
}
