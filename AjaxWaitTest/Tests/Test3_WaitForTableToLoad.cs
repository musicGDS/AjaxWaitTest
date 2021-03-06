﻿using System;
using MagnetoTesting.Infrastructure;
using NUnit.Framework;

namespace AjaxWaitTest
{
    public class Test5_WaitForTableToLoad : TestBase
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
            _overviewPage.SwitchToIframe();

            //Turbut sita turejai omenyje, kai sakei, kad newrappinti elemento, o atskirai palaukti
            //Bandziau lentele naudoti
            _overviewPage.WaitForData();

            Assert.That(expectedCountry == _overviewPage.GetFirstCountry());
        }
    }
}
