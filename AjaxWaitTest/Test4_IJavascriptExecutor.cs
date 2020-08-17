using System;
using MagnetoTesting.Infrastructure;
using NUnit.Framework;

namespace AjaxWaitTest
{
    public class Test4_IJavascriptExecutor : TestBase
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
            //_overviewPage.WaitForJQuery();
            //_overviewPage.CheckPageIsLoaded();

            //_overviewPage.CheckPageIsLoaded();

            //_overviewPage.SwitchToIframe();

            //_overviewPage.WaitForReady();

            _overviewPage.WaitForReady();
            //_overviewPage.WaitForAustralia();

            Assert.That(expectedCountry == _overviewPage.GetFirstCountry());
        }
    }
}
