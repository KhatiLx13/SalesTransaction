using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace SalesTransaction.Pages
{
    public partial class SalesOnDate : System.Web.UI.Page
    {
        TransactionDAL objDa=new TransactionDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            BindTransaction();
        }
        private void BindTransaction()
        {
            DataTable dt = null;
            dt = objDa.SalesOnDate();
            ViewState["daily"] = dt;
            if (dt != null && dt.Rows.Count > 0)
            {

                lvTotalByDate.DataSource = dt;
                lvTotalByDate.DataBind();
            }

        }
    }
}