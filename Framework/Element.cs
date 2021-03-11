using System.Collections.ObjectModel;
using System.Drawing;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Framework
{
    public class Element : IWebElement
    {
        private readonly IWebElement element_;

        public Element(IWebElement element)
        {
            element_ = element;
        }

        public By FoundBy { get; set; }

        public IWebElement CurrentElement => element_ ?? throw new System.NullReferenceException("element is null.");

        public string TagName => CurrentElement.TagName;

        public string Text => CurrentElement.Text;

        public bool Enabled => CurrentElement.Enabled;

        public bool Selected => CurrentElement.Selected;

        public Point Location => CurrentElement.Location;

        public Size Size => CurrentElement.Size;

        public bool Displayed => CurrentElement.Displayed;

        public void Clear()
        {
            CurrentElement.Clear();
        }

        public void Click()
        {
            CurrentElement.Click();
        }

        public IWebElement FindElement(By by)
        {
            return CurrentElement.FindElement(by);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return CurrentElement.FindElements(by);
        }

        public string GetAttribute(string attributeName)
        {
            return CurrentElement.GetAttribute(attributeName);
        }

        public string GetCssValue(string propertyName)
        {
            return CurrentElement.GetCssValue(propertyName);
        }

        public string GetProperty(string propertyName)
        {
            return CurrentElement.GetProperty(propertyName);
        }

        public void Hover()
        {
            Thread.Sleep(1000);
            var actions = new Actions(Driver.CurrentBrowser);
            actions.MoveToElement(CurrentElement).Perform();
        }

        public void SendKeys(string text)
        {
            CurrentElement.SendKeys(text);
        }

        public void SendKeysWithHumanSpeed(string text)
        {
            for (int i = 0; i < text.Length; i ++)
            {
                CurrentElement.SendKeys(text.Substring(i,1));
                if (i == text.Length - 1) {
                    break;
                }
                Thread.Sleep(100);
            }
        }

        public void Submit()
        {
            CurrentElement.Submit();
        }

        // Used for scroll down in a page for an element that is not in the view.
        public static void ScrollDownToAnElement(Elements listOfElementsForScroll, Element finalValue, int row)
        {
            CommonForAll.Wait.Until(drvr => listOfElementsForScroll[row].Displayed);
            var actions = new Actions(Driver.CurrentBrowser);
            actions.MoveToElement(listOfElementsForScroll[row]).Perform();
            CommonForAll.Wait.Until(drvr => finalValue.Displayed);
        }

        public static string GetTextOfElementsInAList(Elements elementsList, int row)
        {
            CommonForAll.Wait.Until(drvr => elementsList[row].Displayed);
            return elementsList[row].Text;
        }

    }
}
