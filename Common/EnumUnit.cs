using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
  public enum EnumUnit
    {
        Continue = 100,
        witchingProtocols = 101,
        [Description("成功")]
        OK = 200,
        Created = 201,
        Accepted = 202,
        NonAuthoritativeInformation = 203,
        NoContent = 204,
        ResetContent = 205,
        PartialContent = 206,
        MultipleChoices = 300,
        MovedPermanently = 301,
        Found = 302,
        SeeOther = 303,
        NotModified = 304,
        UseProxy = 305,
        TemporaryRedirect = 307,
        BadRequest = 400,
        [Description("身份认证失败！")]
        Unauthorized = 401,
        PaymentRequired = 402,
        Forbidden = 403,
        NotFound = 404,
        MethodNotAllowed = 405,
        NotAcceptable = 406,
        ProxyAuthenticationRequired = 407,
        RequestTime_out = 408,
        Conflict = 409,
        Gone = 410,
        LengthRequired = 411,
        PreconditionFailed = 412,
        RequestEntityTooLarge = 413,
        Request_URITooLarge = 414,
        UnsupportedMediaType = 415,
        Requestedrangenotsatisfiable = 416,
        ExpectationFailed = 417,
        InternalServerError = 500,
        NotImplemented = 501,
        BadGateway = 502,
        ServiceUnavailable = 503,
        GatewayTime_out = 504,
        HTTPVersion_notsupported = 505
    }
    /// <summary>
    /// 枚举帮助类（获得枚举描述信息）
    /// </summary>
    public static class EnumHelper
    {
        /// <summary>
        /// 返回枚举项的描述信息。
        /// </summary>
        /// <param name="value">要获取描述信息的枚举项。</param>
        /// <returns>枚举想的描述信息。</returns>
        public static string GetDescription(this Enum value)
        {
            Type enumType = value.GetType();
            DescriptionAttribute attr = null;
            string[] strName = Enum.GetNames(enumType);
            Array strValue = Enum.GetValues(enumType);
            FieldInfo[] fil = enumType.GetFields();
            foreach (EnumUnit item in Enum.GetValues(typeof(EnumUnit)))
            {
                bool f = Enum.Equals(value, item);
                if (value.CompareTo(item) == 0)
                {

                    // 获取枚举常数名称。
                    string name = Enum.GetName(enumType, item);
                    if (name != null)
                    {
                        // 获取枚举字段。
                        FieldInfo fieldInfo = enumType.GetField(name);
                        if (fieldInfo != null)
                        {
                            // 获取描述的属性。
                            attr = Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute), false) as DescriptionAttribute;
                        }
                    }
                    break;
                }
                else
                {
                    continue;
                }
            }
            if (attr != null && !string.IsNullOrEmpty(attr.Description))
            {
                return attr.Description;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
