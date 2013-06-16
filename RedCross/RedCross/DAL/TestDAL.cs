using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.Diagnostics;

namespace RedCross.DAL
{
    public class TestDAL : PoolUtil
    {
        private BaseDAL dalBase1 = new BaseDAL();
        private BaseDAL dalBase2 = new BaseDAL();

        public void Test()
        {

            new Thread(() =>
            {
                Thread.CurrentThread.Name = "";

                for (int i = 0; i < 100000; ++i)
                {
                    dalBase.sql = "SELECT * FROM db_users";
                    dalBase.Run(Behavious.SELECT_WITHOUT_PARAM, false);
                    Trace.WriteLine("###dalBase : " + i);
                }
            }
            ).Start();
            

            /*
            new Thread(() =>
            {
                Thread.CurrentThread.Name = "openClose";

                for (int i = 0; i < 100000; ++i)
                {
                    dalBase2.sql = "SELECT * FROM db_users";
                    dalBase2.Run(Behavious.SELECT_WITHOUT_PARAM, true);
                    Trace.WriteLine("###dalBase2 : " + i);
                }
            }
            ).Start();
            */


        }

//         public void Test2()
//         {
//             BaseDALPool pool = new BaseDALPool();
//             for (int i = 0; i < GLB.dalPoolCount; ++i)
//             {
//                 pool.poolUnits.Add(
//                     new PoolUnit()
//                     {
//                         baseDal = new BaseDAL(),
//                         IsUse = true
//                     });
//             }
// 
//             PoolUnit unit = pool.GetValidDal();
//         }
    }
}