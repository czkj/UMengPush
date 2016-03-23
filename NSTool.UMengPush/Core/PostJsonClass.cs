using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NSTool.UMengPush.Base;

namespace NSTool.UMengPush.Core
{
    /// <summary>
    /// 发送到友盟的json实体类
    /// </summary>
    public class PostUMengJson
    {

        /// <summary>
        /// 必填 应用唯一标识
        /// </summary>
        public string appkey { get; set; }
        /// <summary>
        /// 注意：该值由UMengMessagePush自动生成，无需主动赋值
        /// 
        /// 必填 时间戳，10位或者13位均可，时间戳有效期为10分钟 
        /// </summary>
        public string timestamp { get; set; }
        /// <summary>
        /// 必填 消息发送类型,其值可以为:
        /// <example>
        ///unicast-单播
        ///listcast-列播(要求不超过500个device_token)
        ///filecast-文件播
        ///(多个device_token可通过文件形式批量发送）
        ///broadcast-广播
        ///groupcast-组播
        ///(按照filter条件筛选特定用户群, 具体请参照filter参数)
        ///customizedcast(通过开发者自有的alias进行推送), 
        ///包括以下两种case:
        ///- alias: 对单个或者多个alias进行推送
        ///- file_id: 将alias存放到文件后，根据file_id来推送
        ///</example>
        /// </summary>
        public string type { get; set; }

        public string device_tokens { get; set; }
        /// <summary>
        /// 可选 
        /// 当type=customizedcast时必填，alias的类型, 
        /// alias_type可由开发者自定义,
        /// 开发者在SDK中调用setAlias(alias, alias_type)时所设置的alias_type
        /// </summary>
        public string alias_type { get; set; }
        /// <summary>
        /// 可选 当type=customizedcast时, 
        /// 开发者填写自己的alias。 要求不超过50个alias,多个alias以英文逗号间隔。
        /// 在SDK中调用setAlias(alias, alias_type)时所设置的alias
        /// </summary>
        public string alias { get; set; }

        public string file_id { get; set; }

        public string filter { get; set; }
        /// <summary>
        /// 必填 消息内容(iOS最大为2012B),
        /// </summary>
        public Payload payload { get; set; }
        /// <summary>
        /// 可选 发送策略
        /// </summary>
        public Policy policy { get; set; }

        /// <summary>
        /// // 可选 正式/测试模式。测试模式下，广播/组播只会将消息发给测试设备。
        /// </summary>
        public string production_mode { get; set; }
        /// <summary>
        /// 可选 发送消息描述，建议填写。
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// 可选 开发者自定义消息标识ID, 开发者可以为同一批发送的消息提供
        /// 同一个thirdparty_id, 便于后期合并统计数据。  
        /// </summary>
        public string thirdparty_id { get; set; }
    }


    public class Payload
    {
        public Aps aps { get; set; }
        public string key1 { get; set; } //可选 用户自定义内容, "d","p"为友盟保留字段， key不可以是"d","p"
        public string key2 { get; set; }
    }



    public class Aps
    { 
        public string alert{get;set;} // 必填         
        public string  badge{get;set;}   // 可选     
        public string sound{get;set;}  // 可选       
        public string content_available{get;set;} // 可选      
        public string category {get;set;} // 可选, 注意: ios8才支持该字段。
    }





    public class Policy
    {
        public string start_time { get; set; }
        public string expire_time { get; set; }
        public int max_send_num { get; set; }

    }
}
