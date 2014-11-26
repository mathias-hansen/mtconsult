using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class accessroie
{
    public string _header { get; set; }
    public string _modelNumber { get; set; }
    public string _description { get; set; }
    public int _width { get; set; }
    public int _height { get; set; }
    public int _depth { get; set; }
    public int _weight { get; set; }

    DataAccess da = new DataAccess();
    SqlCommand cmd = new SqlCommand();
    
    public accessroie(DataRow row)
    {
        _header = row["header"].ToString();
        _modelNumber = row["modelNumber"].ToString();
        _description = row["description"].ToString();
        _width = Convert.ToInt32(row["width"]);
        _height = Convert.ToInt32(row["height"]);
        _depth = Convert.ToInt32(row["depth"]);
        _weight = Convert.ToInt32(row["weight"]);
    }

    public List<accessroie> getAccessories()
    {
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
    public List<accessroie> getAccessories(List<int> these)
    {
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
}