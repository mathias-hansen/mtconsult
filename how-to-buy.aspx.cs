using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class how_to_buy : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        contact contact = new contact(txtName.Text, txtEmail.Text, txtSubject.Text, Convert.ToInt32(txtPhone.Text), txtCompany.Text, txtDescription.Text, txtComments.Text);
    }
}