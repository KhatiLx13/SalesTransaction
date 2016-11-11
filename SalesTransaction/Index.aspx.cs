using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using DAL;

namespace SalesTransaction
{
    public partial class Index : System.Web.UI.Page
    {
       public LoginCom objCom=new LoginCom();
       public LoginDAL objDa=new LoginDAL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_OnClick(object sender, EventArgs e)
        {
            DataTable dt = null;
            objCom.loginName = txtName.Text;
            objCom.loginPassword = txtPassword.Text;
            dt = objDa.LoginUser(objCom);
            if (dt != null && dt.Rows.Count > 0)
            {
                Session["UserId"] = dt.Rows[0]["user_id"].ToString();
                Session["Username"] = dt.Rows[0]["user_name"].ToString();
                Response.Redirect("/Pages/Home.aspx");
            }
            else
            {
                Response.Write("<script>alert('Wrong Username or Password')</script>");
            }
        }
    }
}