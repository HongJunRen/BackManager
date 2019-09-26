using System.Security.Cryptography;
using System.Text;

namespace BackManager.Utility
{
    /// <summary>
    /// 字符串加密扩展
    /// </summary>
    public static class StringEncrypt
    {
        /// <summary>
        /// 计算当前字符串的SHA256散列值
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToSHA256Encoding(this string value)
        {
            if (string.IsNullOrEmpty(value)) return null;
            SHA256 _sha256 = SHA256.Create();
            StringBuilder _builder = new StringBuilder();
            byte[] _cipherByte = _sha256.ComputeHash(Encoding.UTF8.GetBytes(value));
            foreach (var _byte in _cipherByte)
            {
                _builder.Append(_byte.ToString("x2"));
            }
            return _builder.ToString();
        }

        /// <summary>
        /// 计算当前字符串的MD5散列值
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToMD5Encoding(this string value)
        {
            if (string.IsNullOrEmpty(value)) return null;
            MD5 _md5 = MD5.Create();
            StringBuilder _builder = new StringBuilder();
            byte[] _cipherByte = _md5.ComputeHash(Encoding.UTF8.GetBytes(value));
            foreach (var _byte in _cipherByte)
            {
                _builder.Append(_byte.ToString("x2"));
            }
            return _builder.ToString();
        }
    }
}



















