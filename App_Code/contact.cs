using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class contact
{
    public string name { get; set; }
    public string email { get; set; }
    public string subject { get; set; }
    public int phone { get; set; }
    public string company { get; set; }
    public string descripiton { get; set; }
    public string comments { get; set; }

    public void newContact()
    {
        DataAccess da = new DataAccess();
        SqlCommand cmd = new SqlCommand();

        cmd.CommandText = @"
        INERT INTO 
        mtconsult_contact(name, email, subject, phone, company, description, comments) 
        VALUES('" + name + "', '" + email + "', '" + subject + "', " + phone + ", '" + company + "', '" + descripiton + "', '" + comments + "')";
        
        da.ModifyData(cmd);
    }
}