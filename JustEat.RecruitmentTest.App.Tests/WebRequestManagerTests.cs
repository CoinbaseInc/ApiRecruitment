using System;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JustEat.RecruitmentTest.App.Tests
{
    [TestClass]
    public class WebRequestManagerTests
    {
        [TestMethod]
        public void WebRequestManager_return_json_when_is_the_rigth_code()
        {
            var webRequestManager = new WebRequestManager();

            var data = webRequestManager.GetJsonData("SE19");
            
            Assert.IsInstanceOfType(data, typeof(string));
        }

        [TestMethod]
        public void WebRequestManager_return_json_when_is_the_code_empty()
        {
            var webRequestManager = new WebRequestManager();

            var data = webRequestManager.GetJsonData(string.Empty);

            Assert.IsInstanceOfType(data, typeof(string));
        }
    }
}
