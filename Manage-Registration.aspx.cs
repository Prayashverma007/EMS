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

public partial class Manage_Registration : System.Web.UI.Page
{
    clsRegistration objRegistration = new clsRegistration();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillRegistrationDetails();
        }
    }

    protected void FillRegistrationDetails()
    {

        gvMaster.DataSource = objRegistration.SelectAll(); 
        gvMaster.DataBind();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Response.Redirect("Manage-Registration-Add.aspx");
    }

    protected void gvMaster_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        

        if (e.CommandName.ToString().ToUpper() == "EDIT")
        {
            Response.Redirect("Manage-Registration-Add.aspx?RegId=" + e.CommandArgument.ToString());
        }
        if (e.CommandName.ToString().ToUpper() == "DELETE")
        {
            objRegistration.RegId = Convert.ToInt32(e.CommandArgument.ToString());
            objRegistration.Delete();  
            lblMessage.Text = "Registration successfully deleted!";
        }
        if (e.CommandName.ToString().ToUpper() == "PRINT")
        {
            Response.Redirect("Master-List-Registration-Bill-Print.aspx?RegId=" + e.CommandArgument.ToString());
        }
    }

    protected void gvMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        FillRegistrationDetails();
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
        FillRegistrationDetails();
    }

    /*protected void chkStatus_CheckedChanged(object sender, EventArgs e)
    {
        FillEmployeeDetails();
    } */
}
