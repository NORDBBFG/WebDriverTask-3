using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using WebDriverTask_3.POM.AbstractEntity;
using WebDriverTask_3.POM.GoogleEstimateSummary;

namespace WebDriverTask_3.POM.GooglePricingCalculatorPage
{
    internal class GooglePricingCalculatorPageContext : AbstractPageContext
    {
        private GooglePricingCalculatorPage googlePricingCalculatorPage;

        public GooglePricingCalculatorPageContext(IWebDriver driver)
        {
            this.driver = driver;
            this.googlePricingCalculatorPage = new GooglePricingCalculatorPage(driver);
        }

        public GooglePricingCalculatorPageContext setNumberOfInstances(string numberOfInstances)
        {
            googlePricingCalculatorPage.inputNumberOfInstances.Clear();
            googlePricingCalculatorPage.inputNumberOfInstances.SendKeys(numberOfInstances);
            return this;
        }

        public GooglePricingCalculatorPageContext setOperatingSystem(string operatingSystem)
        {
            string value = googlePricingCalculatorPage.dropDownMenuOperatingSystem.Text;
            if (value.Contains(operatingSystem))
                return this;
            googlePricingCalculatorPage.dropDownMenuOperatingSystem.Click();
            googlePricingCalculatorPage.dropDownMenuSelectElementByValue(operatingSystem).Click();
            return this;
        }

        public GooglePricingCalculatorPageContext setProvisioningModel(string provisioningModel)
        {
            bool isDisplayed = googlePricingCalculatorPage.inputProvisioningModelSelectByValue(provisioningModel).Displayed;
            Assert.IsTrue(isDisplayed);
            googlePricingCalculatorPage.inputProvisioningModelSelectByValue(provisioningModel).Click();
            return this;
        }

        public GooglePricingCalculatorPageContext setMachineFamily(string machineFamily)
        {
            string value = googlePricingCalculatorPage.dropDownMenuMachineFamily.Text;
            if (value == machineFamily)
                return this;
            googlePricingCalculatorPage.dropDownMenuMachineFamily.Click();
            googlePricingCalculatorPage.dropDownMenuSelectElementByValue(machineFamily).Click();
            return this;
        }

        public GooglePricingCalculatorPageContext setSeries(string series)
        {
            string value = googlePricingCalculatorPage.dropDownMenuSeries.Text;
            if (value == series)
                return this;
            googlePricingCalculatorPage.dropDownMenuSeries.Click();
            googlePricingCalculatorPage.dropDownMenuSelectElementByValue(series).Click();
            return this;
        }

        public GooglePricingCalculatorPageContext setMachineType(string machineType)
        {
            string value = googlePricingCalculatorPage.dropDownMenuMachineType.Text;
            if (value == machineType)
                return this;
            googlePricingCalculatorPage.dropDownMenuMachineType.Click();
            googlePricingCalculatorPage.dropDownMenuSelectElementByValue(machineType).Click();
            return this;
        }

        public GooglePricingCalculatorPageContext checkAddGPUs()
        {
            googlePricingCalculatorPage.buttonAddGPUs.Click();
            return this;
        }

        public GooglePricingCalculatorPageContext setGPUModel(string GPUModel)
        {
            string value = googlePricingCalculatorPage.dropDownMenuGPUModel.Text;
            if (value == GPUModel)
                return this;
            googlePricingCalculatorPage.dropDownMenuGPUModel.Click();
            googlePricingCalculatorPage.dropDownMenuSelectElementByValue(GPUModel).Click();
            return this;
        }

        public GooglePricingCalculatorPageContext setNumberGPUs(string numberGPUs)
        {
            string value = googlePricingCalculatorPage.dropDownMenuNumberGPUs.Text;
            if (value == numberGPUs)
                return this;
            googlePricingCalculatorPage.dropDownMenuNumberGPUs.Click();
            googlePricingCalculatorPage.dropDownMenuSelectElementByValue(numberGPUs).Click();
            return this;
        }

        public GooglePricingCalculatorPageContext setLocalSSD(string localSSD)
        {
            string value = googlePricingCalculatorPage.dropDownMenuLocalSSD.Text;
            if (value == localSSD)
                return this;
            googlePricingCalculatorPage.dropDownMenuLocalSSD.Click();
            googlePricingCalculatorPage.dropDownMenuSelectElementByValue(localSSD).Click();
            return this;
        }

        public GooglePricingCalculatorPageContext setRegion(string region)
        {
            string value = googlePricingCalculatorPage.dropDownMenuRegion.Text;
            if (value == region)
                return this;
            googlePricingCalculatorPage.dropDownMenuRegion.Click();
            googlePricingCalculatorPage.dropDownMenuSelectElementByValue(region).Click();
            Thread.Sleep(1000);
            return this;
        }

        public GooglePricingCalculatorPageContext clickButtonShare(out string pageHandle)
        {
            pageHandle = driver.CurrentWindowHandle;
            googlePricingCalculatorPage.buttonShare.Click();
            return this;
        }

        public GoogleEsimateSummeryPageContext clickPopUpMenuButtonOpenEstimateSummery()
        {
            googlePricingCalculatorPage.PopUpMenuButtonOpenEstimateSummery.Click();
            return new GoogleEsimateSummeryPageContext(driver);
        }
    }
}
