using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectCSharpCGV.App_Code;
namespace ProjectCSharpCGV.View.Account
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.drRegion.DataSource = RegionDAO.getAllRegion();
                this.drRegion.DataTextField = "name";
                this.drRegion.DataValueField = "id";
                this.drRegion.SelectedIndex = 0;
                this.drRegion.DataBind();

                this.drSite.DataSource = SiteDAO.getAllSite();
                this.drSite.DataTextField = "name";
                this.drSite.DataValueField = "id";
                this.drSite.SelectedIndex = 0;
                this.drSite.DataBind();
            }

        }

        protected void btRegister_Click(object sender, EventArgs e)
        {
            string name = this.txtName.Text;
            string phone = this.txtPhone.Text;
            if (!CheckValidate.VerifyPhoneNumber(phone))
            {
                this.thongBao.Text = "Error phone!";
            }
            else
            {
                string email = this.txtEmail.Text;

                string pass = this.txtPass.Text;
                string username = this.txtUsername.Text;
                bool gender = true;
                if (this.rdFemale.Checked)
                {
                    gender = false;
                }
                int idRegion = Convert.ToInt32(this.drRegion.SelectedValue);
                int idSite = Convert.ToInt32(this.drSite.SelectedValue);
                DateTime dob = this.dob.SelectedDate;
                if (AccountDAO.insertAccount(name, phone, email, username, pass, dob, gender, idRegion, idSite))
                {
                    Response.Redirect("../../Default.aspx");
                }
                else
                {
                    this.txtName.Text = "Login fail!";
                }
            }
            
            
        }
    }
}