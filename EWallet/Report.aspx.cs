﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Report : System.Web.UI.Page
{
    DataBaseHandler cls = new DataBaseHandler();
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        int Flag = Convert.ToInt32(Request.QueryString["Flag"]) ;
        
        if (Flag == 2)
        {
            ds = cls.ShowTransactions(2, Convert.ToInt16(Request.QueryString["CustID"]));

        }
        else
        {
            ds = cls.ShowTransactions(1, Convert.ToInt16(Session["Userid"]));

        }
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }

    

    protected void ReportGridView_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

   

    protected void BtnReportBack_Click1(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}