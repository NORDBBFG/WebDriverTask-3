using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Runtime.Intrinsics.X86;
using WebDriverTask_3.POM;
using WebDriverTask_3.POM.GoogleEstimateSummary;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebDriverTask_3
{
    public class Tests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [Test]
        public void Test1()
        {
            //Arrange
            string calculatorType;
            string numberOfInstances;
            string operatingSystem;
            string provisioningModel;
            string machineFamily;
            string series;
            string machineType;
            string GPUType;
            string numberOfGPUs;
            string localSSD;
            string region;
            string pageHandle;

            //Act
            calculatorType = "Compute Engine";
            numberOfInstances = "4";
            operatingSystem = "Free: Debian, CentOS, CoreOS, Ubuntu or BYOL (Bring Your Own License)";
            provisioningModel = "Regular";
            machineFamily = "General Purpose";
            series = "N1";
            machineType = "n1-standard-8";
            GPUType = "NVIDIA V100";
            numberOfGPUs = "1";
            localSSD = "2x375 GB";
            region = "Netherlands (europe-west4)";

            //Assert
            driver.Navigate().GoToUrl("https://cloud.google.com/products/calculator/?hl=en");
            var welcomeGoogleCalculatorPageContext = new WelcomeGoogleCalculatorPageContext(driver);
            Thread.Sleep(3000);
            welcomeGoogleCalculatorPageContext.clickButtonAddToEstimate()
                .SelectPopUpMenuElementByValue(calculatorType)
                .setNumberOfInstances(numberOfInstances)
                .setOperatingSystem(operatingSystem)
                .setProvisioningModel(provisioningModel)
                .setMachineFamily(machineFamily)
                .setSeries(series)
                .setMachineType(machineType)
                .checkAddGPUs()
                .setGPUModel(GPUType)
                .setNumberGPUs(numberOfGPUs)
                .setLocalSSD(localSSD)
                .setRegion(region)
                .clickButtonShare(out pageHandle)
                .clickPopUpMenuButtonOpenEstimateSummery()
                .verifySummeryPageScreenshot(numberOfInstances, pageHandle);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}