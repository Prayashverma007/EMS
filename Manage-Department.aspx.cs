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
    clsClient objClient = new clsClient();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //FillDepartmentDetails();
            FillClientDetails();
        }
    }

    protected void FillClientDetails()
    {
        gvMaster.DataSource = objClient.SelectAll();
        gvMaster.DataBind();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Response.Redirect("Manage-Department-Add.aspx");
    }

    protected void gvMaster_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.ToString().ToUpper() == "EDIT")
        {
            Response.Redirect("Manage-Department-Add.aspx?DeparmentId=" + e.CommandArgument.ToString());
        }
        if (e.CommandName.ToString().ToUpper() == "DELETE")
        {
            objClient.ClientId = Convert.ToInt32(e.CommandArgument.ToString());
            objClient.Delete();
            lblMessage.Text = "Client successfully deleted!";
        }
    }

    protected void gvMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        FillClientDetails();
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
        FillClientDetails();
    }

}
