using System;
using System.IO;

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


    private static string GetFileNameWithoutExtension(string filename)
    {
        return Path.GetFileNameWithoutExtension(filename);
    }

    private static string GetFileExtension(string filename)
    {
        return Path.GetExtension(filename);
    }
}
