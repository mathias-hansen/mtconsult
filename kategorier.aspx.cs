using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class om_os : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int pageId = 1;
        List<page> pages = (List<page>)Session["pages"];
        page page = pages[pageId];
        string query = HttpContext.Current.Request.Url.AbsolutePath;

        string sub = Regex.Match(query, "/" + Regex.Replace(page._name, @"\s", "-") + @"/[\w\d\-]+", RegexOptions.IgnoreCase).ToString();
        if (sub != "")
        {
            subpage subpage = page._subpages[getSubpageId(query, page._subpages)];
            getSubPage(subpage, page._name);
        }
        else
        {
            getPage(page);
        }
    }
    public void getPage(page page)
    {

        litBreadcrumb.Text = "<bread-crumb type='first'><a href='/hjem'>Hjem</a></bread-crumb><bread-crumb type='last'><a href='/" + Regex.Replace(page._name, @"\s", "-").ToLower() + "'>" + page._name + "</a></bread-crumb>";

        litPagename.Text = page._name;

        litSubpages.Text = "";
        foreach (subpage subpage in page._subpages)
        {
            litSubpages.Text += "<li><a href='/" + Regex.Replace(page._name, @"\s", "-").ToLower() + "/" + Regex.Replace(subpage._name, @"\s", "-").ToLower() + "'>" + subpage._name + "</a>";
            // get subpage subpages
            litSubpages.Text += "</li>";
        }

        litContent.Text = page._content;
    }

    public void getSubPage(subpage subpage, string pageName)
    {
        litBreadcrumb.Text = "<bread-crumb type='first'><a href='/hjem'>Hjem</a></bread-crumb><bread-crumb><a href='/" + Regex.Replace(pageName, @"\s", "-").ToLower() + "'>" + pageName + "</a></bread-crumb><bread-crumb type='last'><a href='/" + Regex.Replace(pageName, @"\s", "-").ToLower() + "/" + Regex.Replace(subpage._name, @"\s", "-").ToLower() + "'>" + subpage._name + "</a></bread-crumb>";

        litPagename.Text = subpage._name;

        litSubpages.Text = "";
        foreach (subpage subsubpage in subpage._subpages)
        {
            litSubpages.Text += "<li><a href='/" + Regex.Replace(subsubpage._name, @"\s", "-").ToLower() + "/" + Regex.Replace(subsubpage._name, @"\s", "-").ToLower() + "'>" + subsubpage._name + "</a></li>";
        }
        litContent.Text = subpage._content;
    }
    public int getSubpageId(string query, List<subpage> subpages)
    {
        int id = -1;
        int i = 0;

        foreach (subpage subpage in subpages)
        {
            if (Regex.Match(query, subpage._name + "$").ToString() != "")
            {
                id = i;
            }
            i++;
        }
        return id;
    }
}