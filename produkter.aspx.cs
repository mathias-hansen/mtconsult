using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class produkter : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        List<product> prods = product.getProducts();

        int prod = Convert.ToInt32(Request.QueryString["prod"]);

        if (Request.QueryString["prod"] != null)
        {
            litBreadcrumb.Text = "<bread-crumb type='first'><a href='/default.aspx'>Hjem</a></bread-crumb><bread-crumb><a href='/produkter.aspx'>Produkter</a></bread-crumb><bread-crumb type='last'><a href='/produkter.aspx?prod=" + prod + "'>" + prods[prod]._header + "</a></bread-crumb>";
            litTop.Text = "<p tabindex='0' class='selected'>Funktioner</p><p tabindex='0'>Specifikationer</p><p tabindex='0'>Konfiguration</p><p tabindex='0'>Tekniske Tegninger</p><p tabindex='0'>Tilbehør</p>";

            S.Attributes.Add("style", "background-color: transparent");
            S1.Attributes.Add("style", "display: block; padding: 0");

            litProductDescription.Text = prods[prod].displayProdDescription(prod);
            litContent.Text = prods[prod].displayProdContent();

            getNav(prods, prods[prod]);
        }
        else
        {
            litBreadcrumb.Text = "<bread-crumb type='first'><a href='/default.aspx'>Hjem</a></bread-crumb><bread-crumb type='last'><a href='/produkter.aspx'>Produkter</a></bread-crumb>";
            litContent.Text = prods[0].displayProds(prods);

            getNav(prods);
        }
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
    public void getNav(List<product> prods, product self)
    {
        int i = 0;
        foreach (product prod in prods)
        {
            if (prod == self)
            {
                if (!prod._dome)
                {
                    litStd.Text += "<li class='selected'><a href='/produkter.aspx?prod=" + i + "'>" + prod._header + "</a></li>";
                }
                else
                {
                    litDome.Text += "<li class='selected'><a href='/produkter.aspx?prod=" + i + "'>" + prod._header + "</a></li>";
                }
            }
            else
            {
                if (!prod._dome)
                {
                    litStd.Text += "<li><a href='/produkter.aspx?prod=" + i + "'>" + prod._header + "</a></li>";
                }
                else
                {
                    litDome.Text += "<li><a href='/produkter.aspx?prod=" + i + "'>" + prod._header + "</a></li>";
                }
            }
            i++;
        }
    }
}