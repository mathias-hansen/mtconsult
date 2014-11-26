using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class product
{
    public string _header { get; set; }
    public string _description { get; set; }
    public List<image> _images { get; set; }
    public List<int> _accessories { get; set; }
    public specifications _specs { get; set; }
    public string _features { get; set; }
    public string _configuraion { get; set; }
    public bool _dome { get; set; }
    public bool _indoor { get; set; }
    public bool _outdoor { get; set; }

    DataAccess da = new DataAccess();
    SqlCommand cmd = new SqlCommand();

    public product()
    { }

    public product(DataRow row, int id)
    {
        _header = row["header"].ToString();
        _description = row["description"].ToString();

        _images = getImages(id);
        _accessories = getAccessories(id);
        _specs = getSpecs(id);

        _features = row["features"].ToString();
        _configuraion = row["configuration"].ToString();

        _dome = Convert.ToBoolean(row["dome"]);
        _indoor = Convert.ToBoolean(row["indoor"]);
        _outdoor = Convert.ToBoolean(row["outdoor"]);
    }
    public List<int> getAccessories(int prodId)
    {
        DataTable dt = new DataTable();
        List<int> accessories = new List<int>();

        cmd.CommandText = "SELECT * FROM mtconsult_productAccessories WHERE prodFk =" + prodId;
        dt = da.GetData(cmd);

        foreach (DataRow accessori in dt.Rows)
        {
            accessories.Add(Convert.ToInt32(accessori["accessoriFk"]));
        }

        return accessories;
    }
    public List<image> getImages(int prodId)
    {
        DataTable dt = new DataTable();
        List<image> images = new List<image>();

        cmd.CommandText = "SELECT * FROM mtconsult_productImages WHERE prodFk = " + prodId;
        dt = da.GetData(cmd);

        foreach (DataRow image in dt.Rows)
        {
            image img = new image();
            img._filename = image["filename"].ToString();
            img._type = Convert.ToBoolean(image["type"]);
            images.Add(img);
        }

        return images;
    }
    public specifications getSpecs(int prodId)
    {
        DataTable dt = new DataTable();
        specifications specs = new specifications();

        specs._video = new List<specRow>();
        specs._features = new List<specRow>();
        specs._network = new List<specRow>();
        specs._io = new List<specRow>();
        specs._misc = new List<specRow>();

        cmd.CommandText = "SELECT * FROM mtconsult_specs WHERE prodFk = " + prodId;
        dt = da.GetData(cmd);

        foreach (DataRow spec in dt.Rows)
        {
            specRow specRow = new global::specRow();
            int type = Convert.ToInt32(spec["type"]);

            specRow._header = spec["header"].ToString();
            specRow._detail = spec["detail"].ToString();

            if (type == 0) specs._video.Add(specRow);
            else if (type == 1) specs._features.Add(specRow);
            else if (type == 2) specs._network.Add(specRow);
            else if (type == 3) specs._io.Add(specRow);
            else if (type == 4) specs._misc.Add(specRow);
        }

        return specs;
    }

    public List<product> getProducts()
    {
        DataTable dt = new DataTable();
        List<product> prods = new List<product>();

        cmd.CommandText = "SELECT * FROM mtconsult_product";
        dt = da.GetData(cmd);

        foreach (DataRow prod in dt.Rows)
        {
            int id = Convert.ToInt32(prod["id"]);
            prods.Add(new product(prod, id));
        }

        return prods;
    }
}

public class image
{
    public string _filename { get; set; }
    public bool _type { get; set; }
}
public class specifications
{
    public List<specRow> _video { get; set; }
    public List<specRow> _features { get; set; }
    public List<specRow> _network { get; set; }
    public List<specRow> _io { get; set; }
    public List<specRow> _misc { get; set; }
}
public class specRow
{
    public string _header { get; set; }
    public string _detail { get; set; }
}