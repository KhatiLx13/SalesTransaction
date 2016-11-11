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
    public partial class Home : System.Web.UI.Page
    {
        public TransactionCom objCom=new TransactionCom();
        public TransactionDAL objDa = new TransactionDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //PopulateProductPrice(objCom.productId);
                if (Request.QueryString["Id"] != null)
                {
                    Session["Id"] = Request.QueryString["Id"];
                    BindTransaction();
                    ddlCustomer.Enabled = false;
                    btnSave.Text = "Update";
                }
                if (Session["UserId"] == null || Convert.ToInt32(Session["UserId"]) < 0)
                {
                    Response.Redirect("~/Index.aspx");
                }
            }
        }
        private void BindTransaction()
        {
            objCom.invoiceId = Int32.Parse(Request.QueryString["Id"]);
            DataTable dt = null;
            dt = objDa.SelectInvoiceById(objCom);
            hidTxnID.Value = dt.Rows[0]["txn_id"].ToString();
            ddlCustomer.SelectedValue = dt.Rows[0]["customer_id"].ToString();
            ddlProduct.SelectedValue = dt.Rows[0]["product_id"].ToString();
            ddlQuantity.SelectedValue = dt.Rows[0]["quantity"].ToString();
            txtAmount.Text = dt.Rows[0]["amount"].ToString();
            txtInvoiceNo.Text = dt.Rows[0]["invoice_no"].ToString();
           
        }

        protected void btnAddCustomer_OnClick(object sender, EventArgs e)
        {
           
            if (!string.IsNullOrEmpty(txtCustomerName.Text.Trim()))
            {
                objCom.custName = txtCustomerName.Text;
            }
            if (!string.IsNullOrEmpty(txtContact.Text.Trim()))
            {
                objCom.custNumber = txtContact.Text;
            }
            objCom.userId = Convert.ToInt32(Session["UserId"].ToString());
            int i = objDa.AddCustomer(objCom);
            if (i > 0)
            {
                Response.Redirect("Home.aspx");
            }
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            int a = 0;
            objCom.userId = Convert.ToInt32(Session["UserId"].ToString());
            if (Convert.ToInt32(ddlCustomer.SelectedValue) > 0)
            {
                objCom.custId = Convert.ToInt32(ddlCustomer.SelectedValue);
            }
            if (Convert.ToInt32(ddlProduct.SelectedValue) > 0)
            {
                objCom.productId = Convert.ToInt32(ddlProduct.SelectedValue);
            }
            if (Convert.ToInt32(ddlQuantity.SelectedValue) > 0)
            {
                objCom.quantity = Convert.ToInt32(ddlQuantity.SelectedValue);
            }
            objCom.amount = Convert.ToInt32(ddlQuantity.SelectedValue) * Convert.ToInt32(lblRate.Text);
            txtAmount.Text = Convert.ToString(objCom.amount);
           
            if (!string.IsNullOrEmpty(txtInvoiceNo.Text.Trim()))
            {
                objCom.invoiceNo = Convert.ToInt32(txtInvoiceNo.Text);
            }
            objCom.date=DateTime.Today.ToString("MM/dd/yyyy");

            if (Request.QueryString["Id"] != null)
            {
                Session["Id"] = Request.QueryString["Id"];
                objCom.txnId = Convert.ToInt32(hidTxnID.Value);
                objCom.invoiceId = Int32.Parse(Request.QueryString["Id"]);
                a = objDa.UpdateTransaction(objCom);
                if (a > 0)
                {
                    int j = objDa.UpdateInvoice(objCom);
                    if (j > 0)
                    {
                        Response.Write("<script>alert('Transaction Updated  Successfull!!!')</script>");
                    }
                    
                }

            }
            else
            {
                a = objDa.AddTransaction(objCom);

                if (a > 0)
                {
                    objCom.txnId = a;
                    objCom.total += Convert.ToInt32(txtAmount.Text);
                    int j = objDa.AddInvoice(objCom);
                    if (j > 0)
                    {
                        Response.Write("<script>alert('Transaction Successfull!!!')</script>");
                    }

                }
            }

            

        }
        private void PopulateProductPrice(int productId)
        {
            DataTable dt = objDa.PopulateProductRate(productId);
            lblRate.Enabled = true;
            lblRate.Text = dt.Rows[0].Field<string>("product_rate");
        }

        protected void ddlProduct_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int productId = Convert.ToInt32(ddlProduct.SelectedValue);
            PopulateProductPrice(productId);
        }

        protected void ddlQuantity_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            
            objCom.amount = Convert.ToInt32(ddlQuantity.SelectedValue) * Convert.ToInt32(lblRate.Text);
            txtAmount.Text = Convert.ToString(objCom.amount);
            objCom.custId = Convert.ToInt32(ddlCustomer.SelectedValue);
            
            
        }


       

       
    }
}