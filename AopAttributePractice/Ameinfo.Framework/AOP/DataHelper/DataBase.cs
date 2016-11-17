using System;
using System.Collections.Generic;
using System.Text;
using Capinfo.BJMedicare.Sys.Net20.Common.CommonLib.DBHelper;
using System.Configuration;
using System.Data;

namespace Capinfo.Framework.AOP.DataHelper
{
    public class DataBase
    {
        private DataBase()
        {
        }
        //数据库助手实例
        public static DBHelper dbHelper = DBHelper.GetSingtonInstance(DBHelper.enumDBType.ORACLE);

        public static string GetConnectString(string strConfiguration)
        {
            string sServer = ConfigurationManager.AppSettings[strConfiguration];

            // string sDefaultConnectionString = "Data Source=236; User ID=bjmedicare_zw; Password=bjmedicare_zw;Connection Lifetime=3600;Enlist='false'; Max Pool Size=30";
            StringBuilder sDefaultConnectionString = new StringBuilder("Data Source = ").Append(sServer).Append(";User Id =bjmedicare_hd; ");
            sDefaultConnectionString.Append(" Password = bjmedicare_hd;Connection Lifetime=3600;Enlist='false'; Max Pool Size=30;");
            return sDefaultConnectionString.ToString();
        }
        //获取数据库连接
        public static IDbConnection GetConnection()
        {
            IDbConnection iConn = null;
            iConn = dbHelper.GetConnection();
            iConn.ConnectionString = GetConnectString("server");
            return iConn;
        }
    }
}
