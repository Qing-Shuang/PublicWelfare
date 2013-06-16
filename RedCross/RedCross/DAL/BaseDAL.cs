using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using RedCross.Models.Entities;

namespace RedCross.DAL
{
    public enum Behavious
    {
        INSERT_OR_UPDATE_OR_DELETE,
        SELECT_WITHOUT_PARAM,
        SELECT_WITH_MUTIPARAM,
        SELECT_WITH_SINGLEPARAM,
        DELETE_SINGLE
    }

    public class BaseDAL
    {
        public readonly string ConnectionStr
            = ConfigurationManager.ConnectionStrings["MySqlDB"].ConnectionString;

        private MySqlConnection connect;
        private MySqlCommand command;
        private MySqlParameter param;
        private MySqlDataReader dread;
        private List<MySqlParameter> list_param;
        private static BaseDAL dalBase;
        public string sql = "";

        public MySqlDataReader DataRead
        {
            get { return dread; }
        }

        public List<MySqlParameter> List_param
        {
            set { list_param = value; }
            get { return list_param; }
        }

        public MySqlParameter Param
        {
            set {param = value;}
        }

        public bool IsConnect
        {
            get
            {
                return connect.State == ConnectionState.Open ? true : false;
            }
        }

        private object threadLock = new object();

        public static BaseDAL Instance()
        {
            if (dalBase == null)
            {
                dalBase = new BaseDAL();
            }
            return dalBase;
        }

        public bool Run(Behavious behv,bool flag_close)
        {
            bool flag_success = true;
            try
            {
	            ConnectOpen();
                IsReaderClose();
	            if (behv == Behavious.INSERT_OR_UPDATE_OR_DELETE)
	            {
	                InsertOrUpdateOrDelete(sql);
	            }
	            else if (behv == Behavious.SELECT_WITH_MUTIPARAM)
	            {
	                SelectWithMutiParam(sql);
	            }
	            else if (behv == Behavious.SELECT_WITH_SINGLEPARAM)
	            {
	                SelectWirhSingleParam(sql);
	            }
	            else if (behv == Behavious.SELECT_WITHOUT_PARAM)
	            {
	                SelectWithOutParam(sql);
	            }
                else if (behv == Behavious.DELETE_SINGLE)
                {
                    DeleteWirhSingleParam(sql);
                }
                else
                {
                    flag_success = false;
                }
            }
            catch (System.Exception ex)                        
            {
                flag_success = false;
            }

            if (flag_close)
            {
                CloseConnect();
            }
            return flag_success;
        }

        public void ConnectOpen()
        {
            if (connect == null)
            {
                connect = new MySqlConnection();
                connect.ConnectionString = ConnectionStr;
            }
            if (connect.State == ConnectionState.Closed)
            {
                connect.Open();
            }
            else if (connect.State == ConnectionState.Broken)
            {
                connect.Close();
                connect.Open();
            }
        }

        public void CloseConnect()
        {
            if (connect.State != ConnectionState.Closed)
            {
                connect.Close();
            }
        }

        public void IsReaderClose()
        {
            if (dread != null && !dread.IsClosed)
            {
                dread.Close();
            }
        }

        public void SelectWithOutParam(string sqlStr)
        {
            using (command = new MySqlCommand(sqlStr, connect))
            {
                dread = command.ExecuteReader();
            }
        }

        public void SelectWirhSingleParam(string sqlStr)
        {
            using (command = new MySqlCommand(sqlStr, connect))
            {
                command.Parameters.Add(param);
                dread = command.ExecuteReader();
            }
        }

        public void SelectWithMutiParam(string sqlStr)
        {
            using (command = new MySqlCommand(sqlStr, connect))
            {
                for (int i = 0; i < this.list_param.Count; ++i)
                {
                    command.Parameters.Add(this.list_param[i]);
                }
                dread = command.ExecuteReader();
            }
        }

        public void InsertOrUpdateOrDelete(string sqlStr)
        {
            using (command = new MySqlCommand(sqlStr, connect))
            {
                for (int i = 0; i < list_param.Count; ++i)
                {
                    command.Parameters.Add(list_param[i]);
                }
                command.ExecuteNonQuery();
            }
        }

        public void DeleteWirhSingleParam(string sqlStr)
        {
            using (command = new MySqlCommand(sqlStr, connect))
            {
                command.Parameters.Add(param);
                command.ExecuteNonQuery();
            }
        }
    }
}