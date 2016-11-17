using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;
using System.Data;
using Capinfo.BJMedicare.Sys.Net20.Common.CommonLib.DBHelper;
using System.Configuration;

namespace Capinfo.Framework.AOP.DataHelper
{
    public class SqlDALBase : ContextBoundObject
    {
        private IDbTransaction _Trans;

        private IDbConnection connection =  DataBase.GetConnection();

        public SqlDALBase()
        {
            //GetConnection();
        }

        public static string GetConnectString(string strConfiguration)
        {
            string sServer = ConfigurationManager.AppSettings[strConfiguration];
            // string sDefaultConnectionString = "Data Source=236; User ID=bjmedicare_zw; Password=bjmedicare_zw;Connection Lifetime=3600;Enlist='false'; Max Pool Size=30";
            StringBuilder sDefaultConnectionString = new StringBuilder("Data Source = ").Append(sServer).Append(";User Id =bjmedicare_hd; ");
            sDefaultConnectionString.Append(" Password = bjmedicare_hd;Connection Lifetime=3600;Enlist='false'; Max Pool Size=30;");
            return sDefaultConnectionString.ToString();
        }

        /// <summary>
        /// 仅支持有事务时操作
        /// </summary>
        public IDbTransaction SqlTrans
        {
            get
            {
                if (_Trans == null)
                {
                    //从上下文中试图取得事务
                    object obj = CallContext.GetData(AopTransaction.ContextName);
                    if (obj != null && obj is IDbTransaction)
                        _Trans = obj as IDbTransaction;
                }
                return _Trans;
            }
            set { _Trans = value; }
        }

        #region ExecuteNonQuery
        public int ExecuteNonQuery(string cmdText)
        {

            if (SqlTrans == null)
                return DataBase.dbHelper.ExecuteNonQuery(connection, CommandType.Text, cmdText);
            else
                return DataBase.dbHelper.ExecuteNonQuery(SqlTrans, CommandType.Text, cmdText);
            //return 0;
        }
        public int ExecuteNonQuery(string cmdText, CommandType type)
        {
            if (SqlTrans == null)
                return DataBase.dbHelper.ExecuteNonQuery(connection.ConnectionString, type, cmdText);
            else
                return DataBase.dbHelper.ExecuteNonQuery(SqlTrans, type, cmdText);
            //return 0;
        }
        public int ExecuteNonQuery(string cmdText, CommandType type, params SqlParameter[] cmdParameters)
        {
            if (SqlTrans == null)
                return DataBase.dbHelper.ExecuteNonQuery(connection.ConnectionString, type, cmdText, cmdParameters);
            else
                return DataBase.dbHelper.ExecuteNonQuery(SqlTrans, type, cmdText, cmdParameters);
        }
        #endregion

        #region ExecuteDataset
        public DataSet ExecuteDataset(string cmdText)
        {
            if (SqlTrans == null)
                return DataBase.dbHelper.ExecuteDataset(connection.ConnectionString, CommandType.Text, cmdText);
            else
                return DataBase.dbHelper.ExecuteDataset(SqlTrans, CommandType.Text, cmdText);
        }

        public DataSet ExecuteDataset(string cmdText, CommandType type)
        {
            if (SqlTrans == null)
                return DataBase.dbHelper.ExecuteDataset(connection.ConnectionString, type, cmdText);
            else
                return DataBase.dbHelper.ExecuteDataset(SqlTrans, type, cmdText);
        }

        public DataSet ExecuteDataset(string cmdText, CommandType type, params SqlParameter[] cmdParameters)
        {
            if (SqlTrans == null)
                return DataBase.dbHelper.ExecuteDataset(connection.ConnectionString, type, cmdText, cmdParameters);
            else
                return DataBase.dbHelper.ExecuteDataset(SqlTrans, type, cmdText, cmdParameters);
        }

        #endregion


    }
}
