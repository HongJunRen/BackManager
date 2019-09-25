using System;

namespace BackManager.Utility
{
    public enum DbType
    {
        None = -1,
        SqlServer = 1,
        MySql = 2
    }
    public class StaticConstraint
    {

        public static void Init(Func<string, string> func)
        {
            dbType = func.Invoke("ConnectionStrings:DbType").ToEnum<DbType>();
        }

        public static DbType dbType = DbType.None;

    }
}
