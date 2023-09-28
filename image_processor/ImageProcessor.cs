using System;
using System.IO;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// public class ImageProcessor
/// </summary>
public class ImageProcessor
{
    /// <summary>
    /// public static void Inverse
    /// </summary>
    /// <param name="filenames"></param>
    public static void Inverse(string[] filenames)
    {
        foreach (string filename in filenames)
        {
            try
            {
                // Read the original image as a byte array
                byte[] imageData = File.ReadAllBytes(filename);

                // Invert the colors of the image
                byte[] invertedData = InvertColors(imageData);

                // Save the inverted image with the "_inverse" suffix
                string outputFilename = $"{GetFileNameWithoutExtension(filename)}_inverse{GetFileExtension(filename)}";
                File.WriteAllBytes(outputFilename, invertedData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing {filename}: {ex.Message}");
            }
        }
    }

    /// <summary>
    ///  public static void Grayscale
    /// </summary>
    /// <param name="filenames"></param>
    public static void Grayscale(string[] filenames)
    {
        foreach (string filename in filenames)
        {
            try
            {
                // Read the original image as a byte array
                byte[] imageData = File.ReadAllBytes(filename);

                // Convert the image to grayscale
                byte[] grayscaleData = ConvertToGrayscale(imageData);

                // Save the grayscale image with the "_grayscale" suffix
                string outputFilename = $"{GetFileNameWithoutExtension(filename)}_grayscale{GetFileExtension(filename)}";
                File.WriteAllBytes(outputFilename, grayscaleData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing {filename}: {ex.Message}");
            }
        }
    }

    /// <summary>
    /// public static void BlackWhite
    /// </summary>
    /// <param name="filenames"></param>
    /// <param name="threshold"></param>
    public static void BlackWhite(string[] filenames, double threshold)
    {
        foreach (string filename in filenames)
        {
            try
            {
                // Read the original image as a byte array
                byte[] imageData = File.ReadAllBytes(filename);

                // Convert the image to black and white based on the threshold
                byte[] blackWhiteData = ConvertToBlackWhite(imageData, threshold);

                // Save the black and white image with the "_bw" suffix
                string outputFilename = $"{GetFileNameWithoutExtension(filename)}_bw{GetFileExtension(filename)}";
                File.WriteAllBytes(outputFilename, blackWhiteData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing {filename}: {ex.Message}");
            }
        }
    }
    /*     public static void Thumbnail(string[] filenames, int height)
        {
            Thread th = null;
            if (filenames.Length > 1)
            {
                string[] tmp = new string[filenames.Length - 1];
                Array.Copy(filenames, 1, tmp, 0, tmp.Length);
                th = new Thread(() => Thumbnail(tmp, height));
                th.Start();
            }
            if (filenames.Length > 0)
            {
                string name = filenames[0];
                Bitmap bmp = new Bitmap(name);
                Image image = bmp.GetThumbnailImage((int)(bmp.Width * (double)((double)height / (double)bmp.Height)), height, () => { return false; }, IntPtr.Zero);
                int lastSlash = name.LastIndexOf('/') + 1;
                int lastDot = name.LastIndexOf('.');
                image.Save(name.Substring(lastSlash, lastDot - lastSlash) + "_th" + name.Substring(lastDot));
            }
            if (filenames.Length > 1)
            {
                th.Join();
            }
        }  */
    /*     public static void Thumbnail(string[] filenames, int height)
        {
            Parallel.ForEach(filenames, name =>
            {
                Bitmap bmp = new Bitmap(name);
                Image image = bmp.GetThumbnailImage((int)(bmp.Width * (double)((double)height / (double)bmp.Height)), height, () => false, IntPtr.Zero);

                string newFilename = Path.GetFileNameWithoutExtension(name) + "_th" + Path.GetExtension(name);
                string fullPath = Path.Combine(Path.GetDirectoryName(name), newFilename);

                image.Save(fullPath);
            });
        } */
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filenames"></param>
        /// <param name="maxHeight"></param>
    public static void Thumbnail(string[] filenames, int maxHeight)
    {
        Parallel.ForEach(filenames, name =>
        {
            using (Image originalImage = Image.FromFile(name))
            {
                int newWidth, newHeight;

                // Calculate new dimensions while maintaining aspect ratio
                if (originalImage.Height > maxHeight)
                {
                    double aspectRatio = (double)originalImage.Width / originalImage.Height;
                    newHeight = maxHeight;
                    newWidth = (int)(newHeight * aspectRatio);
                }
                else
                {
                    newWidth = originalImage.Width;
                    newHeight = originalImage.Height;
                }

                using (Bitmap thumbnail = new Bitmap(originalImage, newWidth, newHeight))
                {
                    string newFilename = Path.Combine(Path.GetDirectoryName(name),
                        $"{Path.GetFileNameWithoutExtension(name)}_th{Path.GetExtension(name)}");

                    thumbnail.Save(newFilename, originalImage.RawFormat);
                }
            }
        });
    }

    private static byte[] InvertColors(byte[] imageData)
    {
        byte[] invertedData = new byte[imageData.Length];

        for (int i = 0; i < imageData.Length; i++)
        {
            // Invert each byte (color channel)
            invertedData[i] = (byte)(255 - imageData[i]);
        }

        return invertedData;
    }

    private static byte[] ConvertToGrayscale(byte[] imageData)
    {
        int bytesPerPixel = 3; // Assuming RGB format
        int stride = imageData.Length / bytesPerPixel;
        byte[] grayscaleData = new byte[imageData.Length];

        for (int i = 0; i < imageData.Length; i += bytesPerPixel)
        {
            // Check if there are enough bytes for one pixel
            if (i + bytesPerPixel <= imageData.Length)
            {
                // Calculate grayscale value for each pixel using the luminance formula
                byte pixelValue = (byte)(0.299 * imageData[i] + 0.587 * imageData[i + 1] + 0.114 * imageData[i + 2]);

                // Set the same grayscale value for all three color channels
                grayscaleData[i] = grayscaleData[i + 1] = grayscaleData[i + 2] = pixelValue;
            }
        }

        return grayscaleData;
    }

    private static byte[] ConvertToBlackWhite(byte[] imageData, double threshold)
    {
        byte[] bwData = new byte[imageData.Length];

        for (int i = 0; i < imageData.Length; i += 3)
        {
            // Ensure there are enough bytes for one pixel (RGB format)
            if (i + 2 < imageData.Length)
            {
                // Calculate grayscale value for each pixel using the luminance formula
                double luminance = 0.299 * imageData[i] + 0.587 * imageData[i + 1] + 0.114 * imageData[i + 2];

                // Determine whether the pixel should be black or white based on the threshold
                byte pixelValue = (luminance >= threshold) ? (byte)255 : (byte)0;

                // Set the same black or white value for all three color channels
                bwData[i] = bwData[i + 1] = bwData[i + 2] = pixelValue;
            }
        }

        return bwData;
    }
    /* 
        private static int CalculateThumbnailWidth(string filename, int targetHeight)
        {
            try
            {
                using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
                {
                    byte[] header = new byte[24];
                    fs.Read(header, 0, 24);
                    int width = header[12] + (header[13] << 8) + (header[14] << 16) + (header[15] << 24);
                    int height = header[16] + (header[17] << 8) + (header[18] << 16) + (header[19] << 24);
                    double aspectRatio = (double)width / height;
                    return (int)(targetHeight * aspectRatio);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while calculating thumbnail width for {filename}: {ex.Message}");
                return -1;
            }
        }

        private static byte[] CreateThumbnail(byte[] imageData, int width, int height)
        {
            int stride = (width * 3 + 3) & ~3;
            byte[] thumbnailData = new byte[stride * height];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int originalIndex = (y * width + x) * 3;
                    int thumbnailIndex = (y * stride + x * 3);
                    if (originalIndex + 2 < imageData.Length && thumbnailIndex + 2 < thumbnailData.Length)
                    {
                        thumbnailData[thumbnailIndex] = imageData[originalIndex];
                        thumbnailData[thumbnailIndex + 1] = imageData[originalIndex + 1];
                        thumbnailData[thumbnailIndex + 2] = imageData[originalIndex + 2];
                    }
                }
            }
            return thumbnailData;
        } */
    private static string GetFileNameWithoutExtension(string filename)
    {
        return Path.GetFileNameWithoutExtension(filename);
    }

    private static string GetFileExtension(string filename)
    {
        return Path.GetExtension(filename);
    }
}
