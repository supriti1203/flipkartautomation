using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomateFlipKart.SetUp
{
    public class Base
    {
        public static IWebDriver driver;
        // Core Automation class
        [TestFixtureSetUp]
        public void StartUpTest()// This method fire at the start of the Test
        {
            Browser.Init();
            driver = Browser.GetWebDriver();
        }
        [TestFixtureTearDown]
        public void EndTest()// This method will fire at the end of the Test
        {
            Browser.Close();
        }
    }
}
