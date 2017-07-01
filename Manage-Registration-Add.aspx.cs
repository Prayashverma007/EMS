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

public partial class Manage_Registration_Add : System.Web.UI.Page
{
    clsClient objClient = new clsClient();
    clsEmployee objEmployee = new clsEmployee();
    clsLocation objLocation = new clsLocation(); 
    clsRegistration objRegistration = new clsRegistration();  
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillClientNames();
            FillLocation();
            FillEmpDetails();
            if (Request["RegId"] != null)
            {
                getRegistrationDetails(Convert.ToInt32(Request["RegId"].ToString()));
                btnSave.Visible = false;
                btnUpdate.Visible = true;
                //imgPhoto.Visible = true;
            }
            else
            {
                btnSave.Visible = true;
                btnUpdate.Visible = false;
                //imgPhoto.Visible = false;
            }
        }
    }

    protected void FillClientNames()
    {
        DataSet dsClient = new DataSet();
        dsClient = objClient.SelectAll();
        ddlCompanyName.DataTextField = "ClientName";  
        ddlCompanyName.DataValueField = "ClientId";
        ddlCompanyName.DataSource = dsClient.Tables[0];
        ddlCompanyName.DataBind();
    }
    
    protected void FillEmpDetails()
    {
        DataSet dsEmployee = new DataSet();
        dsEmployee = objEmployee.SelectAll();
        ddlEmployee.DataTextField = "Name";
        ddlEmployee.DataValueField = "EmployeeId";
        ddlEmployee.DataSource = dsEmployee.Tables[0];
        ddlEmployee.DataBind(); 
    }

    protected void FillLocation()
    {
        DataSet dsLocation = new DataSet();
        dsLocation = objLocation.SelectAll();
        ddlLocationfrm.DataTextField = "LocationfrmName";
        ddlLocationto.DataTextField = "LocationfrmName";
        ddlLocationfrm.DataValueField = "LocationfrmId";
        ddlLocationto.DataValueField = "LocationfrmId";
        ddlLocationfrm.DataSource = dsLocation.Tables[0];
        ddlLocationto.DataSource = dsLocation.Tables[0];
        ddlLocationfrm.DataBind();
        ddlLocationto.DataBind();  
     }
    
    protected void getRegistrationDetails(int RegId)
    {
        objRegistration.RegId = RegId;
        objRegistration.SelectById();
        ddlEmployee.SelectedValue = objRegistration.EmployeeName.ToString();
        TxtDrivername.Text = objRegistration.DriverName;
        ddlLocationfrm.SelectedValue = objRegistration.Locationfrm.ToString();
        ddlLocationto.SelectedValue = objRegistration.Locationto.ToString();
        txtStartKm.Text = objRegistration.StartingKm;
        txtCloseKm.Text = objRegistration.ClosingKm;
        ddlTriptype.SelectedValue = objRegistration.Triptype.ToString();
        txtStarttime.Text = objRegistration.Startingtime;
        txtClosingTime.Text = objRegistration.Closingtime;
        if (objRegistration.DOT.CompareTo(Convert.ToDateTime("01/01/1900")) > 0)
        {
            txtDOT.Text = objRegistration.DOT.ToShortDateString();  
                
        }

        ddlCompanyName.SelectedValue = objRegistration.CompanyName.ToString();
        txtAdvance.Text = objRegistration.Advance;
        txtDiesel.Text = objRegistration.Diesel;
        if (objRegistration.DateofEntry.CompareTo(Convert.ToDateTime("01/01/1900")) > 0)
        {
            txtDateofEntry.Text = objRegistration.DateofEntry.ToShortDateString();
        }
        
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Manage-Registration.aspx");
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        /* string sFilename = Guid.NewGuid().ToString();
        if (filePhoto.HasFile)
        {
            string sPath = "";
            string sFile = filePhoto.FileName.ToString();
            sPath = Server.MapPath("EmpPhotos");
            sFilename = sFilename + sFile.Substring(sFile.LastIndexOf("."));
            filePhoto.SaveAs(sPath + "\\" + sFilename);
        }
        else
        {
            sFilename = "NoImage.jpg";
        } */
        objRegistration.EmployeeName = ddlEmployee.SelectedValue;
        objRegistration.DriverName = TxtDrivername.Text.Trim();
        objRegistration.Locationfrm = ddlLocationfrm.SelectedValue;
        objRegistration.Locationto = ddlLocationto.SelectedValue;
        objRegistration.StartingKm = txtStartKm.Text.Trim();
        objRegistration.ClosingKm = txtClosingTime.Text.Trim();
        objRegistration.Startingtime = txtStarttime.Text.Trim();
        objRegistration.Triptype = ddlTriptype.SelectedValue;
        objRegistration.Closingtime = txtClosingTime.Text.Trim();
        objRegistration.DOT = Convert.ToDateTime(txtDOT.Text.Trim());
        objRegistration.CompanyName = ddlCompanyName.SelectedValue; 
        objRegistration.Advance = txtAdvance.Text.Trim();
        objRegistration.Diesel = txtDiesel.Text.Trim();
        objRegistration.DateofEntry = System.DateTime.Today;  

        objRegistration.Insert();  
        Response.Redirect("Manage-Registration.aspx");
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        objRegistration.RegId = Convert.ToInt32(Request["RegId"].ToString());  
        
        /* string sFilename = Guid.NewGuid().ToString();
        if (filePhoto.HasFile)
        {
            string sPath = "";
            string sFile = filePhoto.FileName.ToString();
            sPath = Server.MapPath("EmpPhotos");
            sFilename = sFilename + sFile.Substring(sFile.LastIndexOf("."));
            filePhoto.SaveAs(sPath + "\\" + sFilename);
        }
        else
        {
            sFilename = txtPhoto.Text;
        } */

        objRegistration.EmployeeName = ddlEmployee.SelectedValue;
        objRegistration.DriverName = TxtDrivername.Text.Trim();
        objRegistration.Locationfrm = ddlLocationfrm.SelectedValue;
        objRegistration.Locationto = ddlLocationto.SelectedValue;
        objRegistration.StartingKm = txtStartKm.Text.Trim();
        objRegistration.ClosingKm = txtClosingTime.Text.Trim();
        objRegistration.Startingtime = txtStarttime.Text.Trim();
        objRegistration.Triptype = ddlTriptype.SelectedValue;
        objRegistration.Closingtime = txtClosingTime.Text.Trim();
        objRegistration.DOT = Convert.ToDateTime(txtDOT.Text.Trim());
        objRegistration.CompanyName = ddlCompanyName.Text.Trim();
        objRegistration.Advance = txtAdvance.Text.Trim();
        objRegistration.Diesel = txtDiesel.Text.Trim();
        objRegistration.DateofEntry = System.DateTime.Today;
        objRegistration.Update();  
        Response.Redirect("Manage-Registration.aspx");
    }
}
