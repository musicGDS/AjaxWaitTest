using System;
using MagnetoTesting.Infrastructure;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AjaxWaitTest
{
    public class Test1_WaitUntil : TestBase
    {
        private OverviewPage _overviewPage;
        [SetUp]
        public void Setup()
        {
            _overviewPage = new OverviewPage(Driver); 
        }

        [Test]
        public void Test()
        {
            string expectedCountry = "Australia";
            _overviewPage.GoToPage();
            //_overviewPage.WaitTilAjax1Loaded();

            _overviewPage.SwitchToIframe();

            Assert.That(expectedCountry == _overviewPage.GetFirstCountryWaitUntil());
        }
    }
}