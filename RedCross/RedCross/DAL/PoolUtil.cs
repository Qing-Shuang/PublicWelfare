using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RedCross.Models.BusinessModels;
using RedCross.Controllers;
using RedCross.Models.Entities;

namespace RedCross.DAL
{
    public delegate void DoDBSuccess();
    public delegate void DoDBFailed();

    public class PoolUtil
    {
        protected BaseDAL dalBase;
        private PoolUnit unit;

        public PoolUtil()
        {
            unit = BaseDALPool.Instance().GetValidDal();
            if (unit != null)
            {
                dalBase = unit.baseDal;
            } 
            else
            {
                //这里应该要有忙碌的处理
            }
        }

        protected ResponseStatus JudgeDBResult(bool isSuccess, DoDBSuccess dosuccess,DoDBFailed dofailed)
        {
            if (dalBase == null) return ResponseStatus.NONE;

            if (isSuccess)
            {
                if (dalBase.DataRead.HasRows)
                {
                    if (dosuccess != null) dosuccess();
                    dalBase.CloseConnect();
                    return ResponseStatus.SUCCESS;
                } 
                else
                {
                    dalBase.CloseConnect();
                    return ResponseStatus.NOT_DATA;
                }
            } 
            else
            {
                if (dofailed != null) dofailed();
                dalBase.CloseConnect();
                return ResponseStatus.FAILED;
            }
        }

        public virtual bool Insert(object obj)
        {
            return false;
        }

        public virtual bool Delete(int id,bool isclose)
        {
            return false;
        }

        public virtual bool Update(object obj)
        {
            return false;
        }

        public virtual ResponseStatus GetMuti(object list_obj, Paginate paginate)
        {
            return ResponseStatus.NONE;
        }

        public virtual ResponseStatus GetSingle(int id, object obj)
        {
            return ResponseStatus.NONE;
        }

        public void ReturnUnitToPool()
        {
            unit.IsUse = false;
            dalBase.sql = "";
            dalBase.Param = null;
            if (dalBase.List_param != null && dalBase.List_param.Count > 0) dalBase.List_param.Clear();
            dalBase.CloseConnect();
        }
    }
}