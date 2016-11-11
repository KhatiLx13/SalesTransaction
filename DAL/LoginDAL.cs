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
    public class LoginDAL:ConnectionHelper
    {
        public DataTable LoginUser(LoginCom obj)
        {
            DbCommand cmd = Db.GetStoredProcCommand("sp_login");
            Db.AddInParameter(cmd, "@user_name", DbType.String, obj.loginName);
            Db.AddInParameter(cmd, "@password", DbType.String, obj.loginPassword);
            DataSet ds = null;
            DataTable dt = null;
            ds = Db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }
    }
}
