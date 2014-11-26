using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        page page = new global::page();
        List<page> pages = new List<page>();

        if (Session["pages"] == null)
        {
            pages = page.getPages();
            Session["pages"] = pages;
        }
        else
        {
            pages = (List<page>)Session["pages"];
        }

        getSubpages(pages[0], litPage0);
        getSubpages(pages[1], litPage1);
        getSubpages(pages[2], litPage2);
        getSubpages(pages[3], litPage3);
        getSubpages(pages[4], litPage4);
        getSubpages(pages[5], litPage5);
    }
    public void getSubpages(page page, Literal litPage)
    {
        string queryString = HttpContext.Current.Request.Url.AbsolutePath;
        
        litPage.Text = "";
        foreach (subpage subpage in page._subpages)
        {
            string sub = Regex.Match(queryString, "/" + Regex.Replace(page._name, @"\s", "-") + "/" + Regex.Replace(subpage._name, @"\s", "-"), RegexOptions.IgnoreCase).ToString();
            if (sub != "")
            {
                litPage.Text += "<li class='selected'><a href='/" + Regex.Replace(page._name, @"\s", "-").ToLower() + "/" + Regex.Replace(subpage._name, @"\s", "-").ToLower() + "'>" + subpage._name + "</a></li>";
            }
            else
            {
                litPage.Text += "<li><a href='/" + Regex.Replace(page._name, @"\s", "-").ToLower() + "/" + Regex.Replace(subpage._name, @"\s", "-").ToLower() + "'>" + subpage._name + "</a></li>";
            }
        }
    }
}
