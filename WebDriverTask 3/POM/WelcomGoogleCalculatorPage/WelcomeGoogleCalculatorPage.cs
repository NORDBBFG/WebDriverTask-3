using OpenQA.Selenium;
using WebDriverTask_3.POM.AbstractEntity;

namespace WebDriverTask_3.POM.WelcomGoogleCalculatorPage
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
