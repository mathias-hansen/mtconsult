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

        displayProds(prods);

        getNav(prods);
    }

    public void displayProds(List<product> prods)
    {
        litContent.Text = "<div class='standard'>";
        foreach (product prod in prods)
        {
            if (!prod._dome)
            {
                displayProd(prod);
            }
        }
        litContent.Text += "</div>";

        litContent.Text += "<div class='dome'>";
        foreach (product prod in prods)
        {
            if (prod._dome)
            {
                displayProd(prod);
            }
        }
        litContent.Text += "</div>";
    }
    public void displayProd(product prod)
    {
        List<image> images = new List<image>();
        List<image> techImages = new List<image>();

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

        litContent.Text += "<div class='prod'>";

        litContent.Text += "<img src='/img/prods/" + images[0]._filename + "' />";

        litContent.Text += "<h2>" + prod._header + "</h2>";

        litContent.Text += "<p>" + prod._description + "</p>";

        litContent.Text += "<a href='/produkter.aspx/" + Regex.Replace(prod._header, @"\s", "-").ToLower() + "'>Læs mere</a>";

        // compare link

        litContent.Text += "</div>";
    }

    public void getNav(List<product> prods)
    {
        foreach (product prod in prods)
        {
            if (!prod._dome)
            {
                litStd.Text += "<li><a href='/produkter.aspx/" + Regex.Replace(prod._header, @"\s", "-").ToLower() + "'>" + prod._header + "</a></li>";
            }
            else
            {
                litDome.Text += "<li><a href='/produkter.aspx/" + Regex.Replace(prod._header, @"\s", "-").ToLower() + "'>" + prod._header + "</a></li>";
            }
        }
    }
}