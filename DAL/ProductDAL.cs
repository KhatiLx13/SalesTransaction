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
    public class ProductDAL : ConnectionHelper
    {
        public int AddProducts(ProductCom objCom)
        {
            try
            {
                DbCommand cmd = Db.GetStoredProcCommand("sp_add_product");
                Db.AddInParameter(cmd, "@product_name", DbType.String, objCom.productName);
                Db.AddInParameter(cmd, "@category", DbType.String, objCom.productCategory);
                Db.AddInParameter(cmd, "@rate", DbType.String, objCom.productRate);
                Db.AddInParameter(cmd, "@user_id", DbType.Int32, objCom.userId);
                Db.AddInParameter(cmd, "@is_active", DbType.Boolean, objCom.isActive);
                return Db.ExecuteNonQuery(cmd);
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public int DeleteProductById(ProductCom objCom)
        {
            DbCommand cmd = Db.GetStoredProcCommand("sp_delete_product");
            Db.AddInParameter(cmd, "@product_id", DbType.Int32, objCom.productId);
            return Db.ExecuteNonQuery(cmd);
        }

        public DataTable SelectProductById(ProductCom objCom)
        {
            DbCommand cmd = Db.GetStoredProcCommand("sp_fetch_product_by_id");
            Db.AddInParameter(cmd, "@product_id", DbType.Int32, objCom.productId);
            DataTable dt = new DataTable();
            var ds = Db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count != 0)
                dt = ds.Tables[0];
            return dt;
        }

        public DataTable SelectAllProducts()
        {
            DbCommand cmd = Db.GetStoredProcCommand("sp_fetch_product");
            DataSet ds = null;
            ds = Db.ExecuteDataSet(cmd);
            DataTable dt = new DataTable();
            if (ds != null && ds.Tables.Count > 0)
                dt = ds.Tables[0];
            return dt;
        }

        public int UpdateProduct(ProductCom objCom)
        {
            try
            {
                DbCommand cmd = Db.GetStoredProcCommand("sp_update_product");
                Db.AddInParameter(cmd, "@product_id", DbType.Int32, objCom.productId);
                Db.AddInParameter(cmd, "@product_name", DbType.String, objCom.productName);
                Db.AddInParameter(cmd, "@category", DbType.String, objCom.productCategory);
                Db.AddInParameter(cmd, "@rate", DbType.String, objCom.productRate);
                Db.AddInParameter(cmd, "@user_id", DbType.Int32, objCom.userId);
                Db.AddInParameter(cmd, "@is_active", DbType.Int32, objCom.isActive);
                return Db.ExecuteNonQuery(cmd);
            }
            catch (Exception e)
            {
                return 0;
            }

        }
    }
}
