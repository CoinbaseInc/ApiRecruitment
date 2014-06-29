using Moq;
using System;
using System.Net;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace JustEat.RecruitmentTest.App.Tests
{
    [TestClass]
    public class RestaurantServiceTests
    {
        [TestMethod]
        public void RestaurantService_GetRestaurants()
        {
            var webrequestManager = new Mock<IWebRequestManager>();
            var mapper = new Mock<IMapper>();
            mapper.Setup(x => x.MapToRestaurants(It.IsAny<string>())).Returns(new List<Restaurant>());
            var restaurantService = new RestaurantService(webrequestManager.Object, mapper.Object);
            var restaurantsResult = restaurantService.GetRestaurantsByCode("se15");

            Assert.IsInstanceOfType(restaurantsResult, typeof(List<Restaurant>));
            mapper.Verify(x => x.MapToRestaurants(It.IsAny<string>()));
        }
    }
}
