using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

public class slider
{
    public string[] _images { get; set; }

    public void getImages()
    {
        _images = Directory.GetFiles(HttpContext.Current.Server.MapPath("/slider/images"));
        for (int i = 0; i < _images.Length; i++)
        {
            _images[i] = Regex.Match(_images[i], @"[\w\d\-_]+\.[\w\d\-_]+$").ToString();
        }
    }
}