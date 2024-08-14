using OpenQA.Selenium;
using WebDriverTask_3.POM.AbstractEntity;
using System.Drawing.Imaging;
using System.IO;
using Emgu.CV.Structure;
using Emgu.CV;
using OpenQA.Selenium.Interactions;
using System;

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

        public GoogleEsimateSummeryPageContext verifySummeryPageScreenshot(string expectedNumberOfInstances, string firstTabHandle, string expectedScreenshotPath = null)
        {
            Thread.Sleep(4000);
            var currentPageHandle = driver.WindowHandles;
            string secondTabHandle = currentPageHandle.First(handle => handle != firstTabHandle);
            driver.SwitchTo().Window(secondTabHandle);

            actions.ScrollByAmount(0, 100).Perform();
            var titleScreenshot = (driver as ITakesScreenshot).GetScreenshot();
            string projectRoot = AppDomain.CurrentDomain.BaseDirectory;
            string actualScreenshotPath = Path.Combine(projectRoot, "ActualScreenshot.png");
            titleScreenshot.SaveAsFile(actualScreenshotPath);
            if(expectedScreenshotPath == null)
            {
                expectedScreenshotPath = Path.Combine(projectRoot, "ExpectedScreenshot.png");
            }

            Image<Gray, Byte> img1 = new Image<Gray, Byte>(expectedScreenshotPath);
            Image<Gray, Byte> img2 = new Image<Gray, Byte>(actualScreenshotPath);

            bool result = Compare(img1, img2);
            File.Delete(actualScreenshotPath);
            Assert.True(result);
            return this;
        }

        private bool Compare(Image<Gray, byte> image1, Image<Gray, byte> image2)
        {
            if (image1.Width != image2.Width || image1.Height != image2.Height)
            {
                return false;
            }

            using var diffImage = new Image<Gray, byte>(image1.Width, image1.Height);
            // Get the image of different pixels.
            CvInvoke.AbsDiff(image1, image2, diffImage);

            using var threadholdImage = new Image<Gray, byte>(image1.Width, image1.Height);
            // Check the pixies difference.
            // For instance, if difference between the same pixel on both image are less then 20,
            // we can say that this pixel is the same on both images.
            // After threadholding we would have matrix on which we would have 0 for pixels which are "nearly" the same and 1 for pixes which are different.
            CvInvoke.Threshold(diffImage, threadholdImage, 20, 1, Emgu.CV.CvEnum.ThresholdType.Binary);
            int diff = CvInvoke.CountNonZero(threadholdImage);

            // Take the percentage of the pixels which are different.
            var deffPrecentage = diff / (double)(image1.Width * image1.Height);

            // If the amount of different pixels more then 15% then we can say that those images are different.
            return deffPrecentage < 0.15;
        }
    }
}
