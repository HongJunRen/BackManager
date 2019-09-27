using System;
using System.Collections.Generic;
using System.Text;

namespace BackManager.Utility
{
    /// <summary>
    /// 自定义异常
    /// </summary>
    [Serializable]
    public class CustomException : Exception
    {

        public CustomException()
        {
        }

        public CustomException(string message) : base(message)
        {
        }

        public CustomException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
