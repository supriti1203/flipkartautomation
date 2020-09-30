using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomateFlipKart.Utility
{
    public class Utilities
    {
        
        public static void ExpliciteWait(IWebDriver driver, Elements type, string value)
        {

            switch (type)
            {
                case Elements.Css:
                     new WebDriverWait(driver, TimeSpan.FromSeconds(30))
                        .Until(ExpectedConditions.ElementIsVisible(By.CssSelector(value)));
                    break;               
                case Elements.Xpath:
                    new WebDriverWait(driver, TimeSpan.FromSeconds(50))
                       .Until(ExpectedConditions.ElementIsVisible(By.XPath(value)));
                    break;


            }
                        
        }
    }
}
