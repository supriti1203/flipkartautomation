using AutomateFlipKart.SetUp;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using static AutomateFlipKart.SetUp.Browser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomateFlipKart.Page
{
    public class LoginPage
    {
        private IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "._1dBPDZ")]
        public IWebElement UserName { get; set; }

        [FindsBy(How = How.CssSelector, Using = "._3v41xv")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.CssSelector, Using = "._1LctnI")]
        public IWebElement Submit { get; set; }

        [FindsBy(How = How.ClassName,Using = "_3Ep39l")]
        public IWebElement LoginButton { get; set; }
        public void Login(string userName, string password)
        {            
            if (browser.Equals("IE"))
            {
                LoginButton.Click();
            }
            UserName.SendKeys(userName);
            Password.SendKeys(password);
            Submit.Click();           
        }
    }
}
