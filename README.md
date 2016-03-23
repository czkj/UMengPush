如果觉得适合你，请给一颗星星哟，仅表我写代码的安慰(^_^)

# NSTool.UMengPush
友盟推送基于2.3sdk封装， 使用C#语法开发的 .NET版 sdk封装，主要封装了IOS手机推送支持

<b style="color:red">注意：使用前请使用Nuget控制台恢复程序集引用。</b>


//例子一，具体参考TEST
<pre>
           PostUMengJson postJson = new PostUMengJson();
            postJson.production_mode = "false";//开发环境
            postJson.type = "unicast";//单播 
            postJson.device_tokens = "8ebc607753ee042e38492f9d8e6bf13c07ae6cff54fa4c1d10d34aa1425e4d1e"; 

            postJson.payload = new Payload() { aps = new Aps { alert = "你好啊！来自zhuyongwu的问候"+" 这是异步方法！", badge = "1", sound = "beep.wav" } };

            //异步方法
            umPush.AsynSendMessage(postJson, callBack);
</pre>
