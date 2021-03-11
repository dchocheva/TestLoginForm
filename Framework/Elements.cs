using System.Collections.Generic;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Framework
{
    public class Elements : ReadOnlyCollection<IWebElement>
    {
        private readonly IList<IWebElement> elements_;

        public Elements(IList<IWebElement> list)
            : base(list)
        {
            elements_ = list;
        }

        public IList<IWebElement> CurrentElements => elements_ ?? throw new System.NullReferenceException("list of elements is null.");

        public By FoundBy { get; set; }

        public bool IsEmpty => Count == 0;

        public void Hover(IWebElement element)
        {
            var actions = new OpenQA.Selenium.Interactions.Actions(Driver.CurrentBrowser);
            actions.MoveToElement(element).Perform();
        }
    }
}
