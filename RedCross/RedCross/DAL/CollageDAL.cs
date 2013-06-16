using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MySql.Data.MySqlClient;

using RedCross.Models.Entities;

namespace RedCross.DAL
{
    public class CollageDAL:PoolUtil
    {
        public List<Collage> list_CollageInfo;
        public Collage collageInfo = null;

        public CollageDAL()
        {
            list_CollageInfo = new List<Collage>();
        }

        public bool GetColgs()
        {
            dalBase.sql = "SELECT * FROM db_collage";
            if (dalBase.Run(Behavious.SELECT_WITHOUT_PARAM, false))
            {
                while (dalBase.DataRead.Read())
                {
                    collageInfo = new Collage()
                    {
                        ID = Convert.ToInt32(dalBase.DataRead["collageid"]),
                        Name = dalBase.DataRead["collagename"].ToString()
                    };
                    list_CollageInfo.Add(collageInfo);
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

        public bool GetColg(int id)
        {
            dalBase.sql = "SELECT * FROM db_collage WHERE collageid=@collageid";
            dalBase.Param = new MySqlParameter("@collageid", id);
            if (dalBase.Run(Behavious.SELECT_WITH_SINGLEPARAM, false))
            {
                collageInfo = new Collage()
                {
                    ID = Convert.ToInt32(dalBase.DataRead["collageid"]),
                    Name = dalBase.DataRead["collagename"].ToString()
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

        public bool InsertColg(Collage colg)
        {
            dalBase.sql = "INSERT INTO db_collage VALUES (@collagename)";
            dalBase.Param = new MySqlParameter("@collagename", colg.Name);
            return dalBase.Run(Behavious.INSERT_OR_UPDATE_OR_DELETE, true);
        }

        public bool UpdateColg(Collage colg)
        {
            dalBase.sql = "UPDATE db_collage SET collagename=@collagename WHERE collageid=@collageid";
            dalBase.List_param = new List<MySqlParameter>()
            {
                new MySqlParameter("@collagename", colg.Name),
                new MySqlParameter("@collageid", colg.ID)
            };
            return dalBase.Run(Behavious.INSERT_OR_UPDATE_OR_DELETE, true);
        }

        public bool DeleteColg(Collage colg)
        {
            dalBase.sql = "DELETE FROM db_collage WHERE collageid=@collageid";
            dalBase.Param = new MySqlParameter("@collageid", colg.ID);
            return dalBase.Run(Behavious.INSERT_OR_UPDATE_OR_DELETE, true);
        }
    }
}