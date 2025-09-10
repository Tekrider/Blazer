namespace Blazor_ImageOverlay.Components.Service
{
    using System.Drawing;
    using System.Drawing.Imaging;

    public class ImageService
    {
        public byte[] MergeImages(string basePath, string overlayPath)
        {
            using var baseImage = new Bitmap(basePath);
            using var overlayImage = new Bitmap(overlayPath);
            using var graphics = Graphics.FromImage(baseImage);

            graphics.DrawImage(overlayImage, new Point(0, 0));

            using var ms = new MemoryStream();
            baseImage.Save(ms, ImageFormat.Png);
            return ms.ToArray();
        }

    }
    public class ImageMergeService
    {
        public byte[] MergeImages(string baseImagePath, string overlayImagePath, Point overlayPosition,bool overlay=true)
        {
            using var baseImage = Image.FromFile(baseImagePath);
            using var overlayImage = Image.FromFile(overlayImagePath);
            using var graphics = Graphics.FromImage(baseImage);
            if (overlay==false)
            {
                graphics.DrawImage(overlayImage, overlayPosition);
            }
            

            using var ms = new MemoryStream();
            baseImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }
    }
}
