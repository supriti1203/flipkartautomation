using AutomateFlipKart.SetUp;
using AutomateFlipKart.Utility;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AutomateFlipKart.Utility.Utilities;

namespace AutomateFlipKart.Page
{
    public class ProductSearchPage
    {
        private IWebDriver driver;
        public ProductSearchPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }       

        [FindsBy(How = How.CssSelector,Using = ".LM6RPg")]
        public IWebElement SearchBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(text(), 'Canon EOS 1500D DSLR Camera')]")]
        public IWebElement ProductClick { get; set; }

        public void ProductSearch()
        {
            try
            {
                System.Threading.Thread.Sleep(3000);
                SearchBox.SendKeys("Camera" + Keys.Enter);

                //Scrolling page   
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("window.scrollBy(0,3000)");
                ExpliciteWait(driver, Elements.Xpath, "//*[contains(text(), 'Canon EOS 1500D DSLR Camera')]");
                ProductClick.Click();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }                

        }
    }
}
