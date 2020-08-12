using System;
using MagnetoTesting.Infrastructure;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AjaxWaitTest
{
    public class Tests : TestBase
    {
        private OverviewPage _overviewPage;
        [SetUp]
        public void Setup()
        {
            _overviewPage = new OverviewPage(Driver);
            
        }

        [Test]
        public void Test1()
        {
            string expectedCountry = "Australia";
            _overviewPage.GoToPage();
            //_overviewPage.WaitTilAjax1Loaded();
            
            _overviewPage.SwitchToIframe();

            //_overviewPage.WaitTilAjax2Loaded();
            //_overviewPage.HideMenu();


            //_overviewPage.WaitForIframe();

            Assert.That(expectedCountry == _overviewPage.GetFirstCountry());
        }
    }
}