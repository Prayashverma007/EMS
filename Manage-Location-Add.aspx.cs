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

public partial class Manage_Location_Add : System.Web.UI.Page
{
    // clsDeparment objDeparment = new clsDeparment();
    clsLocation objLocation = new clsLocation();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request["LocationfrmId"] != null)
            {
                getLocationDetails(Convert.ToInt32(Request["LocationfrmId"].ToString()));
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

    protected void getLocationDetails(int LocationfrmId)
    {
        objLocation.LocationfrmId = LocationfrmId;
        objLocation.SelectById();
        txtName.Text = objLocation.LocationfrmName.ToString();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Manage-Locations.aspx");
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        objLocation.LocationfrmName = txtName.Text.Trim();
        objLocation.Insert();
        Response.Redirect("Manage-Locations.aspx");
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        objLocation.LocationfrmId = Convert.ToInt32(Request["LocationfrmId"].ToString());
        objLocation.LocationfrmName = txtName.Text.Trim();
        objLocation.Update();
        Response.Redirect("Manage-Locations.aspx");
    }
}
