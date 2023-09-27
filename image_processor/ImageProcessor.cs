using System;
using System.IO;
using System.Drawing;
using System.Linq;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

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

    /// <summary>
    /// public static void Thumbnail
    /// </summary>
    /// <param name="filenames"></param>
    /// <param name="height"></param>
    public static void Thumbnail(string[] filenames, int height)
    {
        foreach (string filename in filenames)
        {
            try
            {
                using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.ReadWrite))
                {
                    long fileSize = fs.Length;
                    byte[] imageData = new byte[fileSize];

                    fs.Read(imageData, 0, (int)fileSize);

                    // Calculate the width for the thumbnail based on the aspect ratio
                    int width = CalculateThumbnailWidth(filename, height);

                    // Create a new byte array for the thumbnail image
                    byte[] thumbnailData = CreateThumbnail(imageData, width, height);

                    // Save the thumbnail image with the "_th" suffix
                    string outputFilename = $"{GetFileNameWithoutExtension(filename)}_th{GetFileExtension(filename)}";
                    File.WriteAllBytes(outputFilename, thumbnailData);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing {filename}: {ex.Message}");
            }
        }
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

    private static int CalculateThumbnailWidth(string filename, int targetHeight)
    {
        try
        {
            using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                // Read the image header to determine its dimensions
                byte[] header = new byte[24];
                fs.Read(header, 0, 24);

                int width = header[12] + (header[13] << 8) + (header[14] << 16) + (header[15] << 24);
                int height = header[16] + (header[17] << 8) + (header[18] << 16) + (header[19] << 24);

                double aspectRatio = (double)width / height;

                // Calculate the width for the thumbnail based on the aspect ratio
                return (int)(targetHeight * aspectRatio);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while calculating thumbnail width for {filename}: {ex.Message}");
            return -1; // Return a default value or handle the error accordingly
        }
    }

    private static byte[] CreateThumbnail(byte[] imageData, int width, int height)
    {
        // Placeholder logic: This code doesn't perform actual image resizing.

        // Calculate the stride (number of bytes per row)
        int stride = (width * 3 + 3) & ~3; // Assuming 24-bit RGB format

        // Create a new byte array for the thumbnail image
        byte[] thumbnailData = new byte[stride * height];

        // Placeholder: Copy the original image data to the thumbnail (no resizing)
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                int originalIndex = (y * width + x) * 3;
                int thumbnailIndex = (y * stride + x * 3);

                if (originalIndex + 2 < imageData.Length && thumbnailIndex + 2 < thumbnailData.Length)
                {
                    thumbnailData[thumbnailIndex] = imageData[originalIndex]; // R
                    thumbnailData[thumbnailIndex + 1] = imageData[originalIndex + 1]; // G
                    thumbnailData[thumbnailIndex + 2] = imageData[originalIndex + 2]; // B
                }
            }
        }

        return thumbnailData;
    }
    private static string GetFileNameWithoutExtension(string filename)
    {
        return Path.GetFileNameWithoutExtension(filename);
    }

    private static string GetFileExtension(string filename)
    {
        return Path.GetExtension(filename);
    }
}
