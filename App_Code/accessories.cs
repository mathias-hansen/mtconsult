using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

public class accessroie
{
    public string _header { get; set; }
    public string _modelNumber { get; set; }
    public string _description { get; set; }
    public int _width { get; set; }
    public int _height { get; set; }
    public int _depth { get; set; }
    public int _weight { get; set; }
    public string _image { get; set; }
    
    public accessroie(DataRow row)
    {
        _header = row["header"].ToString();
        _modelNumber = row["modelNumber"].ToString();
        _description = row["description"].ToString();
        _width = Convert.ToInt32(row["width"]);
        _height = Convert.ToInt32(row["height"]);
        _depth = Convert.ToInt32(row["depth"]);
        _weight = Convert.ToInt32(row["weight"]);
        _image = row["image"].ToString();
    }

    public static List<accessroie> getAccessories()
    {
        DataAccess da = new DataAccess();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        List<accessroie> accessories = new List<accessroie>();

        cmd.CommandText = "SELECT * FROM mtconsult_accessories";
        dt = da.GetData(cmd);

        foreach (DataRow row in dt.Rows)
        {
            accessories.Add(new accessroie(row));
        }

        return accessories;
    }
    public static List<accessroie> getAccessories(List<int> these)
    {
        DataAccess da = new DataAccess();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        List<accessroie> accessories = new List<accessroie>();

        cmd.CommandText = "";
        foreach (int id in these)
        {
            cmd.CommandText += "SELECT * FROM mtconsult_accessories WHERE id = " + id + ";";
        }

        dt = da.GetData(cmd);

        foreach (DataRow row in dt.Rows)
        {
            accessories.Add(new accessroie(row));
        }

        return accessories;
    }

    public static List<product> getCompatibleProducts(int accessorie)
    { 
        List<product> self = new List<product>();
        return self;
    }

    public static string displayAccessories(List<accessroie> accessories)
    {
        string str = string.Empty;

        foreach (accessroie acc in accessories)
        {
            str += "<div class='accessorie'>";
            str += "<div class='flex'>";
            str += "<div class='header'>";
            str += "<h3>" + acc._header + "</h3>";
            str += "<p>" + acc._modelNumber + "</p>";
            str += "</div>";
            str += "<p>" + acc._description + "</p>";
            str += "<div class='info'>";
            str += "<p><b>Mål:</b> " + acc._width + "mm x " + acc._height + "mm x " + acc._depth + "mm</p>";
            str += "<p><b>Mål:</b> " + acc._weight + "g</p>";
            str += "</div>";
            str += "<div class='compatible'>";
            // getCompatibleProducts
            str += "</div></div>";
            str += "<div class='image'><img src='" + acc._image + "'/><a href='/how-to-buy.aspx'>How To Buy</a></div>";
            str += "</div>";
        }

        return str;
    }
}