using System;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace MagnetoTesting.Infrastructure
{
    public class PageBase
    {
        public IWebDriver Driver;

        public PageBase(IWebDriver driver)
        {
            Driver = driver;
        }

        public IWebElement Element(By by)
        {
            return Driver.FindElement(by);
        }

        public void Click(By by)
        {
            Element(by).Click();
        }

        public void SendKeys(By by, string keys)
        {
            Element(by).SendKeys(keys);
        }

        public string Text(By by)
        {
            return Element(by).Text;
        }

        public void OpenNewTab()
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("window.open();");
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
        }



        public IWebElement WaitForElement(By by)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            IWebElement result = wait.Until(ExpectedConditions.ElementExists(by));
            return result;
        }
    }
}
