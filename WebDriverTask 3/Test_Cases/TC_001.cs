using Microsoft.Extensions.Configuration;
using WebDriverTask_3.Entities;
using WebDriverTask_3.Entities.AbstractEntities;
using WebDriverTask_3.POM.WelcomGoogleCalculatorPage;
using WebDriverTask_3.Util;

namespace WebDriverTask_3
{
    public class Tests : BaseTest
    {
        [Test]
        public void Test1()
        {
            //Arrange
            EntityComputeEngine computeEngine;
            string pageHandle;

            //Act
            _config = new ConfigurationBuilder()
            .SetBasePath(StringUtil.testsPath)
            .AddJsonFile("TC_001.json")
            .Build();

            computeEngine = _config.GetSection("TestData").Get<EntityComputeEngine>();

            //Assert
            driver.Navigate().GoToUrl("https://cloud.google.com/products/calculator/?hl=en");
            var welcomeGoogleCalculatorPageContext = new WelcomeGoogleCalculatorPageContext(driver);
            Thread.Sleep(3000);
            welcomeGoogleCalculatorPageContext.clickButtonAddToEstimate()
                .SelectPopUpMenuElementByValue(computeEngine.CalculatorType)
                .setNumberOfInstances(computeEngine.NumberOfInstances)
                .setOperatingSystem(computeEngine.OperatingSystem)
                .setProvisioningModel(computeEngine.ProvisioningModel)
                .setMachineFamily(computeEngine.MachineFamily)
                .setSeries(computeEngine.Series)
                .setMachineType(computeEngine.MachineType)
                .checkAddGPUs()
                .setGPUModel(computeEngine.GPUType)
                .setNumberGPUs(computeEngine.NumberOfGPUs)
                .setLocalSSD(computeEngine.LocalSSD)
                .setRegion(computeEngine.Region)
                .clickButtonShare(out pageHandle)
                .clickPopUpMenuButtonOpenEstimateSummery()
                .verifySummeryPageScreenshot(pageHandle);
        }
    }
}