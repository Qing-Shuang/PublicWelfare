using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;

namespace RedCross.DAL
{
    public class PoolUnit
    {
        public BaseDAL baseDal{get;set;}
        public bool IsUse{get;set;}
    }

    public class BaseDALPool
    {
        private static BaseDALPool baseDalPool;
        private List<PoolUnit> poolUnits;
        private object threadLock;

        private BaseDALPool()
        {
            threadLock = new object();
            poolUnits = new List<PoolUnit>();
            poolUnits.Capacity = GLB.dalPoolCount;
            for (int i = 0; i < GLB.dalPoolCount; ++i)
            {
                poolUnits.Add(
                    new PoolUnit()
                    {
                        baseDal = new BaseDAL(),
                        IsUse = false
                    });
            }
        }

        public static BaseDALPool Instance()
        {
            if (baseDalPool ==null)
            {
                baseDalPool = new BaseDALPool();
            }
            return baseDalPool;
        }

        public PoolUnit GetValidDal()
        {
            lock(threadLock)
            {
                PoolUnit unit = null;
                for (int i = 0; i < GLB.attemptTime; ++i)
                {
                    unit = poolUnits.Find((u) => u.IsUse == false);
                    if (unit != null) break;
                    Thread.Sleep(100);
                }
                return unit;
            }
        }
    }
}