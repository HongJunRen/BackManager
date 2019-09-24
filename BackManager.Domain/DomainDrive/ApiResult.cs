using Newtonsoft.Json;

namespace BackManager.Domain
{
    public enum StateEnum
    {
        Tip = 0, // 提示
        Success = 1, // 成功
        Error = 2, // 出错
        NoLogin = 3, // 没有登陆
        NoPermission = 4, // 没有权限
        Warning = 5 // 警告
    }
    /// <summary>
    /// 返回格式
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiResult<T>
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        [JsonProperty("success")]
        public bool Success { get; set; } = true;
        /// <summary>
        /// 信息
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; } = "";
        /// <summary>
        /// 状态码
        /// </summary>
        [JsonProperty("stateCode")]
        public StateEnum StateCode { get; set; } = StateEnum.Success;
        [JsonProperty("apiData")]
        public T ApiData { get; set; }

        /// <summary>
        /// 返回成功
        /// </summary>
        /// <returns></returns>
        public static ApiResult<T> Ok(T tData) =>
            ApiResult<T>.Ok(tData, "");
        /// <summary>
        /// 返回成功
        /// </summary>
        /// <returns></returns>
        public static ApiResult<T> Ok(T tData, string message = "操作成功")
        {
            ApiResult<T> result = new ApiResult<T>();
            result.ApiData = tData;
            result.Message = message;
            return result;
        }

        public static ApiResult<T> Error() => ApiResult<T>.Error("操作失败！");
        public static ApiResult<T> Error(string message) => ApiResult<T>.Error(message, StateEnum.Error);
        /// <summary>
        /// 返回失败
        /// </summary>
        /// <returns></returns>
        public static ApiResult<T> Error(string message, StateEnum stateEnum)
        {
            ApiResult<T> result = new ApiResult<T>();
            result.ApiData = default(T);
            result.Message = message;
            result.Success = false;
            result.StateCode = stateEnum;
            return result;
        }
    }
}
