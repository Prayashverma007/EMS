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

public partial class Manage_Department : System.Web.UI.Page
{
    //clsDeparment objDeparment = new clsDeparment();
    clsLocation objLocation = new clsLocation(); 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //FillDepartmentDetails();
            FillLocationDetails();
        }
    }

    protected void FillLocationDetails()
    {
        gvMaster.DataSource = objLocation.SelectAll();
        gvMaster.DataBind();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Response.Redirect("Manage-Location-Add.aspx");
    }

    protected void gvMaster_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.ToString().ToUpper() == "EDIT")
        {
            Response.Redirect("Manage-Location-Add.aspx?LocationfrmId=" + e.CommandArgument.ToString());
        }
        if (e.CommandName.ToString().ToUpper() == "DELETE")
        {
            objLocation.LocationfrmId = Convert.ToInt32(e.CommandArgument.ToString());
            objLocation.Delete();
            lblMessage.Text = "Location successfully deleted!";
        }
    }

    protected void gvMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        FillLocationDetails();
    }

    protected void gvMaster_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lbDelete = (LinkButton)e.Row.FindControl("lbDelete");
            lbDelete.Attributes.Add("onclick", "return confirm('Are you sure to delete?');");
        }
    }

    protected void gvMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvMaster.PageIndex = e.NewPageIndex;
        //FillDepartmentDetails();
        FillLocationDetails();
    }

}
