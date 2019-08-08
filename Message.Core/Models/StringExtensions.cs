﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Message.Core.Models
{
    public static class StringExtensions
    {
        #region 正则表达式

        /// <summary>
        /// 指示所指定的正则表达式在指定的输入字符串中是否找到了匹配项
        /// </summary>
        /// <param name="value">要搜索匹配项的字符串</param>
        /// <param name="pattern">要匹配的正则表达式模式</param>
        /// <param name="isContains">是否包含，否则全匹配</param>
        /// <returns>如果正则表达式找到匹配项，则为 true；否则，为 false</returns>
        public static bool IsMatch(this string value, string pattern, bool isContains = true)
        {
            if (value == null)
            {
                return false;
            }
            return isContains
                ? Regex.IsMatch(value, pattern)
                : Regex.Match(value, pattern).Success;
        }

        /// <summary>
        /// 在指定的输入字符串中搜索指定的正则表达式的第一个匹配项
        /// </summary>
        /// <param name="value">要搜索匹配项的字符串</param>
        /// <param name="pattern">要匹配的正则表达式模式</param>
        /// <returns>一个对象，包含有关匹配项的信息</returns>
        public static string Match(this string value, string pattern)
        {
            if (value == null)
            {
                return null;
            }
            return Regex.Match(value, pattern).Value;
        }

        /// <summary>
        /// 在指定的输入字符串中搜索指定的正则表达式的所有匹配项的字符串集合
        /// </summary>
        /// <param name="value"> 要搜索匹配项的字符串 </param>
        /// <param name="pattern"> 要匹配的正则表达式模式 </param>
        /// <returns> 一个集合，包含有关匹配项的字符串值 </returns>
        public static IEnumerable<string> Matches(this string value, string pattern)
        {
            if (value == null)
            {
                return new string[] { };
            }
            MatchCollection matches = Regex.Matches(value, pattern);
            return from Match match in matches select match.Value;
        }

        /// <summary>
        /// 在指定的输入字符串中匹配第一个数字字符串
        /// </summary>
        public static string MatchFirstNumber(this string value)
        {
            MatchCollection matches = Regex.Matches(value, @"\d+");
            if (matches.Count == 0)
            {
                return string.Empty;
            }
            return matches[0].Value;
        }

        /// <summary>
        /// 在指定字符串中匹配最后一个数字字符串
        /// </summary>
        public static string MatchLastNumber(this string value)
        {
            MatchCollection matches = Regex.Matches(value, @"\d+");
            if (matches.Count == 0)
            {
                return string.Empty;
            }
            return matches[matches.Count - 1].Value;
        }

        /// <summary>
        /// 在指定字符串中匹配所有数字字符串
        /// </summary>
        public static IEnumerable<string> MatchNumbers(this string value)
        {
            return Matches(value, @"\d+");
        }

        /// <summary>
        /// 检测指定字符串中是否包含数字
        /// </summary>
        public static bool IsMatchNumber(this string value)
        {
            return IsMatch(value, @"\d");
        }

        /// <summary>
        /// 检测指定字符串是否全部为数字并且长度等于指定长度
        /// </summary>
        public static bool IsMatchNumber(this string value, int length)
        {
            Regex regex = new Regex(@"^\d{" + length + "}$");
            return regex.IsMatch(value);
        }


        /// <summary>
        /// 用正则表达式截取字符串
        /// </summary>
        public static string Substring2(this string source, string startString, string endString)
        {
            return source.Substring2(startString, endString, false);
        }

        /// <summary>
        /// 用正则表达式截取字符串
        /// </summary>
        public static string Substring2(this string source, string startString, string endString, bool containsEmpty)
        {
            if (source.IsMissing())
            {
                return string.Empty;
            }
            string inner = containsEmpty ? "\\s\\S" : "\\S";
            string result = source.Match(string.Format("(?<={0})([{1}]+?)(?={2})", startString, inner, endString));
            return result.IsMissing() ? null : result;
        }

        /// <summary>
        /// 是否电子邮件
        /// </summary>
        public static bool IsEmail(this string value)
        {
            const string pattern = @"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$";
            return value.IsMatch(pattern);
        }

        /// <summary>
        /// 是否是IP地址
        /// </summary>
        public static bool IsIpAddress(this string value)
        {
            const string pattern = @"^((?:(?:25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d)))\.){3}(?:25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d))))$";
            return value.IsMatch(pattern);
        }

        /// <summary>
        /// 是否是整数
        /// </summary>
        public static bool IsNumeric(this string value)
        {
            const string pattern = @"^\-?[0-9]+$";
            return value.IsMatch(pattern);
        }

        /// <summary>
        /// 是否是Unicode字符串
        /// </summary>
        public static bool IsUnicode(this string value)
        {
            const string pattern = @"^[\u4E00-\u9FA5\uE815-\uFA29]+$";
            return value.IsMatch(pattern);
        }

        /// <summary>
        /// 是否Url字符串
        /// </summary>
        public static bool IsUrl(this string value)
        {
            try
            {
                if (value.IsNullOrEmpty() || value.Contains(' '))
                {
                    return false;
                }
                Uri uri = new Uri(value);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 是否身份证号，验证如下3种情况：
        /// 1.身份证号码为15位数字；
        /// 2.身份证号码为18位数字；
        /// 3.身份证号码为17位数字+1个字母
        /// </summary>
        public static bool IsIdentityCardId(this string value)
        {
            if (value.Length != 15 && value.Length != 18)
            {
                return false;
            }
            Regex regex;
            string[] array;
            DateTime time;
            if (value.Length == 15)
            {
                regex = new Regex(@"^(\d{6})(\d{2})(\d{2})(\d{2})(\d{3})_");
                if (!regex.Match(value).Success)
                {
                    return false;
                }
                array = regex.Split(value);
                return DateTime.TryParse(string.Format("{0}-{1}-{2}", "19" + array[2], array[3], array[4]), out time);
            }
            regex = new Regex(@"^(\d{6})(\d{4})(\d{2})(\d{2})(\d{3})([0-9Xx])$");
            if (!regex.Match(value).Success)
            {
                return false;
            }
            array = regex.Split(value);
            if (!DateTime.TryParse(string.Format("{0}-{1}-{2}", array[2], array[3], array[4]), out time))
            {
                return false;
            }
            //校验最后一位
            string[] chars = value.ToCharArray().Select(m => m.ToString()).ToArray();
            int[] weights = { 7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2 };
            int sum = 0;
            for (int i = 0; i < 17; i++)
            {
                int num = int.Parse(chars[i]);
                sum = sum + num * weights[i];
            }
            int mod = sum % 11;
            string vCode = "10X98765432";//检验码字符串
            string last = vCode.ToCharArray().ElementAt(mod).ToString();
            return chars.Last().ToUpper() == last;
        }

        /// <summary>
        /// 是否手机号码
        /// </summary>
        /// <param name="value"></param>
        /// <param name="isRestrict">是否按严格格式验证</param>
        public static bool IsMobileNumber(this string value, bool isRestrict = false)
        {
            string pattern = isRestrict ? @"^[1][3-8]\d{9}$" : @"^[1]\d{10}$";
            return value.IsMatch(pattern);
        }

        #endregion

        #region 其他操作

        /// <summary>
        /// 指示指定的字符串是 null 或者 System.String.Empty 字符串
        /// </summary>
        [DebuggerStepThrough]
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        /// <summary>
        /// 指示指定的字符串是 null、空或者仅由空白字符组成。
        /// </summary>
        [DebuggerStepThrough]
        public static bool IsNullOrWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        /// 指示指定的字符串是 null、空或者仅由空白字符组成。
        /// </summary>
        [DebuggerStepThrough]
        public static bool IsMissing(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }


        /// <summary>
        /// 单词变成单数形式
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static string ToSingular(this string word)
        {
            Regex plural1 = new Regex("(?<keep>[^aeiou])ies$");
            Regex plural2 = new Regex("(?<keep>[aeiou]y)s$");
            Regex plural3 = new Regex("(?<keep>[sxzh])es$");
            Regex plural4 = new Regex("(?<keep>[^sxzhyu])s$");

            if (plural1.IsMatch(word))
            {
                return plural1.Replace(word, "${keep}y");
            }
            if (plural2.IsMatch(word))
            {
                return plural2.Replace(word, "${keep}");
            }
            if (plural3.IsMatch(word))
            {
                return plural3.Replace(word, "${keep}");
            }
            if (plural4.IsMatch(word))
            {
                return plural4.Replace(word, "${keep}");
            }

            return word;
        }

        /// <summary>
        /// 单词变成复数形式
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static string ToPlural(this string word)
        {
            Regex plural1 = new Regex("(?<keep>[^aeiou])y$");
            Regex plural2 = new Regex("(?<keep>[aeiou]y)$");
            Regex plural3 = new Regex("(?<keep>[sxzh])$");
            Regex plural4 = new Regex("(?<keep>[^sxzhy])$");

            if (plural1.IsMatch(word))
            {
                return plural1.Replace(word, "${keep}ies");
            }
            if (plural2.IsMatch(word))
            {
                return plural2.Replace(word, "${keep}s");
            }
            if (plural3.IsMatch(word))
            {
                return plural3.Replace(word, "${keep}es");
            }
            if (plural4.IsMatch(word))
            {
                return plural4.Replace(word, "${keep}s");
            }

            return word;
        }

        /// <summary>
        /// 判断指定路径是否图片文件
        /// </summary>
        public static bool IsImageFile(this string filename)
        {
            if (!File.Exists(filename))
            {
                return false;
            }
            byte[] filedata = File.ReadAllBytes(filename);
            if (filedata.Length == 0)
            {
                return false;
            }
            ushort code = BitConverter.ToUInt16(filedata, 0);
            switch (code)
            {
                case 0x4D42: //bmp
                case 0xD8FF: //jpg
                case 0x4947: //gif
                case 0x5089: //png
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// 以指定字符串作为分隔符将指定字符串分隔成数组
        /// </summary>
        /// <param name="value">要分割的字符串</param>
        /// <param name="strSplit">字符串类型的分隔符</param>
        /// <param name="removeEmptyEntries">是否移除数据中元素为空字符串的项</param>
        /// <returns>分割后的数据</returns>
        public static string[] Split(this string value, string strSplit, bool removeEmptyEntries = false)
        {
            return value.Split(new[] { strSplit }, removeEmptyEntries ? StringSplitOptions.RemoveEmptyEntries : StringSplitOptions.None);
        }



        /// <summary>
        /// 支持汉字的字符串长度，汉字长度计为2
        /// </summary>
        /// <param name="value">参数字符串</param>
        /// <returns>当前字符串的长度，汉字长度为2</returns>
        public static int TextLength(this string value)
        {
            ASCIIEncoding ascii = new ASCIIEncoding();
            int tempLen = 0;
            byte[] bytes = ascii.GetBytes(value);
            foreach (byte b in bytes)
            {
                if (b == 63)
                {
                    tempLen += 2;
                }
                else
                {
                    tempLen += 1;
                }
            }
            return tempLen;
        }

        /// <summary>
        /// 给URL添加查询参数
        /// </summary>
        /// <param name="url">URL字符串</param>
        /// <param name="queries">要添加的参数，形如："id=1,cid=2"</param>
        /// <returns></returns>
        public static string AddUrlQuery(this string url, params string[] queries)
        {
            foreach (string query in queries)
            {
                if (!url.Contains("?"))
                {
                    url += "?";
                }
                else if (!url.EndsWith("&"))
                {
                    url += "&";
                }

                url = url + query;
            }
            return url;
        }

        /// <summary>
        /// 获取URL中指定参数的值，不存在返回空字符串
        /// </summary>
        public static string GetUrlQuery(this string url, string key)
        {
            Uri uri = new Uri(url);
            string query = uri.Query;
            if (query.IsNullOrEmpty())
            {
                return string.Empty;
            }
            query = query.TrimStart('?');
            var dict = (from m in query.Split("&", true)
                        let strs = m.Split("=")
                        select new KeyValuePair<string, string>(strs[0], strs[1]))
                .ToDictionary(m => m.Key, m => m.Value);
            if (dict.ContainsKey(key))
            {
                return dict[key];
            }
            return string.Empty;
        }

        /// <summary>
        /// 给URL添加 # 参数
        /// </summary>
        /// <param name="url">URL字符串</param>
        /// <param name="query">要添加的参数</param>
        /// <returns></returns>
        public static string AddHashFragment(this string url, string query)
        {
            if (!url.Contains("#"))
            {
                url += "#";
            }

            return url + query;
        }

        /// <summary>
        /// 将字符串转换为<see cref="byte"/>[]数组，默认编码为<see cref="Encoding.UTF8"/>
        /// </summary>
        public static byte[] ToBytes(this string value, Encoding encoding = null)
        {
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }
            return encoding.GetBytes(value);
        }

        /// <summary>
        /// 将<see cref="byte"/>[]数组转换为字符串，默认编码为<see cref="Encoding.UTF8"/>
        /// </summary>
        public static string ToString2(this byte[] bytes, Encoding encoding = null)
        {
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }
            return encoding.GetString(bytes);
        }

        /// <summary>
        /// 将<see cref="byte"/>[]数组转换为Base64字符串
        /// </summary>
        public static string ToBase64String(this byte[] bytes)
        {
            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// 将字符串转换为Base64字符串，默认编码为<see cref="Encoding.UTF8"/>
        /// </summary>
        /// <param name="source">正常的字符串</param>
        /// <param name="encoding">编码</param>
        /// <returns>Base64字符串</returns>
        public static string ToBase64String(this string source, Encoding encoding = null)
        {
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }
            return Convert.ToBase64String(encoding.GetBytes(source));
        }

        /// <summary>
        /// 将Base64字符串转换为正常字符串，默认编码为<see cref="Encoding.UTF8"/>
        /// </summary>
        /// <param name="base64String">Base64字符串</param>
        /// <param name="encoding">编码</param>
        /// <returns>正常字符串</returns>
        public static string FromBase64String(this string base64String, Encoding encoding = null)
        {
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }
            byte[] bytes = Convert.FromBase64String(base64String);
            return encoding.GetString(bytes);
        }

        /// <summary>
        /// 将字符串转换为十六进制字符串，默认编码为<see cref="Encoding.UTF8"/>
        /// </summary>
        public static string ToHexString(this string source, Encoding encoding = null)
        {
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }
            byte[] bytes = encoding.GetBytes(source);
            return bytes.ToHexString();
        }

        /// <summary>
        /// 将十六进制字符串转换为常规字符串，默认编码为<see cref="Encoding.UTF8"/>
        /// </summary>
        public static string FromHexString(this string hexString, Encoding encoding = null)
        {
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }
            byte[] bytes = hexString.ToHexBytes();
            return encoding.GetString(bytes);
        }

        /// <summary>
        /// 将byte[]编码为十六进制字符串
        /// </summary>
        /// <param name="bytes">byte[]数组</param>
        /// <returns>十六进制字符串</returns>
        public static string ToHexString(this byte[] bytes)
        {
            return bytes.Aggregate(string.Empty, (current, t) => current + t.ToString("X2"));
        }

        /// <summary>
        /// 将十六进制字符串转换为byte[]
        /// </summary>
        /// <param name="hexString">十六进制字符串</param>
        /// <returns>byte[]数组</returns>
        public static byte[] ToHexBytes(this string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if (hexString.Length % 2 != 0)
            {
                hexString = hexString ?? "";
            }
            byte[] bytes = new byte[hexString.Length / 2];
            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }
            return bytes;
        }

        /// <summary>
        /// 将字符串进行Unicode编码，变成形如“\u7f16\u7801”的形式
        /// </summary>
        /// <param name="source">要进行编号的字符串</param>
        public static string ToUnicodeString(this string source)
        {
            Regex regex = new Regex(@"[^\u0000-\u00ff]");
            return regex.Replace(source, m => string.Format(@"\u{0:x4}", (short)m.Value[0]));
        }

        /// <summary>
        /// 将形如“\u7f16\u7801”的Unicode字符串解码
        /// </summary>
        public static string FromUnicodeString(this string source)
        {
            Regex regex = new Regex(@"\\u([0-9a-fA-F]{4})", RegexOptions.Compiled);
            return regex.Replace(source,
                m =>
                {
                    short s;
                    if (short.TryParse(m.Groups[1].Value, NumberStyles.HexNumber, CultureInfo.InstalledUICulture, out s))
                    {
                        return "" + (char)s;
                    }
                    return m.Value;
                });
        }



        /// <summary>
        /// 将驼峰字符串的第一个字符小写
        /// </summary>
        public static string LowerFirstChar(this string str)
        {
            if (string.IsNullOrEmpty(str) || !char.IsUpper(str[0]))
            {
                return str;
            }
            if (str.Length == 1)
            {
                return char.ToLower(str[0]).ToString();
            }
            return char.ToLower(str[0]) + str.Substring(1, str.Length - 1);
        }

        /// <summary>
        /// 将小驼峰字符串的第一个字符大写
        /// </summary>
        public static string UpperFirstChar(this string str)
        {
            if (string.IsNullOrEmpty(str) || !char.IsLower(str[0]))
            {
                return str;
            }
            if (str.Length == 1)
            {
                return char.ToUpper(str[0]).ToString();
            }
            return char.ToUpper(str[0]) + str.Substring(1, str.Length - 1);
        }

        /// <summary>
        /// 计算当前字符串与指定字符串的编辑距离(相似度)
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <param name="target">目标字符串</param>
        /// <param name="similarity">输出相似度</param>
        /// <param name="ignoreCase">是否忽略大小写</param>
        /// <returns>编辑距离</returns>
        public static int LevenshteinDistance(this string source, string target, out double similarity, bool ignoreCase = false)
        {
            if (string.IsNullOrEmpty(source))
            {
                if (string.IsNullOrEmpty(target))
                {
                    similarity = 1;
                    return 0;
                }
                similarity = 0;
                return target.Length;
            }
            if (string.IsNullOrEmpty(target))
            {
                similarity = 0;
                return source.Length;
            }

            string from, to;
            if (ignoreCase)
            {
                from = source;
                to = target;
            }
            else
            {
                from = source.ToLower();
                to = source.ToLower();
            }

            int m = from.Length, n = to.Length;
            int[,] mn = new int[m + 1, n + 1];
            for (int i = 0; i <= m; i++)
            {
                mn[i, 0] = i;
            }
            for (int j = 1; j <= n; j++)
            {
                mn[0, j] = j;
            }
            for (int i = 1; i <= m; i++)
            {
                char c = from[i - 1];
                for (int j = 1; j <= n; j++)
                {
                    if (c == to[j - 1])
                    {
                        mn[i, j] = mn[i - 1, j - 1];
                    }
                    else
                    {
                        mn[i, j] = Math.Min(mn[i - 1, j - 1], Math.Min(mn[i - 1, j], mn[i, j - 1])) + 1;
                    }
                }
            }

            int maxLength = Math.Max(m, n);
            similarity = (double)(maxLength - mn[m, n]) / maxLength;
            return mn[m, n];
        }

        /// <summary>
        /// 计算两个字符串的相似度，应用公式：相似度=kq*q/(kq*q+kr*r+ks*s)(kq>0,kr>=0,ka>=0)
        /// 其中，q是字符串1和字符串2中都存在的单词的总数，s是字符串1中存在，字符串2中不存在的单词总数，r是字符串2中存在，字符串1中不存在的单词总数. kq,kr和ka分别是q,r,s的权重，根据实际的计算情况，我们设kq=2，kr=ks=1.
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <param name="target">目标字符串</param>
        /// <param name="ignoreCase">是否忽略大小写</param>
        /// <returns>字符串相似度</returns>
        public static double GetSimilarityWith(this string source, string target, bool ignoreCase = false)
        {
            if (string.IsNullOrEmpty(source) && string.IsNullOrEmpty(target))
            {
                return 1;
            }
            if (string.IsNullOrEmpty(source) || string.IsNullOrEmpty(target))
            {
                return 0;
            }
            const double kq = 2, kr = 1, ks = 1;
            char[] sourceChars = source.ToCharArray(), targetChars = target.ToCharArray();

            //获取交集数量
            int q = sourceChars.Intersect(targetChars).Count(), s = sourceChars.Length - q, r = targetChars.Length - q;
            return kq * q / (kq * q + kr * r + ks * s);
        }

        #endregion

        public static object ParseTo(this string str, string type)
        {
            switch (type)
            {
                case "System.Boolean":
                    return ToBoolean(str);
                case "System.SByte":
                    return ToSByte(str);
                case "System.Byte":
                    return ToByte(str);
                case "System.UInt16":
                    return ToUInt16(str);
                case "System.Int16":
                    return ToInt16(str);
                case "System.uInt32":
                    return ToUInt32(str);
                case "System.Int32":
                    return str.ToInt32();
                case "System.UInt64":
                    return ToUInt64(str);
                case "System.Int64":
                    return ToInt64(str);
                case "System.Single":
                    return ToSingle(str);
                case "System.Double":
                    return ToDouble(str);
                case "System.Decimal":
                    return ToDecimal(str);
                case "System.DateTime":
                    return ToDateTime(str);
                case "System.Guid":
                    return ToGuid(str);
            }
            throw new NotSupportedException(string.Format("The string of \"{0}\" can not be parsed to {1}", str, type));
        }

        public static sbyte? ToSByte(this string value)
        {
            sbyte value2;
            if (sbyte.TryParse(value, out value2))
            {
                return value2;
            }
            return null;
        }

        public static byte? ToByte(this string value)
        {
            byte value2;
            if (byte.TryParse(value, out value2))
            {
                return value2;
            }
            return null;
        }

        public static ushort? ToUInt16(this string value)
        {
            ushort value2;
            if (ushort.TryParse(value, out value2))
            {
                return value2;
            }
            return null;
        }

        public static short? ToInt16(this string value)
        {
            short value2;
            if (short.TryParse(value, out value2))
            {
                return value2;
            }
            return null;
        }

        public static uint? ToUInt32(this string value)
        {
            uint value2;
            if (uint.TryParse(value, out value2))
            {
                return value2;
            }
            return null;
        }

        public static ulong? ToUInt64(this string value)
        {
            ulong value2;
            if (ulong.TryParse(value, out value2))
            {
                return value2;
            }
            return null;
        }

        public static long? ToInt64(this string value)
        {
            long value2;
            if (long.TryParse(value, out value2))
            {
                return value2;
            }
            return null;
        }

        public static float? ToSingle(this string value)
        {
            float value2;
            if (float.TryParse(value, out value2))
            {
                return value2;
            }
            return null;
        }

        public static double? ToDouble(this string value)
        {
            double value2;
            if (double.TryParse(value, out value2))
            {
                return value2;
            }
            return null;
        }

        public static decimal? ToDecimal(this string value)
        {
            decimal value2;
            if (decimal.TryParse(value, out value2))
            {
                return value2;
            }
            return null;
        }

        public static bool? ToBoolean(this string value)
        {
            bool value2;
            if (bool.TryParse(value, out value2))
            {
                return value2;
            }
            return null;
        }

        public static T? ToEnum<T>(this string str) where T : struct
        {
            T t;
            if (Enum.TryParse(str, true, out t) && Enum.IsDefined(typeof(T), t))
            {
                return t;
            }
            return null;
        }

        public static Guid? ToGuid(this string str)
        {
            Guid value;
            if (Guid.TryParse(str, out value))
            {
                return value;
            }
            return null;
        }

        public static DateTime? ToDateTime(this string value)
        {
            DateTime value2;
            if (DateTime.TryParse(value, out value2))
            {
                return value2;
            }
            return null;
        }

        public static int? ToInt32(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return null;
            }
            int value;
            if (int.TryParse(input, out value))
            {
                return value;
            }
            return null;
        }

        /// <summary>
        ///     替换空格字符
        /// </summary>
        /// <param name="input"></param>
        /// <param name="replacement">替换为该字符</param>
        /// <returns>替换后的字符串</returns>
        public static string ReplaceWhitespace(this string input, string replacement = "")
        {
            return string.IsNullOrEmpty(input) ? null : Regex.Replace(input, "\\s", replacement, RegexOptions.Compiled);
        }

        /// <summary>
        ///     返回一个值，该值指示指定的 String 对象是否出现在此字符串中。
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value">要搜寻的字符串。</param>
        /// <param name="comparisonType">指定搜索规则的枚举值之一。</param>
        /// <returns>如果 value 参数出现在此字符串中则为 true；否则为 false。</returns>
        public static bool Contains(this string source, string value,
            StringComparison comparisonType = StringComparison.OrdinalIgnoreCase)
        {
            return source.IndexOf(value, comparisonType) >= 0;
        }

        /// <summary>
        ///     清除 Html 代码，并返回指定长度的文本。(连续空行或空格会被替换为一个)
        /// </summary>
        /// <param name="text"></param>
        /// <param name="maxLength">返回的文本长度（为0返回所有文本）</param>
        /// <returns></returns>
        public static string StripHtml(this string text, int maxLength = 0)
        {
            if (string.IsNullOrEmpty(text)) return string.Empty;
            text = text.Trim();

            text = Regex.Replace(text, "[\\r\\n]{2,}", "<&rn>"); //替换回车和换行为<&rn>，防止下一行代码替换空格的时候被替换掉
            text = Regex.Replace(text, "[\\s]{2,}", " "); //替换 2 个以上的空格为 1 个
            text = Regex.Replace(text, "(<&rn>)+", "\n"); //还原 <&rn> 为 \n
            text = Regex.Replace(text, "(\\s*&[n|N][b|B][s|S][p|P];\\s*)+", " "); //&nbsp;

            text = Regex.Replace(text, "(<[b|B][r|R]/*>)+|(<[p|P](.|\\n)*?>)", "\n"); //<br>
            text = Regex.Replace(text, "<(.|\n)+?>", " ", RegexOptions.IgnoreCase); //any other tags

            if (maxLength > 0 && text.Length > maxLength)
                text = text.Substring(0, maxLength);

            return text;
        }
    }
}
