using System.Collections.Generic;

namespace JustEat.RecruitmentTest.App
{
    public class RestaurantService : IRestaurantService
    {
        private IWebRequestManager _webrequestManager;
        private IMapper _mapper;

        public RestaurantService(IWebRequestManager webrequestManager, IMapper  mapper)
        {
            _webrequestManager = webrequestManager;
            _mapper = mapper;
        }

        public List<Restaurant> GetRestaurantsByCode(string code) 
        {
            var jsonDataresult = _webrequestManager.GetJsonData(code);
            return _mapper.MapToRestaurants(jsonDataresult);
        }
    }
}
