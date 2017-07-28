﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Transfer : System.Web.UI.Page
{
    DataBaseHandler cls = new DataBaseHandler();
    DataSet ds = new DataSet();
    DataSet ds1 = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    Regex reg;// = new Regex (@"\D*([2-9]\d{2})(\D*)([2-9]\d{2})(\D*)(\d{4})\D*");
    protected void BtbSend_Click(object sender, EventArgs e)
    {
        if (RbtnType.SelectedValue == "2")
        {
            reg = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
            lbltype.Text = "Email ID";
        }
        else if (RbtnType.SelectedValue == "1")
        {
            reg = new Regex(@"\D*([2-9]\d{2})(\D*)([2-9]\d{2})(\D*)(\d{4})\D*");
            lbltype.Text = "Phone Number";
        }
        if (!reg.IsMatch(txtphonemail.Text))
        {
            lblMes.Text = "Please enter valid entry";
            txtphonemail.Text = "";
        }
        else if (txtbal.Text.Equals(""))
        {
            lblMes.Text = "Please enter an amount";
            txtbal.Text = "";

        }
        else
        {
            ds = cls.UserDetails("6475289869", 1);
            ds1 = cls.UserDetails(txtphonemail.Text, Convert.ToInt16(RbtnType.SelectedValue));
            if (ds1 == null)
            {
                lblMes.Text = "Phone/Email Number not found";

            }
            else
            {
                string balance = ds.Tables[0].Rows[0]["Balance"].ToString();
                string CustID = ds1.Tables[0].Rows[0]["CustomerID"].ToString();
            
         
         if (Convert.ToInt16(balance) < Convert.ToInt16(txtbal.Text))
                {
                    lblMes.Text = "Oops! Not enough balance!";
                }
                else
                {
                    string updatedAmt = Convert.ToString(Convert.ToInt64(balance) - Convert.ToInt64(txtbal.Text));
                    Response.Redirect("ConfirmationForm.aspx?CustID=" + CustID + "&CurBal=" + balance + "&DeductedAmt=" + txtbal.Text + "&updatedAmt=" + updatedAmt);
                }
            }
        }

    }

    protected void RBtnChange(object sender, EventArgs e)
    {
        if (RbtnType.SelectedValue == "2")
        {
            reg = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
            lbltype.Text = "Email ID";
        }
        else if (RbtnType.SelectedValue == "1")
        {
            reg = new Regex(@"\D*([2-9]\d{2})(\D*)([2-9]\d{2})(\D*)(\d{4})\D*");
            lbltype.Text = "Phone Number";
        }
    }

}


