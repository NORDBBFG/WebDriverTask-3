using Emgu.CV;
using Emgu.CV.Structure;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using WebDriverTask_3.POM.AbstractEntity;
using WebDriverTask_3.Util;

namespace WebDriverTask_3.POM.GoogleEstimateSummary
{
    internal class GoogleEsimateSummeryPageContext : AbstractPageContext
    {
        GoogleEsimateSummeryPage googleEsimateSummeryPage;
        Actions actions;

        public GoogleEsimateSummeryPageContext(IWebDriver driver)
        {
            this.driver = driver;
            actions = new Actions(driver);
            googleEsimateSummeryPage = new GoogleEsimateSummeryPage(driver);
        }

        //Actual screenshot path is allways *ProjectName\bin\Debug\.netVersion\ActualScreenshot.png
        public GoogleEsimateSummeryPageContext verifySummeryPageScreenshot(string firstTabHandle, string expectedScreenshotPath = null)
        {
            Thread.Sleep(1000);
            var currentPageHandle = driver.WindowHandles;
            string secondTabHandle = currentPageHandle.First(handle => handle != firstTabHandle);
            Image<Gray, Byte> img1;
            Image<Gray, Byte> img2;
            driver.SwitchTo().Window(secondTabHandle);

            actions.ScrollByAmount(0, 100).Perform();
            var titleScreenshot = (driver as ITakesScreenshot).GetScreenshot();
            string projectRoot = AppDomain.CurrentDomain.BaseDirectory;
            string actualScreenshotPath = Path.Combine(projectRoot, "ActualScreenshot.png");
            titleScreenshot.SaveAsFile(actualScreenshotPath);
            if (expectedScreenshotPath == null)
            {
                expectedScreenshotPath = Path.Combine(projectRoot, "ExpectedScreenshot.png");
            }

            img1 = new Image<Gray, Byte>(expectedScreenshotPath);
            img2 = new Image<Gray, Byte>(actualScreenshotPath);

            bool result = ImageUtil.Compare(img1, img2);
            File.Delete(actualScreenshotPath);
            Assert.True(result);
            return this;
        }
    }
}
