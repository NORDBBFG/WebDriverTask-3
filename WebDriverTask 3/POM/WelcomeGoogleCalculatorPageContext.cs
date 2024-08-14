using OpenQA.Selenium;
using WebDriverTask_3.POM.AbstractEntity;
using WebDriverTask_3.POM.GooglePricingCalculatorPage;

namespace WebDriverTask_3.POM
{
    internal class WelcomeGoogleCalculatorPageContext : AbstractPageContext
    {
        private WelcomeGoogleCalculatorPage welcomeGoogleCalculatorPage;

        public WelcomeGoogleCalculatorPageContext(IWebDriver driver)
        {
            this.driver = driver;
            this.welcomeGoogleCalculatorPage = new WelcomeGoogleCalculatorPage(driver);
        }

        public WelcomeGoogleCalculatorPageContext clickButtonAddToEstimate()
        {
            Thread.Sleep(2000);
            welcomeGoogleCalculatorPage.ButtonAddToEstimate.Click();
            return this;
        }

        public GooglePricingCalculatorPageContext SelectPopUpMenuElementByValue(string value)
        {
            Thread.Sleep(3000);
            welcomeGoogleCalculatorPage.PopUpMenuElementByValue(value).Click();
            return new GooglePricingCalculatorPageContext(driver);
        }
    }
}
