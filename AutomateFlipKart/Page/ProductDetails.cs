using AutomateFlipKart.SetUp;
using AutomateFlipKart.Utility;
using NUnit.Framework;
using OpenQA.Selenium;
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
    public class ProductDetails
    {
        private IWebDriver driver;
       
        public ProductDetails(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver,this);
        }
       
        [FindsBy(How = How.CssSelector, Using = "._2MWPVK")]
        public IWebElement AddToCart { get; set; }

        [FindsBy(How = How.CssSelector, Using = "._7UHT_c")]
        public IWebElement PlaceOrder { get; set; }

        public void AddProduct()
        {
            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(90);
                var newWindowHandle = driver.WindowHandles[1];
                driver.SwitchTo().Window(newWindowHandle);

                IWebElement ProductDescription = driver.FindElement(By.ClassName("_35KyD6"));
                IWebElement ProductPrice = driver.FindElement(By.CssSelector("._3qQ9m1"));
                Dictionary<string, string> product = new Dictionary<string, string>();
                product.Add("product_name", ProductDescription.Text);
                product.Add("product_price", ProductPrice.Text);

                ExpliciteWait(driver, Elements.Css, "._2MWPVK");
                AddToCart.Click();
                ExpliciteWait(driver, Elements.Css, "._7UHT_c");
                PlaceOrder.Click();

                ExpliciteWait(driver, Elements.Css, "._325-ji");
                IWebElement addedProductdescription = driver.FindElement(By.ClassName("_325-ji"));
                IWebElement addedProductprice = driver.FindElement(By.ClassName("XU9vZa"));
                Dictionary<string, string> addedProduct = new Dictionary<string, string>();
                addedProduct.Add("product_name", addedProductdescription.Text);
                addedProduct.Add("product_price", addedProductprice.Text);

                //Assertion
                Assert.IsTrue(product["product_name"].Contains(addedProduct["product_name"]), "Description does not match");
                Assert.AreEqual(addedProduct["product_price"], product["product_price"], "Price is Not as Expected");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
