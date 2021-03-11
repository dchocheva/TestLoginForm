using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Framework
{
    public static class Driver
    {
        [ThreadStatic]
        private static IWebDriver chromeDriver;

        public static IWebDriver CurrentBrowser => chromeDriver ?? throw new NullReferenceException("Driver is null");

        public static void ChromeDriverInit()
        {

            ChromeOptions options = new ChromeOptions();
            //options.AddArguments("--headless");
            //options.AddArguments("--window-size=1600,900");
            options.AddArguments("--no-sandbox");
            options.AddArguments("--disable-gpu");
            options.AddArguments("--disable-dev-shm-usage");
            options.AddUserProfilePreference("credentials_enable_service", false);
            options.AddUserProfilePreference("profile.password_manager_enabled", false);
            options.AddExcludedArgument("enable-automation");
            options.AddAdditionalCapability("useAutomationExtension", false);

            chromeDriver = new ChromeDriver(options);

            chromeDriver.Manage().Window.Maximize();
        }

        public static Element FindElement(By by)
        {
            try
            {
                CurrentBrowser.FindElement(by);
            }
            catch (NoSuchElementException)
            {
                CommonForAll.Wait.Until(drvr => CurrentBrowser.FindElement(by).Displayed);
            };
            return new Element(CurrentBrowser.FindElement(by))
            {
                FoundBy = by,
            };
        }

        public static Elements FindElements(By by)
        {
            return new Elements(CurrentBrowser.FindElements(by))
            {
                FoundBy = by,
            };
        }

        public static void CloseBrowser()
        {
            CurrentBrowser.Quit();
        }
    }
}
