using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// 数据验证类，验证是否邮箱、手机号。。。
    /// </summary>
    public class DataValidation
    {
        private static string regEmail = @"\w+((-w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+";//@"^\s*([A-Za-z0-9_-]+(\.\w+)*@([\w-]+\.)+\w{2,10})\s*$"
        private static string regPhone = @"^((0?1[358]\d{9})|((0(10|2[1-3]|[3-9]\d{2}))?[1-9]\d{6,7}))$";
        private static string regUserName = @"^[A-Za-z0-9_\-\u4e00-\u9fa5]+$"; //数字+字母+_+-+中文组合
        private static string regImageType = @"(.*)\.(jpg|bmp|gif|jpeg|png)$";
        private static string regNumber = @"^[1-9]\d*$";//数字0-9
        private static string regNumLetter = @"^[A-Za-z0-9]+$";//数字和字母
        private static string imgType = "jpg,png,gif,";
        private static string regPassWord = @"^[A-Za-z0-9_-]+$";//数字、大小写字母、下划线和中横线组成

        /// <summary>
        /// 判断是否邮箱
        /// </summary>
        /// <param name="str">待检测字符串</param>
        /// <returns>是邮箱格式，则返回true,否则为false</returns>
        public static bool IsEmail(string strInput)
        {
            return Regex.IsMatch(strInput, regEmail);
        }
        /// <summary>
        /// 判断是否手机号码
        /// </summary>
        /// <param name="str">待检测字符串</param>
        /// <returns>是则返回true,否则为false</returns>
        public static bool IsPhone(string strInput)
        {
            return Regex.IsMatch(strInput, regPhone);
        }
        /// <summary>
        /// 判断数据集是不是null或无数据,并默认检查第一个DataTable
        /// </summary>
        /// <param name="dataSet">数据集DataSet</param>
        /// <returns>否返回true,是返回false</returns>
        public static bool DataSetIsNullOrEmpty(DataSet dataSet)
        {
            if (dataSet != null && dataSet.Tables != null && dataSet.Tables[0].Rows.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// 判断DataTable是不是null或无数据
        /// </summary>
        /// <param name="dataSet">数据集DataSet</param>
        /// <returns>否返回true,是返回false</returns>
        public static bool DataTableIsNullOrEmpty(DataTable dataTable)
        {
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 验证用户名（数字+字母+_+-+中文组合）及长度
        /// </summary>
        /// <param name="strInput">要验证的字符串</param>
        /// <param name="min">最小长度</param>
        /// <param name="max">最大长度</param>
        /// <returns>bool类型，true符合，false不符合</returns>
        public static bool CheckUserName(string strInput, int min, int max)
        {
            if (CheckStringLength(strInput, min, max))
            {
                return Regex.IsMatch(strInput, regUserName);
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 验证字符串的长度
        /// </summary>
        /// <param name="strInput">要验证的字符串</param>
        /// <param name="min">最小长度</param>
        /// <param name="max">最大长度</param>
        /// <returns>bool类型，true符合，false不符合 </returns>
        public static bool CheckStringLength(string strInput, int min, int max)
        {
            if (string.IsNullOrEmpty(strInput))
            {
                return false;
            }
            else
            {
                if (strInput.Length >= min && strInput.Length <= max)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 初始化字符串为""
        /// </summary>
        /// <param name="value">一个 System.String 引用</param>
        /// <returns>返回字符串</returns>
        public static string InitializeValue(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return "";
            }
            else
            {
                return value.ToString();
            }
        }
        /// <summary>
        /// 判断是否图片格式，jpg|bmp|gif|jpeg|png
        /// </summary>
        /// <param name="extName">扩展名</param>
        /// <returns>bool</returns>
        public static bool IsImageType1(string extName)
        {
            if (string.IsNullOrEmpty(extName))
            {
                return false;
            }
            else
            {
                return Regex.IsMatch(extName, regImageType);
            }
        }
        /// <summary>
        /// 判断是否宠物米编码格式
        /// </summary>
        /// <param name="num">编码</param>
        /// <returns>bool值</returns>
        public static bool isChipNumberType(string num)
        {
            if (string.IsNullOrEmpty(num))
            {
                return false;
            }

            if (num.Length == 16 || num.Length == 15 || num.Length == 9)
            {
                return Regex.IsMatch(num, regNumber);
            }
            else if (num.Length == 10)
            {
                return Regex.IsMatch(num, regNumLetter);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 验证是否是允许的图片格式：jpg、png、gif、bmp。
        /// </summary>
        /// <param name="postFile"></param>
        /// <returns></returns>
        public static bool IsAllowedExtension(string imgType)
        {
            if (imgType.Contains("image/"))    //图片的MIME类型为"image/xxx"，这里只判断是否图片。
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 验证密码（数字、大小写字母、下划线和中横线组成）及长度
        /// </summary>
        /// <param name="strInput">要验证的字符串</param>
        /// <param name="min">最小长度</param>
        /// <param name="max">最大长度</param>
        /// <returns>bool类型，true符合，false不符合</returns>
        public static bool IsAllowedPassWordType(string strInput, int min, int max)
        {
            if (CheckStringLength(strInput, min, max))
            {
                return Regex.IsMatch(strInput, regUserName);
            }
            else
            {
                return false;
            }
        }
    }
}
