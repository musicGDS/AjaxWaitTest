using System;
using MagnetoTesting.Infrastructure;
using NUnit.Framework;

namespace AjaxWaitTest
{
    public class Test2_GetLoaderCircle1 : TestBase
    {
        private OverviewPage _overviewPage;

        [SetUp]
        public void Setup()
        {
            _overviewPage = new OverviewPage(Driver);
        }

        [Test]
        public void Test2_LoaderCircle1()
        {
            _overviewPage.GoToPage();
            Assert.That(_overviewPage.AssertLoaderOnePresent());
        }
       
    }
}
