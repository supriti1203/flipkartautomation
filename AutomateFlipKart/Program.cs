using AutomateFlipKart.Page;
using AutomateFlipKart.SetUp;
using NUnit.Framework;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomateFlipKart
{
    class Program: Base
    {
        static void Main(string[] args)
        {
        }

        [Test]
        public void ExecuteTestForFlipKart()
        {
            //Environment varibales setup
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            string UserName = System.Environment.GetEnvironmentVariable("FLIPKART_USERNAME");
            string Password = System.Environment.GetEnvironmentVariable("FLIPKART_PASSWORD");
            LoginPage loginPage = new LoginPage(driver);    
            loginPage.Login(UserName, Password);

            ProductSearchPage productSearchPage = new ProductSearchPage(driver);           
            productSearchPage.ProductSearch();

            ProductDetails details = new ProductDetails(driver);            
            details.AddProduct();
           
            
        }
    }
}
