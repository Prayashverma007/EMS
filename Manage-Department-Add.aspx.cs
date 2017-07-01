using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Employee.BLL;

public partial class Manage_Department_Add : System.Web.UI.Page
{
    // clsDeparment objDeparment = new clsDeparment();
    clsClient objClient = new clsClient();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request["Client"] != null)
            {
                getClientDetails(Convert.ToInt32(Request["ClientId"].ToString()));
                btnSave.Visible = false;
                btnUpdate.Visible = true;
            }
            else
            {
                btnSave.Visible = true;
                btnUpdate.Visible = false;
            }
        }
    }

    protected void getClientDetails(int ClientId)
    {
        objClient.ClientId= ClientId;
        objClient.SelectById();
        txtName.Text = objClient.ClientName.ToString();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Manage-Department.aspx");
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        objClient.ClientName = txtName.Text.Trim();
        objClient.Insert();
        Response.Redirect("Manage-Department.aspx");
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        objClient.ClientId = Convert.ToInt32(Request["ClientId"].ToString());
        objClient.ClientName = txtName.Text.Trim();
        objClient.Update();
        Response.Redirect("Manage-Department.aspx");
    }
}
