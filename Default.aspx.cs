using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            slider slider = new slider();
            slider.getImages();
            foreach (image img in slider._images)
            {
                litSlider.Text += "<img src='slider/images/" + img._filename + "' alt'" + img._description + "' />";
            }
        }
    }
}