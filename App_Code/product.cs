using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

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
    public int _resolution { get; set; }

    DataAccess da = new DataAccess();
    SqlCommand cmd = new SqlCommand();

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
        _resolution = new resolutions().list[Convert.ToInt32(row["resolution"])];
    }
    List<int> getAccessories(int prodId)
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
    List<image> getImages(int prodId)
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
    specifications getSpecs(int prodId)
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

    public static List<product> getProducts()
    {
        DataAccess da = new DataAccess();
        SqlCommand cmd = new SqlCommand();
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

    public string displayProds(List<product> prods)
    {
        int i = 0;
        string std = string.Empty;
        string dome = string.Empty;

        foreach (product prod in prods)
        {
            if (!prod._dome)
            {
                std += prod.displayProd(i);
            }
            else
            {
                dome += prod.displayProd(i);
            }
            i++;
        }

        return "<div class='std'><h2>Standard Kameraer</h2>" + std + "</div><div class='dome'><h2>Dome Kameraer</h2>" + dome + "</div>";
    }
    public string displayProd(int i)
    {
        List<image> images = new List<image>();
        string str = string.Empty;

        foreach (image img in _images)
        {
            if (img._type)
            {
                images.Add(img);
            }
        }

        str += "<div class='prod'>";

        str += "<img src='" + images[0]._filename + "' />";

        str += "<h3>" + _header + "</h3>";

        str += "<p>" + _description + "</p>";

        str += "<div class='buttons'><a href='/produkter.aspx?prod=" + i + "'>Læs mere</a><a href='/produkter.aspx/produkt-sammenligner?prod=" + i + "'>Sammenlign</a></div>";

        return str += "</div>";
    }

    public string displayProdDescription(int p)
    {
        string str = string.Empty;

        str += "<div class='description'>";
        str += "<div class='text'><h1>" + _header + "</h1>";
        str += "<p>" + _description + "</p><div><a class='comp' href='/produkter.aspx/produkt-sammenligner?prod=" + p + "'>Sammenlign</a><a class='how' href='/how-to-buy.aspx'>How To Buy</a></div></div>";
        str += "<div class='images'><img src='" + _images[0]._filename + "' />";
        str += "<div class='select'>";
        for (int i = 0; i < _images.Count; i++)
        {
            if (_images[i]._type)
            {
                if (i == 0)
                {
                    str += "<img class='selected' src='" + _images[i]._filename + "' />";
                }
                else
                {
                    str += "<img src='" + _images[i]._filename + "' />";
                }
            }
        }
        str += "</div></div></div>";

        return str;
    }
    public string displayProdContent()
    {
        string str = string.Empty;

        str += "<div class='prodContent'>";

        str += "<div class='features'><p>" + _features + "</p></div>";

        str += "<div class='specs hidden'>specs</div>";

        str += "<div class='config hidden'><p>" + _configuraion + "</p></div>";

        str += "<div class='techdrawing hidden'>";
        foreach (image img in _images)
        {
            if (!img._type)
            {
                str += "<img src='/img/prods/" + img._filename + "' />";
            }
        }
        str += "</div>";

        str += "<div class='tilbehor hidden'>tilbehør</div>";

        str += "</div>";

        return str;
    }
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

public class resolutions
{
    public Dictionary<int, int> list = new Dictionary<int, int>();
    public resolutions()
    {
        list.Add(0, 10);
        list.Add(1, 20);
        list.Add(2, 31);
        list.Add(3, 36);
        list.Add(4, 50);
        list.Add(5, 120);
    }
}