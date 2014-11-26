using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class page
{
    public string _name { get; set; }
    public string _content { get; set; }
    public List<subpage> _subpages { get; set; }

    public page()
    { }

    public page(DataRow row, int id)
    {
        subpage subpage = new global::subpage();

        _name = row["name"].ToString();
        _content = row["content"].ToString();
        _subpages = subpage.getSubpages(id, 0);
    }

    public List<page> getPages()
    {
        DataAccess da = new DataAccess();
        DataTable dt = new DataTable();
        SqlCommand cmd = new SqlCommand();
        List<page> pages = new List<page>();

        int id = 2;

        cmd.CommandText = "SELECT * FROM mtconsult_page";
        dt = da.GetData(cmd);

        foreach (DataRow row in dt.Rows)
        {
            pages.Add(new global::page(row, id));
            id++;
        }
        return pages;
    }
}

public class subpage
{
    public string _name { get; set; }
    public string _content { get; set; }
    public int _parent { get; set; }
    public int _level { get; set; }
    public List<subpage> _subpages { get; set; }

    public subpage()
    { 
    
    }

    public subpage(DataRow row, int id)
    {
        _name = row["name"].ToString();
        _content = row["content"].ToString();
        _parent = id;
        _level = Convert.ToInt32(row["level"]);
        _subpages = this.getSubpages(Convert.ToInt32(row["id"]), Convert.ToInt32(row["level"]));
    }

    public List<subpage> getSubpages(int id, int level)
    {
        DataAccess da = new DataAccess();
        DataTable dt = new DataTable();
        SqlCommand cmd = new SqlCommand();
        List<subpage> subpages = new List<subpage>();

        cmd.CommandText = "SELECT * FROM mtconsult_subpage WHERE parent =" + id + "AND level =" + ++level;
        dt = da.GetData(cmd);

        foreach (DataRow row in dt.Rows)
        {
            subpages.Add(new subpage(row, id));
        }

        return subpages;
    }
}