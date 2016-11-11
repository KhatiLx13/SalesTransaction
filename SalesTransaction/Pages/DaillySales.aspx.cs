using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using DAL;

namespace SalesTransaction.Pages
{
    public partial class DaillySales : System.Web.UI.Page
    {
        TransactionCom objCom=new TransactionCom();
        TransactionDAL objDa=new TransactionDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindSalesPerDay();
            }
        }

        private void BindSalesPerDay()
        {
            DataTable dt = null;
            objCom.date = Request.QueryString["Id"];
            dt = objDa.SalesPerDay(objCom);
            ViewState["daily"] = dt;
            if (dt != null && dt.Rows.Count > 0)
            {

                lvDaillySales.DataSource = dt;
                lvDaillySales.DataBind();
            }

        }
    }
}