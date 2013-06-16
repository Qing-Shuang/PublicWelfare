using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MySql.Data.MySqlClient;

using RedCross.Models.Entities;

namespace RedCross.DAL
{
    public class GrdDAL:PoolUtil
    {
        public List<Grade> list_GrdInfo;
        public Grade grdInfo = null;

        public GrdDAL()
        {
            list_GrdInfo = new List<Grade>();
        }

        public bool GetGrds()
        {
            dalBase.sql = "SELECT * FROM db_grade";
            if (dalBase.Run(Behavious.SELECT_WITHOUT_PARAM, false))
            {
                while (dalBase.DataRead.Read())
                {
                    grdInfo = new Grade()
                    {
                        ID = Convert.ToInt32(dalBase.DataRead["grdid"]),
                        Name = dalBase.DataRead["grdname"].ToString()
                    };
                    list_GrdInfo.Add(grdInfo);
                }
                dalBase.CloseConnect();
                return true;
            } 
            else
            {
                dalBase.CloseConnect();
                return false;
            }
        }

        public bool GetGrd(int id)
        {
            dalBase.sql = "SELECT * FROM db_grade WHERE grdid=@grdid";
            dalBase.Param = new MySqlParameter("@grdid", id);
            if (dalBase.Run(Behavious.SELECT_WITH_SINGLEPARAM, false))
            {
                grdInfo = new Grade()
                {
                    ID = Convert.ToInt32(dalBase.DataRead["grdid"]),
                    Name = dalBase.DataRead["grdname"].ToString()
                };
                dalBase.CloseConnect();
                return true;
            }
            else
            {
                dalBase.CloseConnect();
                return false;
            }
        }

        public bool InsertGrd(Grade grd)
        {
            dalBase.sql = "INSERT INTO db_grade VALUES (@grdname)";
            dalBase.Param = new MySqlParameter("@grdname", grd.Name);
            return dalBase.Run(Behavious.INSERT_OR_UPDATE_OR_DELETE, true);
        }

        public bool DeleteGrd(int id)
        {
            dalBase.sql = "DELETE FROM db_grade WHERE grdid=@grdid";
            dalBase.Param = new MySqlParameter("@grdid", id);
            return dalBase.Run(Behavious.INSERT_OR_UPDATE_OR_DELETE, true);
        }

        public bool UpdateGrd(Grade grd)
        {
            dalBase.sql = "UPDATE db_grade SET grdname=@grdname WHERE grdid=@grdid";
            dalBase.List_param = new List<MySqlParameter>()
            {
                new MySqlParameter("@grdname", grd.Name),
                new MySqlParameter("@grdid", grd.ID)
            };
            return dalBase.Run(Behavious.INSERT_OR_UPDATE_OR_DELETE, true);
        }
    }
}