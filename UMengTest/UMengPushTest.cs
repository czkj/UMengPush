using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using NSTool.UMengPush;
using NSTool.UMengPush.Core;

namespace UMengTest
{
    /// <summary>
    /// 仅仅只是演示2个类型推送，其他的都可以自己参考友盟参数的文档进行赋值
    /// </summary>
    [TestClass]
    public class UMengPushTest
    {
        //appkey,AppMasterSecret
        UMengMessagePush umPush = new UMengMessagePush("56eab78267e58e90c3001a86", "3khjjjui2rqh4yf9bvuwlkxwddrys2hm");
        
        /// <summary>
        /// 推送给所有用户
        /// </summary>
        [TestMethod]
        public void TestPushByAllUser()
        {
            PostUMengJson postJson = new PostUMengJson();
            postJson.production_mode = "false";//开发环境
            postJson.type = "unicast";//单播 
            postJson.device_tokens = "8ebc607753ee042e38492f9d8e6bf13c07ae6cff54fa4c1d10d34aa1425e4d1e"; 

            postJson.payload = new Payload() { aps = new Aps { alert = "你好啊！来自朱勇的问候"+" 这是异步方法！", badge = "1", sound = "beep.wav" } };

            //异步方法
            umPush.AsynSendMessage(postJson, callBack);


            //var resu = umPush.SendMessage(postJson);

            //if (resu.ret == "SUCCESS")
            //{
            //    Console.WriteLine("发送成功!");
            //}
            //else
            //{
            //    Console.WriteLine("发送失败!");
            //}

        }

        /// <summary>
        /// 根据自定义用户ID推送
        /// </summary>
        [TestMethod]
        public void TestPushByAlias()
        {
            PostUMengJson postJson = new PostUMengJson();
            postJson.type = "customizedcast";
            postJson.alias_type = "USER_ID";
            postJson.alias = "5583";
            postJson.payload = new Payload() { aps = new Aps { alert = "你好啊！来自朱勇的问候", badge = "1", sound = "beep.wav" } };


            umPush.AsynSendMessage(postJson, callBack);
        }

        private void callBack(ReturnJsonClass result)
        {
            ReturnJsonClass a1 = result;
        }

    
    }
}
