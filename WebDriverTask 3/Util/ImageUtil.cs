using Emgu.CV.Structure;
using Emgu.CV;

namespace WebDriverTask_3.Util
{
    public class ImageUtil
    {
        public static bool Compare(Image<Gray, byte> image1, Image<Gray, byte> image2)
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

            return deffPrecentage == 0;
        }
    }
}
