using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class ConnectionHelper
    {
       protected Database Db
       {
           get
           {
               var db = DatabaseFactory.CreateDatabase("Conn");
               return db;
           }
       } 
   }

}
