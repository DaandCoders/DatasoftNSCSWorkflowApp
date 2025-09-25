using System.Drawing;
using System.IO;

public  class ImageInfo
{
    public int DpiX { get; set; }
    public int DpiY { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public string Dimensions => $"{Width}x{Height}";
    public long SizeInBytes { get; set; }
    public string SizeString => $"{SizeInBytes / 1024.0:F2} KB";

    public static ImageInfo GetImageInfo(string filePath)
    {
        using (var img = Image.FromFile(filePath))
        {
            var fileInfo = new FileInfo(filePath);
            return new ImageInfo
            {
                DpiX = (int)img.HorizontalResolution,
                DpiY = (int)img.VerticalResolution,
                Width = img.Width,
                Height = img.Height,
                SizeInBytes = fileInfo.Length
            };
        }
    }

}

