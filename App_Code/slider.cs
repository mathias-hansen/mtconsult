using System.IO;
using System.Text.RegularExpressions;
using System.Web;

public class slider
{
    public string[] _images { get; set; }

    public slider()
    {
        _images = Directory.GetFiles(HttpContext.Current.Server.MapPath("/slider/images"));
        for (int i = 0; i < _images.Length; i++)
        {
            _images[i] = Regex.Match(_images[i], @"[\w\d\-_]+\.[\w\d\-_]+$").ToString();
        }
    }
}