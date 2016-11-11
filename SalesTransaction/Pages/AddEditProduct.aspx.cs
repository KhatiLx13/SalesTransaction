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
    public partial class AddEditProduct : System.Web.UI.Page
    {
        public ProductCom objCom=new ProductCom();
        public ProductDAL objDa=new ProductDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindListview();
                if (Session["UserId"] == null || Convert.ToInt32(Session["UserId"]) < 0)
                {
                    Response.Redirect("~/Index.aspx");
                }
                
            }
        }

        protected void btnAdd_OnClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtProductName.Text.Trim()))
            {
                objCom.productName = txtProductName.Text;
            }
            if (!string.IsNullOrEmpty(txtCategory.Text.Trim()))
            {
                objCom.productCategory = txtCategory.Text;
            }
            if (!string.IsNullOrEmpty(txtProductRate.Text.Trim()))
            {
                objCom.productRate = txtProductRate.Text;
            }
            objCom.isActive = chkStatus.Checked;
            objCom.userId = Convert.ToInt32(Session["UserId"].ToString());

            int i = objDa.AddProducts(objCom);
            if (i > 0)
            {
                Response.Write("<script>alert('Product Added Successfully!!!')</script>");
                Response.Redirect("AddEditProduct.aspx");
            }
        }


       
        private void BindListview()
        {
            DataTable dt = null;
            dt = objDa.SelectAllProducts();
            ViewState["product"] = dt;
            if (dt != null && dt.Rows.Count > 0)
            {
                lvProducts.DataSource = dt;
                lvProducts.DataBind();
            }

        }

        


        protected void lbEdit_OnCommand(object sender, CommandEventArgs e)
        {
            Session["product_id"] = e.CommandArgument.ToString();
            Response.Redirect("AddEditProduct.aspx?product_id=" + Session["product_id"]);
        }
    }
}