using System;
using System.Threading;
using MagnetoTesting.Infrastructure;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AjaxWaitTest
{
    public class OverviewPage : PageBase
    {
        public WebDriverWait wait; 
        public OverviewPage(IWebDriver Driver) : base(Driver) 
        {
            wait = new WebDriverWait(Driver, new TimeSpan(20));
        }


        private By demoFrame = By.XPath("//div[@class='dx-datagrid-header-panel']");

        private By hideMenuButton = By.ClassName("menu-state-button");

        private By firstCountry = By.XPath("//tr[4]/td[5]");

        private By firstAjaxWait = By.ClassName("load-panel");

        private By secondAjaxWait = By.ClassName("dx-loadpanel-content-wrapper");


        public void GoToPage()
        {
            Driver.Navigate().GoToUrl("https://js.devexpress.com/Demos/WidgetsGallery/Demo/DataGrid/Overview/jQuery/Light/");
        }

        public void WaitTilAjax1Loaded()
        {
            new WebDriverWait(Driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists(firstAjaxWait));
        }

        public void WaitTilAjax2Loaded()
        {
            new WebDriverWait(Driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists(secondAjaxWait));
        }

        public string GetFirstCountryWaitUntil()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            IWebElement firstCountryElem = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(firstCountry));
            return firstCountryElem.Text;
        }

        public string GetFirstCountry()
        {
            return Text(firstCountry);
        }

        public void HideMenu()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            IWebElement clickToCloseMenu = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(hideMenuButton));
            clickToCloseMenu.Click();
        }

        public void WaitForIframe()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            IWebElement SearchResult = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(demoFrame));
        }

        public void SwitchToIframe()
        {
            Driver.SwitchTo().ParentFrame();
            Driver.SwitchTo().Frame(0);
        }

        public bool AssertLoaderOnePresent()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementIsVisible(firstAjaxWait));
                return true;
            }
            catch (OpenQA.Selenium.NoSuchElementException)
            {
                return false;
            }
        }

        public bool AssertLoaderTwoPresent()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
                wait.Until(ExpectedConditions.ElementIsVisible(secondAjaxWait));
                return true;
            }
            catch (OpenQA.Selenium.NoSuchElementException)
            {
                return false;
            }
        }

        public void WaitForDemoFrame()
        {
            //Thread.Sleep(200);
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(50));
            wait.Until(ExpectedConditions.ElementIsVisible(firstCountry));
        }

        public void WaitForReady()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            wait.Until(driver => (bool)((IJavaScriptExecutor)driver).
                    ExecuteScript("return jQuery.active == 0"));
        }

        public string FluentWait()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(Driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(10);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(200);

            IWebElement firstCountryElem = fluentWait.Until(ExpectedConditions.ElementIsVisible(firstCountry));
            return Text(firstCountry);
        }
    }
}
