using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using DAL;

namespace SalesTransaction.Pages
{
    public partial class ViewAllTransaction : System.Web.UI.Page
    {
        public TransactionDAL objDa=new TransactionDAL();
        public TransactionCom objCo=new TransactionCom();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindTransaction();
                if (Session["UserId"] == null || Convert.ToInt32(Session["UserId"]) < 0)
                {
                    Response.Redirect("~/Index.aspx");
                }

            }
            
        }
        private void BindTransaction()
        {
            DataTable dt = null;
            dt = objDa.SelectAllInvoice();
            ViewState["transaction"] = dt;
            if (dt != null && dt.Rows.Count > 0)
            {

                lvViewAll.DataSource = dt;
                lvViewAll.DataBind();
            }

        }


        protected void lbEdit_OnCommand(object sender, CommandEventArgs e)
        {
            Session["Id"] = e.CommandArgument.ToString();
            Response.Redirect("Home.aspx?Id=" + Session["Id"]);
        }
    }
}