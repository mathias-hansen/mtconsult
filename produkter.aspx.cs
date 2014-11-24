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
        page page = new global::page();
        page.getPage(4);

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
}