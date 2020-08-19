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

        private readonly IConfiguration _config;

        public AccountController(IConfiguration config)
        {
            _config = config;
        }


        public WebDriverWait wait; 
        public OverviewPage(IWebDriver Driver) : base(Driver) 
        {
            wait = new WebDriverWait(Driver, new TimeSpan(20));
        }

        private By hideMenuButton = By.ClassName("menu-state-button");

        private By firstCountry = By.XPath("//tr[4]/td[5]");

        private By firstAjaxWait = By.ClassName("load-panel");

        private By secondAjaxWait = By.ClassName("dx-loadpanel-content-wrapper");

        private By dataTable = By.ClassName("dx-datagrid-table");


        public void GoToPage()
        {
            string url = System.Configuration.ConfigurationManager.AppSettings["URL"]; ;
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

        public void WaitForData()
        {
            //Thread.Sleep(200);
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(50));
            wait.Until(ExpectedConditions.ElementIsVisible(dataTable));
        }

        public void FluentWait()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(Driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(20);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(200);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Until(ExpectedConditions.ElementExists(firstCountry));
        }
    }
}
