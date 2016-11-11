using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace DAL
{
   public class TransactionDAL:ConnectionHelper
    {
        public int AddCustomer(TransactionCom objCom)
        {
            try
            {
                DbCommand cmd = Db.GetStoredProcCommand("sp_add_customer");
                Db.AddInParameter(cmd, "@name", DbType.String, objCom.custName);
                Db.AddInParameter(cmd, "@contact", DbType.String, objCom.custNumber);
                Db.AddInParameter(cmd, "@user_id", DbType.Int32, objCom.userId);
                return Db.ExecuteNonQuery(cmd);
            }
            catch (Exception e)
            {
                return 0;
            }
        }

       public int AddTransaction(TransactionCom objCom)
       {
           try
           {
               DbCommand cmd = Db.GetStoredProcCommand("sp_add_transaction");
               Db.AddInParameter(cmd, "@product_id", DbType.Int32, objCom.productId);
               Db.AddInParameter(cmd, "@customer_id", DbType.Int32, objCom.custId);
               Db.AddInParameter(cmd, "@quantity", DbType.Int32, objCom.quantity);
               Db.AddInParameter(cmd, "@amount", DbType.Int32, objCom.amount);
               Db.AddInParameter(cmd, "@user_id", DbType.Int32, objCom.userId);
               return int.Parse(Db.ExecuteDataSet(cmd).Tables[0].Rows[0][0].ToString());
               
           }
           catch (Exception e)
           {
               return 0;
           }
       }
       public int AddInvoice(TransactionCom objCom)
       {
           try
           {
               DbCommand cmd = Db.GetStoredProcCommand("sp_add_invoice");
               Db.AddInParameter(cmd, "@invoice_no", DbType.Int32, objCom.invoiceNo);
               Db.AddInParameter(cmd, "@date", DbType.Date, objCom.date);
               Db.AddInParameter(cmd, "@txn_id", DbType.Int32, objCom.txnId);
               Db.AddInParameter(cmd, "@total", DbType.Int32, objCom.total);
               Db.AddInParameter(cmd, "@user_id", DbType.Int32, objCom.userId);
               return Db.ExecuteNonQuery(cmd);
           }
           catch (Exception e)
           {
               return 0;
           }
       }

       public DataTable PopulateProductRate(int productId)
       {
           DbCommand cmd = Db.GetStoredProcCommand("sp_populate_rate");
           Db.AddInParameter(cmd, "@product_id", DbType.Int32, productId);
           DataSet ds = null;
           DataTable dt = null;
           ds = Db.ExecuteDataSet(cmd);
           if (ds != null && ds.Tables.Count > 0)
           {
               dt = ds.Tables[0];
           }
           return dt;
       }

       public DataTable CalcTotal(int custId,DateTime date)
       {
           DbCommand cmd = Db.GetStoredProcCommand("sp_calc_total");
           Db.AddInParameter(cmd, "@cust_id", DbType.Int32, custId);
           Db.AddInParameter(cmd, "@date", DbType.Date, date);
           DataSet ds = null;
           DataTable dt = null;
           ds = Db.ExecuteDataSet(cmd);
           if (ds != null && ds.Tables.Count > 0)
           {
               dt = ds.Tables[0];
           }
           return dt;
       }

       public DataTable SelectAllTransaction()
       {
           DbCommand cmd = Db.GetStoredProcCommand("sp_fetch_transaction");
           DataSet ds = null;
           ds = Db.ExecuteDataSet(cmd);
           DataTable dt = new DataTable();
           if (ds != null && ds.Tables.Count > 0)
               dt = ds.Tables[0];
           return dt;
       }

       public DataTable SelectTransactionById(TransactionCom objCom)
       {
           DbCommand cmd = Db.GetStoredProcCommand("sp_fetch_TransactionById");
           Db.AddInParameter(cmd, "@txn_id", DbType.Int32, objCom.txnId);
           DataTable dt = new DataTable();
           var ds = Db.ExecuteDataSet(cmd);
           if (ds != null && ds.Tables.Count != 0)
               dt = ds.Tables[0];
           return dt;
       }

       public int UpdateTransaction(TransactionCom objCom)
       {
           try
           {
               DbCommand cmd = Db.GetStoredProcCommand("sp_update_transaction");
               Db.AddInParameter(cmd, "@txn_id", DbType.Int32, objCom.txnId);
               Db.AddInParameter(cmd, "@product_id", DbType.Int32, objCom.productId);
               Db.AddInParameter(cmd, "@quantity", DbType.Int32, objCom.quantity);
               Db.AddInParameter(cmd, "@amount", DbType.Int32, objCom.amount);
               Db.AddInParameter(cmd, "@user_id", DbType.Int32, objCom.userId);
               return Db.ExecuteNonQuery(cmd);

           }
           catch (Exception e)
           {
               return 0;
           }
       }
       public int UpdateInvoice(TransactionCom objCom)
       {
           try
           {
               DbCommand cmd = Db.GetStoredProcCommand("sp_update_invoice");
               Db.AddInParameter(cmd, "@invoice_id", DbType.Int32, objCom.invoiceId);
               Db.AddInParameter(cmd, "@invoice_no", DbType.Int32, objCom.invoiceNo);
               Db.AddInParameter(cmd, "@date", DbType.Date, objCom.date);
               Db.AddInParameter(cmd, "@total", DbType.Int32, objCom.total);
               Db.AddInParameter(cmd, "@user_id", DbType.Int32, objCom.userId);
               return Db.ExecuteNonQuery(cmd);
           }
           catch (Exception e)
           {
               return 0;
           }
       }
       public DataTable SelectAllInvoice()
       {
           DbCommand cmd = Db.GetStoredProcCommand("sp_fetch_invoice");
           DataSet ds = null;
           ds = Db.ExecuteDataSet(cmd);
           DataTable dt = new DataTable();
           if (ds != null && ds.Tables.Count > 0)
               dt = ds.Tables[0];
           return dt;
       }

       public DataTable SelectInvoiceById(TransactionCom objCom)
       {
           DbCommand cmd = Db.GetStoredProcCommand("sp_fetch_invoice_by_id");
           Db.AddInParameter(cmd, "@invoice_id", DbType.Int32, objCom.invoiceId);
           DataTable dt = new DataTable();
           var ds = Db.ExecuteDataSet(cmd);
           if (ds != null && ds.Tables.Count != 0)
               dt = ds.Tables[0];
           return dt;
       }



    }
}
