﻿using System;
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

    public void getPage(int id)
    {
        DataAccess da = new DataAccess();
        DataTable dt = new DataTable();
        SqlCommand cmd = new SqlCommand();
        subpage subpage = new global::subpage();

        cmd.CommandText = "SELECT * FROM mtconsult_page WHERE id =" + id;
        dt = da.GetData(cmd);
        page page = new global::page();

        _name = dt.Rows[0]["name"].ToString();
        _content = dt.Rows[0]["content"].ToString();
        _subpages = subpage.getSubpages(id, 0);
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