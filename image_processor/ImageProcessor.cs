using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using System.Threading.Tasks.Parallel;

class ImageProcessor
{
    /// <summary>
    /// public static
    /// </summary>
    /// <param name="filenames"></param>
    public static void Inverse(string[] filenames)
    {
        Parallel.ForEach(filenames, (filename) =>
        {
            try
            {
                // Load the original image
                using (var image = new Bitmap(filename))
                {
                    // Create a new image with the same dimensions
                    using (var newImage = new Bitmap(image.Width, image.Height))
                    {
                        for (int x = 0; x < image.Width; x++)
                        {
                            for (int y = 0; y < image.Height; y++)
                            {
                                // Get the original pixel color
                                Color originalColor = image.GetPixel(x, y);

                                // Invert the color
                                Color invertedColor = Color.FromArgb(
                                    255 - originalColor.R,
                                    255 - originalColor.G,
                                    255 - originalColor.B
                                );

                                // Set the inverted color in the new image
                                newImage.SetPixel(x, y, invertedColor);
                            }
                        }

                        // Determine the output filename
                        string outputFilename = Path.GetFileNameWithoutExtension(filename)
                                                + "_inverse" + Path.GetExtension(filename);

                        // Save the new image with the same format as the original
                        newImage.Save(outputFilename, image.RawFormat);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing {filename}: {ex.Message}");
            }
        });
    }
}
