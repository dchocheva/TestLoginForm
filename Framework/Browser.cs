using OpenQA.Selenium;

namespace Framework
{
    public static class Browser
    {
        public const string BaseUrl = "https://phptravels.com/demo/";


        public static void OpenWebSite()
        {
            Goto(BaseUrl);
        }

        public static void Goto(string url)
        {
            Driver.CurrentBrowser.Url = url;
        }

    }
}
