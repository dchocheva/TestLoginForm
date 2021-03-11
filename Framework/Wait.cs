using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Framework
{
    public class Wait
    {
        private readonly WebDriverWait wait_;

        public Wait()
        {
            wait_ = new WebDriverWait(Driver.CurrentBrowser, TimeSpan.FromSeconds(2));
        }

        public bool Until(Func<IWebDriver, bool> condition)
        {
            return wait_.Until(condition);
        }
    }
}
