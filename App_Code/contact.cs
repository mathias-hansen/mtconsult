using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class contact
{
    public static contact(string name, string email, string subject, int phone, string company, string descripiton, string comments)
    {
        DataAccess da = new DataAccess();
        SqlCommand cmd = new SqlCommand();

        cmd.CommandText = @"
        INSERT INTO 
        mtconsult_contact(name, email, subject, phone, company, description, comments) 
        VALUES('" + name + "', '" + email + "', '" + subject + "', " + phone + ", '" + company + "', '" + descripiton + "', '" + comments + "')";
        
        da.ModifyData(cmd);
    }
}