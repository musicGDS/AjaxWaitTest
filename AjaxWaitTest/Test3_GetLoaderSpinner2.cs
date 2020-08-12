using System;
using MagnetoTesting.Infrastructure;
using NUnit.Framework;

namespace AjaxWaitTest
{
    public class Test3_GetLoaderSpinner2 : TestBase
    {
        private OverviewPage _overviewPage;
        [SetUp]
        public void Setup()
        {
            _overviewPage = new OverviewPage(Driver);
        }

        [Test]
        public void Test3_LoaderSpinner2()
        {
            _overviewPage.GoToPage();
            _overviewPage.AssertLoaderOnePresent();
            //_overviewPage.SwitchToIframe();
            Assert.That(_overviewPage.AssertLoaderTwoPresent());
        }
    }
}
