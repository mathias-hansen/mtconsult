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

    public List<page> getPages()
    {
        DataAccess da = new DataAccess();
        DataTable dt = new DataTable();
        SqlCommand cmd = new SqlCommand();
        List<page> pages = new List<page>();
        subpage subpage = new global::subpage();
        int id = 2;

        cmd.CommandText = "SELECT * FROM mtconsult_page";
        dt = da.GetData(cmd);
        
        foreach (DataRow row in dt.Rows)
        {
            page page = new global::page();

            page._name = row["name"].ToString();
            page._content = row["content"].ToString();
            page._subpages = subpage.getSubpages(id, 0);
            id++;
            pages.Add(page);
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
            subpage subpage = new subpage();
            subpage._name = row["name"].ToString();
            subpage._content = row["content"].ToString();
            subpage._parent = id;
            subpage._level = Convert.ToInt32(row["level"]);
            subpage._subpages = this.getSubpages(Convert.ToInt32(row["id"]), Convert.ToInt32(row["level"]));
            subpages.Add(subpage);
        }

        return subpages;
    }
}