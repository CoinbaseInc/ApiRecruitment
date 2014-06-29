using System.Net;

namespace JustEat.RecruitmentTest.App
{
    public interface IWebRequestManager
    {
        string GetJsonData(string code);
    }
}
