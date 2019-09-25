using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Linq;

namespace BackManager.Utility
{
    /// <summary>
    /// 
    /// </summary>
    public static class MyEnumExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Dictionary<int, string> GetKeyValues<T>()
        {
            Dictionary<int, string> dic = new Dictionary<int, string>();
            int index = 0;
            foreach (FieldInfo fieldInfo in typeof(T).GetFields())
            {
                if (index > 0)
                {
                    DescriptionAttribute descriptionAttribute = (DescriptionAttribute)fieldInfo.GetCustomAttribute(typeof(System.ComponentModel.DescriptionAttribute));
                    var value = fieldInfo.GetValue(null);
                    if (descriptionAttribute != null)
                    {
                        dic.Add(Convert.ToInt32(value), descriptionAttribute.Description);
                    }
                }
                index++;
            }
            return dic;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static dynamic GetKeyValueList<T>() =>
            MyEnumExtension.GetKeyValues<T>().ToList();

        /// <summary>
        /// 获取枚举类型的描述
        /// </summary>
        /// <param name="enumeration"></param>
        /// <returns></returns>
        public static string ToDescription(this Enum enumeration)
        {
            Type type = enumeration.GetType();
            MemberInfo[] memInfo = type.GetMember(enumeration.ToString());
            if (null != memInfo && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (null != attrs && attrs.Length > 0)
                    return ((DescriptionAttribute)attrs[0]).Description;
            }
            return enumeration.ToString();
        }

        /// <summary>
        /// Int to Enum
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T ToEnum<T>(this int value)
        {
            return (T)Enum.ToObject(typeof(T), value);
        }
        /// <summary>
        /// string to  enum
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T ToEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }

    }
}
