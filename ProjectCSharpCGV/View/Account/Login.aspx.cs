using ProjectCSharpCGV.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectCSharpCGV.View.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.txtPass.Text = "";
                this.txtEmailAndPhone.Text = "";
                //this.thongBao.Text = "Login fail!";
            }
        }

        protected void btLogin_Click(object sender, EventArgs e)
        {
            string username = this.txtEmailAndPhone.Text;
            string password = this.txtPass.Text;
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                this.thongBao.Text = "Username / Password is Empty!";
                this.thongBaoNgoai.Text= "Username / Password is Empty!";
            }
            else
            {
                //if (AccountDAO.checkLogin(username, password))
                //{
                //    // Response.Redirect("../../Default.aspx");
                //    this.thongBaoNgoai.Text = "Login done!";
                //}
                //else
                //{

                //    this.thongBao.Text = "Login fail!";
                //    this.thongBaoNgoai.Text = "Login fail!";
                //}
                bool check = AccountDAO.checkLogin(username, password);
               
                    this.thongBao.Text = check+"";
                    this.thongBaoNgoai.Text = check + "";

            }
            
        }
    }
}