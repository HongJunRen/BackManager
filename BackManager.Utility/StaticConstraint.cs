using System;

namespace BackManager.Utility
{
    public class StaticConstraint
    {
        public static void Init(Func<string, string> func)
        {
            MySqlConnectionString = func.Invoke("ConnectionStrings:MySqlConnectionString");
            //循环--反射的方式初始化多个
        }


        /// <summary>
        /// 以前直接读配置文件
        /// ConnectionStrings:JDDbConnectionString
        /// </summary>
        public static string MySqlConnectionString = null;

    }
}
