using OpenQA.Selenium;
using WebDriverTask_3.POM.AbstractEntity;

namespace WebDriverTask_3.POM.GooglePricingCalculatorPage
{
    internal class GooglePricingCalculatorPage : AbstractPage
    {
        public GooglePricingCalculatorPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        //li[span[text()='n1-standard-8']]
        //li[span/span[text()='n1-standard-8']]
        public IWebElement inputNumberOfInstances => driver.FindElement(By.XPath("//input[@id='c13']"));
        public IWebElement dropDownMenuOperatingSystem => driver.FindElement(By.XPath("//div[@class='O1htCb-H9tDt PPUDSe t8xIwc']"));
        public IWebElement dropDownMenuSelectElementByValue(string value) => driver.FindElement(By.XPath($"//li[span/span[text()='{value}']]"));
        public IWebElement inputProvisioningModelSelectByValue(string value) => driver.FindElement(By.XPath($"//input[@name='107']/following-sibling::label[text()='{value}']"));
        public IWebElement dropDownMenuMachineFamily => driver.FindElement(By.XPath("//span[@id='c27']"));
        public IWebElement dropDownMenuSeries => driver.FindElement(By.XPath("//span[@id='c31']"));
        public IWebElement dropDownMenuMachineType => driver.FindElement(By.XPath("//div[@jsname='kgDJk']"));
        public IWebElement buttonAddGPUs => driver.FindElement(By.XPath("//button[@aria-label = 'Add GPUs']"));
        public IWebElement dropDownMenuGPUModel => driver.FindElement(By.XPath("//div[span/span/span[text()='GPU Model']]"));
        public IWebElement dropDownMenuNumberGPUs => driver.FindElement(By.XPath("//div[span/span/span[text()='Number of GPUs']]"));
        public IWebElement dropDownMenuLocalSSD => driver.FindElement(By.XPath("//div[span/span/span[text()='Local SSD']]"));
        public IWebElement dropDownMenuRegion => driver.FindElement(By.XPath("//div[span/span/span[text()='Region']]"));
        public IWebElement buttonShare => driver.FindElement(By.XPath("//button[span[text()='Share']]"));
        public IWebElement PopUpMenuButtonOpenEstimateSummery => driver.FindElement(By.XPath("//a[@class='tltOzc MExMre rP2xkc jl2ntd']"));
    }
}