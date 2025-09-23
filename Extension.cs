using System;
using System.Text;

namespace MyExtension
{
    public static class Exclass
    {
        #region 확장 메서드 강의 1
        /// <summary>
        /// 대문자 => 소문자 / 소문자 => 대문자
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToChangeCase(this String str)
        {
            var sb = new StringBuilder();
            foreach (var ch in str)
            {
                if (ch >= 'A' && ch <= 'Z')
                    sb.Append((char)('a' + ch - 'A'));
                else if (ch >= 'a' && ch <= 'z')
                    sb.Append((char)('A' + ch - 'a'));
                else
                    sb.Append(ch);

            }
            return sb.ToString();
        }

        /// <summary>
        /// 이 char가 str 안에 있는지 판단
        /// </summary>
        /// <param name="str"></param>
        /// <param name="ch"></param>
        /// <returns></returns>
        public static bool Found(this String str, char ch)
        {
            int position = str.IndexOf(ch);
            return position >= 0;
        }

        /// <summary>
        /// char를 string으로 Replace하게 할 수 있는 string의 확장 메서드
        /// </summary>
        /// <param name="str"></param>
        /// <param name="ch"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Replace(this String str, char ch, string value)
        {
            return str.Replace(ch.ToString(), value);
        }
        #endregion
    }
}