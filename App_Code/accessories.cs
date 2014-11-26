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

    public List<accessroie> getAccessories()
    {
        DataTable dt = new DataTable();
        List<accessroie> accessories = new List<accessroie>();

        cmd.CommandText = "SELECT * FROM mtconsult_accessories";
        dt = da.GetData(cmd);

        foreach (DataRow accessorie in dt.Rows)
        {
            accessories.Add(fillAccessorie(accessorie));
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

        foreach (DataRow accessorie in dt.Rows)
        {
            accessories.Add(fillAccessorie(accessorie));
        }

        return accessories;
    }


    public accessroie fillAccessorie(DataRow accessorie)
    {
        accessroie access = new accessroie();
        access._header = accessorie["header"].ToString();
        access._modelNumber = accessorie["modelNumber"].ToString();
        access._description = accessorie["description"].ToString();
        access._width = Convert.ToInt32(accessorie["width"]);
        access._height = Convert.ToInt32(accessorie["height"]);
        access._depth = Convert.ToInt32(accessorie["depth"]);
        access._weight = Convert.ToInt32(accessorie["weight"]);
        return access;
    }
}