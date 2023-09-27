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

    private static string GetFileNameWithoutExtension(string filename)
    {
        return Path.GetFileNameWithoutExtension(filename);
    }

    private static string GetFileExtension(string filename)
    {
        return Path.GetExtension(filename);
    }
}
