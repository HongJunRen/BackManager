using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackManager.Utility
{
    /// <summary>
    /// AutoMapper帮助类
    /// </summary>
    public static class AutoMapperHelper
    {
        /// <summary>
        ///  单个对象映射
        /// </summary>
        public static T MapTo<T>(this object source)
        {
            if (source == null) return default(T);
            var config = new MapperConfiguration(cfg => cfg.CreateMap(source.GetType(), typeof(T)));
            var mapper = config.CreateMapper();
            return mapper.Map<T>(source);
        }


        /// <summary>
        /// 集合列表类型映射
        /// </summary>
        public static List<TDestination> MapToList<TSource, TDestination>(this IEnumerable<TSource> source)
        {
            if (source == null) return new List<TDestination>();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<IEnumerable<TSource>, List<TDestination>>());
            var mapper = config.CreateMapper();
            return mapper.Map<List<TDestination>>(source);
        }

    }

}
