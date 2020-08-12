using System;
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


        private By demoFrame = By.Id("demoFrame");

        private By hideMenuButton = By.ClassName("menu-state-button");

        private By firstCountry = By.XPath("//iframe//tr[4]//td[5]");

        private By firstAjaxWait = By.ClassName("load-panel");

        private By secondAjaxWait = By.ClassName("dx-overlay dx-widget dx-visibility-change-handler dx-loadpanel dx-state-invisible");

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

        public string GetFirstCountry()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(1));
            // Kazkodel negaliu panaudoti firstCountry By kintamojo?
            IWebElement firstCountry = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//tr[4]//td[5]")));
            return firstCountry.Text;
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
    }
}
