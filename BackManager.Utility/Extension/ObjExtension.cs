using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackManager.Utility
{
    /// <summary>
    /// Object 扩展方法
    /// </summary>
    public static class ObjExtension
    {

        /// <summary>
        /// 验证是否为空
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="exceptionMsg"></param>
        public static void CheckNotNull<T>(this T obj, string exceptionMsg = "入参不能为空") where T : class
        {
            if (obj == null)
            {
                throw new CustomException(exceptionMsg);
            }
        }


        /// <summary>
        /// 验证string是否为空,若为空,则抛出异常
        /// </summary>
        /// <param name="str"></param>
        /// <param name="exceptionMsg"></param>
        public static void CheckNotEmpty(this string str, string exceptionMsg = "入参不能为空")
        {
            if (str == null || string.IsNullOrWhiteSpace(str.Trim()) == true)
            {
                throw new CustomException(exceptionMsg);
            }
        }


        /// <summary>
        /// 判断string是否为空
        /// </summary>
        /// <param name="str"></param>
        public static bool IsEmpty(this string str)
        {
            return str == null || string.IsNullOrWhiteSpace(str.Trim()) == true;
        }


        /// <summary>
        /// 验证数据源是否有值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">数据源</param>
        /// <returns>true:有值;false:没有值</returns>
        public static bool CheckNotEmpty<T>(this IEnumerable<T> source)
        {
            return source != null && source.Any();
        }


        /// <summary>
        /// 数据库字符串拼接 where 条件
        /// </summary>
        /// <param name="str"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static string If(this string str, bool condition)
        {
            return condition ? str : string.Empty;
        }
    }
}
