using Mirai.Net.Data.Messages;
using Mirai.Net.Sessions.Http.Managers;
using Mirai.Net.Utils.Scaffolds;

namespace Net_2kBot.modules
{
    public class Call
    {
        //叫人功能
        public static async void Execute(string victim, string group, int times)
        {
            if (times >= 10)
            {
                times = 10;
            }
            MessageChain? messageChain = new MessageChainBuilder()
                               .At(victim)
                               .Plain(" 机器人正在呼叫你")
                               .Build();
            Global.TimeNow = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
            if (Global.TimeNow - Global.LastCall >= Global.Cd)
            {
                for (int i = 0; i < times; i++)
                {
                    try
                    {
                        await MessageManager.SendGroupMessageAsync(group, messageChain);
                        Global.LastCall = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
                    }
                    catch
                    {
                        break;
                    }
                }
            }
            else
            {
                Global.TimeNow = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
                try
                {
                    await MessageManager.SendGroupMessageAsync(group, "CD未到，请别急！CD还剩： " + (Global.Cd - (Global.TimeNow - Global.LastCall)).ToString() + " 秒");
                }
                catch
                {
                    Console.WriteLine("群消息发送失败：CD未到，请别急！CD还剩：" + (Global.Cd - (Global.TimeNow - Global.LastCall)).ToString() + " 秒");
                }
            }
        }
    }
}
