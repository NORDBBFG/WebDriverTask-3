using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverTask_3.POM.AbstractEntity;

namespace WebDriverTask_3.POM
{
    internal class WelcomeGoogleCalculatorPage : AbstractPage
    {
        public WelcomeGoogleCalculatorPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement ButtonAddToEstimate => driver.FindElement(By.XPath("//span[@class='UywwFc-vQzf8d']"));
        public IWebElement PopUpMenuElementByValue(string value) => driver.FindElement(By.XPath($"//div[contains(@class, 'd5NbRd-EScbFb-JIbuQc PtwYlf')][h2[text()='{value}']]"));
    
    }
}
