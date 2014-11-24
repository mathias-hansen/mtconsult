using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class image
{
    public string _filename { get; set; }
    public string _description { get; set; }
}

public class slider
{
    public List<image> _images { get; set; }

    public void getImages()
    {
        DataAccess da = new DataAccess();
        DataTable dt = new DataTable();
        SqlCommand cmd = new SqlCommand();
        _images = new List<image>();

        cmd.CommandText = "SELECT * FROM mtconsult_slider";
        dt = da.GetData(cmd);

        foreach (DataRow row in dt.Rows)
        {
            image img = new image();
            img._filename = row["filename"].ToString();
            img._description = row["description"].ToString();
            _images.Add(img);
        }
    }
}