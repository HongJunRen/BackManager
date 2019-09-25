using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace BackManager.Utility
{
    public static class SqlDataReaderExtend
    {
        /// <summary>  
        /// DataReader转换为obj list  
        /// </summary>  
        /// <typeparam name="T">泛型</typeparam>  
        /// <param name="rdr">datareader</param>  
        /// <returns>返回泛型类型</returns>  
        public static IList<T> ToList<T>(this DbDataReader rdr)
        {
            IList<T> list = new List<T>();

            while (rdr.Read())
            {
                T t = System.Activator.CreateInstance<T>();
                Type obj = t.GetType();
                // 循环字段  
                for (int i = 0; i < rdr.FieldCount; i++)
                {
                    object tempValue = null;

                    if (rdr.IsDBNull(i))
                    {

                        string typeFullName = obj.GetProperty(rdr.GetName(i)).PropertyType.FullName;
                        tempValue = GetDBNullValue(typeFullName);

                    }
                    else
                    {
                        tempValue = rdr.GetValue(i);

                    }

                    obj.GetProperty(rdr.GetName(i)).SetValue(t, tempValue, null);

                }

                list.Add(t);

            }
            return list;
        }

        /// <summary>  
        /// DataReader转换为obj  
        /// </summary>  
        /// <typeparam name="T">泛型</typeparam>  
        /// <param name="rdr">datareader</param>  
        /// <returns>返回泛型类型</returns>  
        public static object ToObj<T>(this DbDataReader rdr)
        {
            T t = System.Activator.CreateInstance<T>();
            Type obj = t.GetType();

            if (rdr.Read())
            {
                // 循环字段  
                for (int i = 0; i < rdr.FieldCount; i++)
                {
                    object tempValue = null;

                    if (rdr.IsDBNull(i))
                    {

                        string typeFullName = obj.GetProperty(rdr.GetName(i)).PropertyType.FullName;
                        tempValue = GetDBNullValue(typeFullName);

                    }
                    else
                    {
                        tempValue = rdr.GetValue(i);

                    }

                    obj.GetProperty(rdr.GetName(i)).SetValue(t, tempValue, null);

                }
                return t;
            }
            else
                return null;

        }


        /// <summary>  
        /// 返回值为DBnull的默认值  
        /// </summary>  
        /// <param name="typeFullName">数据类型的全称，类如：system.int32</param>  
        /// <returns>返回的默认值</returns>  
        private static object GetDBNullValue(string typeFullName)
        {

            typeFullName = typeFullName.ToLower();

            if (typeFullName == typeof(string).Name)
            {
                return String.Empty;
            }
            if (typeFullName == typeof(int).Name)
            {
                return 0;
            }
            if (typeFullName == typeof(DateTime).Name)
            {
                return DateTime.MinValue;
            }
            if (typeFullName == typeof(bool).Name)
            {
                return false;
            }

            return null;
        }

    }
}
