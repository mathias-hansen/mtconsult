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
        product product = new global::product();
        List<product> prods = product.getProducts();

        litBreadcrumb.Text = "<bread-crumb type='first'><a href='/default.aspx'>Hjem</a></bread-crumb><bread-crumb type='last'><a href='/produkter.aspx'>Produkter</a></bread-crumb>";
        displayProds(prods);

        getNav(prods);
    }

    public void displayProds(List<product> prods)
    {
        int i = 0;
        string std = string.Empty;
        string dome = string.Empty;

        foreach (product prod in prods)
        {
            if (!prod._dome)
            {
                std += displayProd(prod, i);
            }
            else
            {
                dome += displayProd(prod, i);
            }
            i++;
        }

        litContent.Text += std + dome;
    }
    public string displayProd(product prod, int i)
    {
        List<image> images = new List<image>();
        List<image> techImages = new List<image>();
        string strProd = string.Empty;

        foreach (image img in prod._images)
        {
            if (img._type)
            {
                images.Add(img);
            }
            else
            {
                techImages.Add(img);
            }
        }

        strProd += "<div class='prod'>";

        strProd += "<img src='/img/prods/" + images[0]._filename + "' />";

        strProd += "<h2>" + prod._header + "</h2>";

        strProd += "<p>" + prod._description + "</p>";

        strProd += "<a href='/produkter.aspx?prod=" + i + "'>Læs mere</a>";

        // compare link

        return strProd += "</div>";
    }

    public void getNav(List<product> prods)
    {
        int i = 0;
        foreach (product prod in prods)
        {
            if (!prod._dome)
            {
                litStd.Text += "<li><a href='/produkter.aspx?prod=" + i + "'>" + prod._header + "</a></li>";
            }
            else
            {
                litDome.Text += "<li><a href='/produkter.aspx?prod=" + i + "'>" + prod._header + "</a></li>";
            }
            i++;
        }
    }
}