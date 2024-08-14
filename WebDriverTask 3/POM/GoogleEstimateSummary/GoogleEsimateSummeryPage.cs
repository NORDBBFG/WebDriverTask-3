using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverTask_3.POM.AbstractEntity;

namespace WebDriverTask_3.POM.GoogleEstimateSummary
{
    internal class GoogleEsimateSummeryPage : AbstractPage
    {
        public GoogleEsimateSummeryPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement spanNumberOfInstances => driver.FindElement(By.ClassName("hXFIvf"));
        public IWebElement spanOperatingSystem => driver.FindElement(By.XPath($"//span[text()='Operating System / Software']/following-sibling::span[1]"));
        public IWebElement spanProvisioningModel => driver.FindElement(By.XPath($"//span[text()='Provisioning Model']/following-sibling::span[1]"));
        public IWebElement spanMachineType => driver.FindElement(By.XPath($"//span[text()='Machine type']/following-sibling::span[1]"));
        public IWebElement spanGPUModel => driver.FindElement(By.XPath($"//span[text()='GPU Model']/following-sibling::span[1]"));
        public IWebElement spanNumberOfGPUs => driver.FindElement(By.XPath($"//span[text()='Number of GPUs']/following-sibling::span[1]"));
        public IWebElement spanLocalSSD => driver.FindElement(By.XPath($"//span[text()='Local SSD']/following-sibling::span[1]"));
        public IWebElement spanRegion => driver.FindElement(By.XPath($"//span[text()='Region']/following-sibling::span[1]"));


    }
}
