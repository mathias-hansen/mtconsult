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
        contact contact = new contact();
        contact.name = txtName.Text;
        contact.email = txtEmail.Text;
        contact.phone = Convert.ToInt32(txtPhone.Text);
        contact.company = txtCompany.Text;
        contact.descripiton = txtDescription.Text;
        contact.comments = txtComments.Text;
        contact.newContact();
    }
}