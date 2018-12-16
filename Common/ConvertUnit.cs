using Microsoft.International.Converters.PinYinConverter;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class ConvertUnit
    {
        private static LogUnit log = new LogUnit(typeof(ConvertUnit));

        /// <summary>
        /// 单表查询结果转换成泛型集合
        /// </summary>
        /// <typeparam name="T">泛型集合类型</typeparam>
        /// <param name="dt">查询结果DataTable</param>
        /// <returns>以实体类为元素的泛型集合</returns>
        public static IList<T> DataTableToList<T>(DataTable dt) where T : new()
        {
            try
            {
                // 定义集合
                List<T> list = new List<T>();

                // 获得此模型的类型
                Type type = typeof(T);
                //定义一个临时变量
                string tempName = string.Empty;
                //遍历DataTable中所有的数据行 
                foreach (DataRow dr in dt.Rows)
                {
                    T t = new T();
                    // 获得此模型的公共属性
                    PropertyInfo[] propertys = t.GetType().GetProperties();
                    //遍历该对象的所有属性
                    foreach (PropertyInfo pi in propertys)
                    {
                        tempName = pi.Name;//将属性名称赋值给临时变量  
                                           //检查DataTable是否包含此列（列名==对象的属性名）    
                        if (dt.Columns.Contains(tempName))
                        {
                            // 判断此属性是否有Setter  
                            if (!pi.CanWrite) continue;//该属性不可写，直接跳出  
                                                       //取值  
                            object value = dr[tempName];
                            //如果非空，则赋给对象的属性  
                            if (value != DBNull.Value)
                            {
                                pi.SetValue(t, value, null);
                            }
                        }
                    }
                    //对象添加到泛型集合中
                    list.Add(t);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 汉字转换为拼音(全拼)
        /// </summary>
        /// <param name="chinese">汉字</param>
        /// <returns>转换后的拼音（string）</returns>
        public static string GetFullSpell(string chinese)
        {
            return ChineseToSpell(chinese);
        }
        /// <summary>
        /// 获取汉字转换为拼音的首字母
        /// </summary>
        /// <param name="chinese">汉字</param>
        /// <returns>转换后的拼音（string）</returns>
        public static string GetFirstSpell(string chinese)
        {
            string spell = ChineseToSpell(chinese);
            if (!string.IsNullOrEmpty(spell))
            {
                if (spell.Length > 1)
                {
                    spell = spell.Substring(0, 1);
                }
            }
            return spell;
        }

        /// <summary>
        /// 汉字转换为拼音
        /// </summary>
        /// <param name="chinese">汉字字符</param>
        /// <returns>转换后的拼音（string）</returns>
        private static string ChineseToSpell(string chinese)
        {
            string r = string.Empty;
            foreach (char obj in chinese)
            {
                try
                {
                    ChineseChar chineseChar = new ChineseChar(obj);
                    string t = chineseChar.Pinyins[0].ToString();
                    r += t.Substring(0, t.Length - 1);
                }
                catch
                {
                    r += obj.ToString();
                }
            }
            return r;
        }

        /// <summary>
        /// 数据集转换为Json
        /// </summary>
        /// <param name="obj">数据集</param>
        /// <param name="dateFormat">时间转换格式</param>
        /// <returns></returns>
        public static string DataToJson(object obj, string dateFormat = "yyyy-MM-dd")
        {
            try
            {
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                settings.DateFormatString = dateFormat;
                string result = JsonConvert.SerializeObject(obj, Formatting.Indented, settings);
                return result;
            }
            catch (Exception ex)
            {
                log.Error($"数据集转换为json失败:", ex);
                return "";
            }
        }

        /// <summary>
        /// 解析Json字符串为实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T JsonToData<T>(string json)
        {
            T model = JsonConvert.DeserializeObject<T>(json);
            return model;
        }

        /// <summary>
        /// 生日转换成年龄
        /// </summary>
        /// <param name="birthday"></param>
        /// <returns></returns>
        public static string BirthdayToAge(DateTime birthday)
        {
            string nianling = "";
            DateTime time_now = DateTime.Now;
            TimeSpan S = time_now - birthday;
            int cha = Convert.ToInt32(S.TotalDays);
            int cha_yue = Convert.ToInt32(cha / 30);
            int cha_nian = Convert.ToInt32(cha / 365);
            if (cha_nian == 0)
            {
                nianling = Convert.ToString(cha_yue) + "个月";
            }
            else
            {
                nianling = Convert.ToString(cha_nian) + "  岁";
            }
            return nianling;
        }

        /// <summary>
        /// 年龄转换为生日
        /// </summary>
        /// <param name="strAge">年龄字符串：2.5</param>
        /// <returns></returns>
        public static DateTime AgeToBirthday(string strAge)
        {
            try
            {
                double douAge = Convert.ToDouble(strAge);//年龄
                int intSection = Convert.ToInt32(Math.Floor(douAge));//整数部分
                double decSection = douAge - intSection;//小数部分
                DateTime nowDate = DateTime.Now;
                int nowYear = nowDate.Year;//当前年份
                int nowMonth = nowDate.Month;//当前月份
                int nowDay = nowDate.Day;//当前日
                int birYear = nowYear - intSection;//生日年份
                int birMonth = nowMonth;
                int month = Convert.ToInt32(Math.Floor(decSection * 12));
                if (nowMonth > month)
                {
                    birMonth = nowMonth - month;
                }
                else
                {
                    birMonth = nowMonth + 12 - month;
                    birYear = birYear - 1;
                }
                DateTime birthday = new DateTime(birYear, birMonth, nowDay);
                return birthday;
            }
            catch (Exception ex)
            {
                log.Error("年龄" + strAge + "转化出错：", ex);
                return new DateTime();
            }
        }


    }
}
