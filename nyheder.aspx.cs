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
        int pageId = 5;
        List<page> pages = (List<page>)Session["pages"];
        page page = pages[pageId];
        string query = HttpContext.Current.Request.Url.AbsolutePath;

        string sub = Regex.Match(query, "/" + Regex.Replace(page._name, @"\s", "-") + @".aspx/[\w\d\-]+", RegexOptions.IgnoreCase).ToString();
        if (sub != "")
        {
            subpage subpage = new subpage();
            subpage = page._subpages[subpage.getSubpageId(query, page._subpages)];
            displaySubPage(subpage, page._name);
        }
        else
        {
            displayPage(page);
        }
    }
    public void displayPage(page page)
    {

        litBreadcrumb.Text = "<bread-crumb type='first'><a href='/default.aspx'>Hjem</a></bread-crumb><bread-crumb type='last'><a href='/" + Regex.Replace(page._name, @"\s", "-").ToLower() + ".aspx'>" + page._name + "</a></bread-crumb>";

        litPagename.Text = page._name;

        litSubpages.Text = "";
        foreach (subpage subpage in page._subpages)
        {
            litSubpages.Text += "<li><a href='/" + Regex.Replace(page._name, @"\s", "-").ToLower() + ".aspx/" + Regex.Replace(subpage._name, @"\s", "-").ToLower() + "'>" + subpage._name + "</a>";
            // get subpage subpages
            litSubpages.Text += "</li>";
        }

        litContent.Text = page._content;
    }

    public void displaySubPage(subpage subpage, string pageName)
    {
        litBreadcrumb.Text = "<bread-crumb type='first'><a href='/hjem'>Hjem</a></bread-crumb><bread-crumb><a href='/" + Regex.Replace(pageName, @"\s", "-").ToLower() + ".aspx'>" + pageName + "</a></bread-crumb><bread-crumb type='last'><a href='/" + Regex.Replace(pageName, @"\s", "-").ToLower() + ".aspx/" + Regex.Replace(subpage._name, @"\s", "-").ToLower() + "'>" + subpage._name + "</a></bread-crumb>";

        litPagename.Text = subpage._name;

        litSubpages.Text = "";
        foreach (subpage subsubpage in subpage._subpages)
        {
            litSubpages.Text += "<li><a href='/" + Regex.Replace(pageName, @"\s", "-").ToLower() + ".aspx/" + Regex.Replace(subsubpage._name, @"\s", "-").ToLower() + "/" + Regex.Replace(subsubpage._name, @"\s", "-").ToLower() + "'>" + subsubpage._name + "</a></li>";
        }

        litContent.Text = subpage._content;
    }
}