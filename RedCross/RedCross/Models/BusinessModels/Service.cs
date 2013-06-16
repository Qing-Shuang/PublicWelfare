using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RedCross.DAL;
using RedCross.Models.Entities.Container;
using RedCross.Models.Entities;

namespace RedCross.Models.BusinessModels
{
    public delegate List<T> m_FuncList<T>();

    public class Service<T> where T:new ()
    {
        private T m;
        private PoolUtil poolUtil;
        private List<T> list_m;

        public ResponseStatus GetMuti(HttpRequestBase req, Func<PoolUtil> m_InstanceDal, List<T> m_List, Paginate paginate)
        {
            ResponseStatus resp = ResponseStatus.NONE;
            poolUtil = m_InstanceDal();
            resp = poolUtil.GetMuti(m_List, paginate);
            if (resp == ResponseStatus.FAILED) list_m = default(List<T>);
            poolUtil.ReturnUnitToPool();
            return resp;
        }

        public ResponseStatus GetSingle(int id, Func<T> m_InstanceModel, Func<PoolUtil> m_InstanceDal)
        {
            ResponseStatus resp = ResponseStatus.NONE;
            poolUtil = m_InstanceDal();
            resp = poolUtil.GetSingle(id, m_InstanceModel());
            if (resp == ResponseStatus.FAILED) m = default(T);
            poolUtil.ReturnUnitToPool();
            return resp;
        }

        public ResponseStatus Add(HttpRequestBase req, Func<T> m_InstanceModel, Func<PoolUtil> m_InstanceDal,Action<T> m_SetValues)
        {
            ResponseStatus resp = ResponseStatus.NONE;
            m = m_InstanceModel();
            if (this.CreateInstance(req, m_SetValues,m))
            {
                poolUtil = m_InstanceDal();
                if (poolUtil.Insert(m))
                {
                    poolUtil.ReturnUnitToPool();
                    resp = ResponseStatus.SUCCESS;
                }
                else
                {
                    resp = ResponseStatus.FAILED;
                }
            } 
            else
            {
                m = default(T);
                resp = ResponseStatus.FAILED;
            }
            return resp;
        }

        public ResponseStatus Delete(HttpRequestBase req, Func<PoolUtil> m_InstanceDal)
        {
            ResponseStatus resp = ResponseStatus.NONE;
            int id;
            bool isclose = false;
            poolUtil = m_InstanceDal();
            for (int i = 0; i < req.Form.Count; ++i)
            {
                if (i == req.Form.Count - 1) isclose = true;
                if (int.TryParse(req.Form.AllKeys[i], out id))
                {
                    if (poolUtil.Delete(id, isclose))
                    {
                        resp = ResponseStatus.SUCCESS;
                    }
                    else
                    {
                        resp = ResponseStatus.FAILED;
                        break;
                    }
                }
                else
                {
                    resp = ResponseStatus.FAILED;
                    break;
                }
            }
            poolUtil.ReturnUnitToPool();
            return resp;
        }

        public ResponseStatus Delete(int id, Func<PoolUtil> m_InstanceDal)
        {
            ResponseStatus resp = ResponseStatus.NONE;
            bool isclose = true;
            poolUtil = m_InstanceDal();
            if (poolUtil.Delete(id, isclose))
            {
                resp = ResponseStatus.SUCCESS;
            }
            else
            {
                resp = ResponseStatus.FAILED;
            }
            poolUtil.ReturnUnitToPool();
            return resp;
        }

        public ResponseStatus Update(HttpRequestBase req, Func<T> m_InstanceModel, Func<PoolUtil> m_InstanceDal, Action<T> m_SetValues)
        {
            ResponseStatus resp = ResponseStatus.NONE;
            T m = m_InstanceModel();
            if (this.CreateInstance(req, m_SetValues,m))
            {
                poolUtil = m_InstanceDal();
                if (poolUtil.Update(m))
                {
                    resp = ResponseStatus.SUCCESS;
                }
                else
                {
                    resp = ResponseStatus.FAILED;
                }
            }
            else
            {
                m = default(T);
                resp = ResponseStatus.FAILED;
            }
            return resp;
        }

        private bool CreateInstance(HttpRequestBase req, Action<T> m_SetValues,T type)
        {
            bool flag = true;
            try
            {
                m_SetValues(type);
            }
            catch (System.Exception ex)
            {
                flag = false;
            }
            return flag;
        }
    }
}