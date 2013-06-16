using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MySql.Data.MySqlClient;

using RedCross.Models.Entities.Base;
using RedCross.Models.BusinessModels;
using RedCross.Models.Entities;

namespace RedCross.DAL
{
    public class FamilyDAL:PoolUtil
    {
        public FamilyDAL()
        { }

        public override ResponseStatus GetMuti(object list_obj, Paginate paginate)
        {
            if (!(list_obj is List<Family>)) return ResponseStatus.FAILED;

            List<Family> list_Family = (List<Family>)list_obj;
            dalBase.sql = string.Format("SELECT COUNT(*) FROM db_family ");
            bool isSuccess1 = dalBase.Run(Behavious.SELECT_WITHOUT_PARAM, false);
            ResponseStatus resp1, resp2;
            resp1 = this.JudgeDBResult(isSuccess1,
                ()=>
                {
                    dalBase.DataRead.Read();
                    paginate.TotalRecords = Convert.ToInt32(dalBase.DataRead[0]);

                    dalBase.sql = string.Format(
                        "SELECT id,userId,userName,sex,db_grade.grdId,grdname,db_collage.collageid,db_collage.collagename,db_department.depId,db_department.depname,wish  " +
                        "FROM db_family LEFT JOIN db_grade ON db_family.grdId=db_grade.grdid " +
                        "LEFT JOIN db_department ON db_family.depId=db_department.depid " +
                        "LEFT JOIN db_collage ON db_family.clgId=db_collage.collageid " +
                        "ORDER BY userId LIMIT {0},{1}",
                        paginate.StartRow, paginate.PageSize);

                    //list_Family = new List<Family>();
                    bool isSuccess2 = dalBase.Run(Behavious.SELECT_WITHOUT_PARAM, false);
                    resp2 =  this.JudgeDBResult(isSuccess2,
                        () =>
                        {
                            while (dalBase.DataRead.Read())
                            {
                                list_Family.Add(new Family()
                                {
                                    ID = Convert.ToInt32(dalBase.DataRead["id"]),
                                    UserID = dalBase.DataRead["userId"].ToString(),
                                    UserName = dalBase.DataRead["userName"].ToString(),
                                    Sex = Convert.ToByte(dalBase.DataRead["sex"]),
                                    Grd = dalBase.DataRead["grdId"] != DBNull.Value?
                                    new Grade() { ID = Convert.ToInt32(dalBase.DataRead["grdId"]), Name = dalBase.DataRead["grdname"].ToString() }:
                                    new Grade(),
                                    Clg = dalBase.DataRead["collageid"] != DBNull.Value ?
                                    new Collage() { ID = Convert.ToInt32(dalBase.DataRead["collageid"]), Name = dalBase.DataRead["collagename"].ToString() }:
                                    new Collage(),
                                    Dep = dalBase.DataRead["depId"] != DBNull.Value ?
                                    new Department() { ID = Convert.ToInt32(dalBase.DataRead["depId"]), Name = dalBase.DataRead["depname"].ToString() }:
                                    new Department(),
                                    Wish = dalBase.DataRead["wish"].ToString(),
                                });
                            }
                        }, null);
                    resp1 = resp2;
                },
                ()=>
                {
                     dalBase.CloseConnect();
                });
            return resp1;
        }

        public override ResponseStatus GetSingle(int id, object obj)
        {
            if(obj is Family)
            {
                Family family = (Family)obj;
                dalBase.sql = "SELECT * FROM db_family WHERE id=@id";
                dalBase.Param = new MySqlParameter("@id", id);
                bool isSuccess = dalBase.Run(Behavious.SELECT_WITH_SINGLEPARAM, false);
                return this.JudgeDBResult(isSuccess,
                    () =>
                    {
                        dalBase.DataRead.Read();
                        SetValue(family);
                    },
                    null);
            }
            else
            {
                return ResponseStatus.FAILED;
            }
        }

        private void SetValue(Family family)
        {
            family.ID = Convert.ToInt32(dalBase.DataRead["id"]);
            family.UserID = dalBase.DataRead["userId"].ToString();
            family.UserName = dalBase.DataRead["userName"].ToString();
            family.Sex = Convert.ToByte(dalBase.DataRead["sex"]);
            family.Grd = new Grade() { ID = Convert.ToInt32(dalBase.DataRead["grdId"]) };
            family.Dep = new Department() { ID = Convert.ToInt32(dalBase.DataRead["depId"]) };
            family.Clg = new Collage() { ID = Convert.ToInt32(dalBase.DataRead["clgId"]) };
            family.Wish = dalBase.DataRead["wish"].ToString();
        }

        public override bool Update(object obj)
        {
            if (!(obj is Family)) return false;

            Family family = (Family)obj;
            dalBase.sql = "UPDATE db_family SET userId=@userId,userName=@userName,sex=@sex,grdId=@grdId,depId=@depId,clgId=@clgId,wish=@wish WHERE id=@id";
            dalBase.List_param = new List<MySqlParameter>()
            {
                new MySqlParameter("@userId",family.UserID),
                new MySqlParameter("@userName",family.UserName),
                new MySqlParameter("@sex",family.Sex),
                new MySqlParameter("@grdId",family.Grd.ID),
                new MySqlParameter("@depId",family.Dep.ID),
                new MySqlParameter("@clgId",family.Clg.ID),
                new MySqlParameter("@wish",family.Wish),
                new MySqlParameter("@id",family.ID)
            };
            return dalBase.Run(Behavious.INSERT_OR_UPDATE_OR_DELETE, true);
        }

        public override bool Delete(int id, bool isclose)
        {
            dalBase.sql = "DELETE FROM db_family WHERE id = @id";
            dalBase.Param = new MySqlParameter("@id", id);
            return dalBase.Run(Behavious.DELETE_SINGLE, isclose);
        }

        public override bool Insert(object obj)
        {
            if (!(obj is Family)) return false;
            Family family = (Family)obj;

            dalBase.sql = "INSERT INTO db_family (userId,userName,sex,grdId,depId,clgId,wish) VALUES (@userId,@userName,@sex,@grdId,@depId,@clgId,@wish)";
            dalBase.List_param = new List<MySqlParameter>()
            {
                new MySqlParameter("@userId",family.UserID),
                new MySqlParameter("@userName",family.UserName),
                new MySqlParameter("@sex",family.Sex),
                new MySqlParameter("@grdId",family.Grd.ID),
                new MySqlParameter("@depId",family.Dep.ID),
                new MySqlParameter("@clgId",family.Clg.ID),
                new MySqlParameter("@wish",family.Wish)
            };
            return dalBase.Run(Behavious.INSERT_OR_UPDATE_OR_DELETE, true);
        }
    }
}