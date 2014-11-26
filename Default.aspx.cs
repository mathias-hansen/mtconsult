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
            litSlider.Text = "";
            foreach (string img in slider._images)
            {
                litSlider.Text += "<img src='slider/images/" + img + "' />";
            }
        }
    }
}