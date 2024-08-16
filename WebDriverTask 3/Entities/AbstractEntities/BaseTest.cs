using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WebDriverTask_3.Util;

namespace WebDriverTask_3.Entities.AbstractEntities
{
    public abstract class BaseTest
    {
        protected IWebDriver driver;
        private IConfiguration _browserConfig;
        protected IConfiguration _config;

        [SetUp]
        public void Setup()
        {
            var configPath = Path.Combine(Directory.GetCurrentDirectory(), "browserconfig.json");
            _browserConfig = new ConfigurationBuilder()
                .AddJsonFile(configPath)
                .Build();

            string browser = _browserConfig["Browser"];

            switch (browser.ToLower())
            {
                case "chrome":
                    var chromeOptions = new ChromeOptions();
                    driver = new ChromeDriver(chromeOptions);
                    break;
                case "firefox":
                    var firefoxOptions = new FirefoxOptions();
                    driver = new FirefoxDriver(firefoxOptions);
                    break;
                case "edge":
                    var edgeOptions = new EdgeOptions();
                    driver = new EdgeDriver(edgeOptions);
                    break;
                default:
                    throw new ArgumentException($"Unsupported browser: {browser}");
            }

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [TearDown]
        public void TearDown()
        {
            var testStatus = TestContext.CurrentContext.Result.Outcome.Status;
            if (testStatus == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                CaptureScreenshot();
            }
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
                driver = null;
            }
        }

        private void CaptureScreenshot()
        {
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            var screenshotFileName = $"{TestContext.CurrentContext.Test.Name}_{DateTime.Now:yyyyMMdd_HHmmss}.png";
            var screenshotFilePath = Path.Combine(StringUtil.failedScreenshotPath, screenshotFileName);

            // Ensure the Screenshots directory exists 
            Directory.CreateDirectory(Path.GetDirectoryName(screenshotFilePath));

            screenshot.SaveAsFile(screenshotFilePath);
            TestContext.AddTestAttachment(screenshotFilePath); // Attach screenshot to the test result
        }
    }
}
