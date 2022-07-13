﻿using Manganese.Text;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Utils.Scaffolds;

namespace Net_2kBot.modules
{
    public static class Help
    {
        public static async void Execute(MessageReceiverBase @base)
        {
            if (@base is GroupMessageReceiver receiver)
            {
                //菜单
                if (receiver.MessageChain.GetPlainMessage() == "菜单" || receiver.MessageChain.GetPlainMessage() == "/menu")
                {
                    try
                    {
                        await receiver.SendMessageAsync("2kbot菜单\r\n" +
                        "1.群管系统\r\n" +
                        "2.复读机\r\n" +
                        "3.精神心理疾病科普\r\n" +
                        "4.量表测试\r\n" +
                        "5.叫人功能\r\n" +
                        "详情请用/help指令");
                    }
                    catch
                    {
                        Console.WriteLine("菜单消息发送失败");
                    }
                }
                //帮助
                var indexs = new List<string>
                {
                    "1",
                    "2",
                    "3",
                    "4",
                    "5",
                };
                var contents = new List<string>
                {
                    "群管功能\r\n禁言：/mute <QQ号或at> [时间] （以分钟算）\r\n解禁：/unmute <QQ号或at>\r\n踢出：/kick <QQ号或at>\r\n加黑：/block <QQ号或at>\r\n解黑：/unblock <QQ号或at>\r\n给予管理员：/op <QQ号或at>\r\n剥夺管理员：/deop <QQ号或at>\r\n（上述功能都需要机器人管理员）",
                    "该指令用于复述文本\r\n用法：/echo <文本>",
                    "该指令用于叫人\r\n用法：/call <QQ号或at> [次数]",
                    "发送“精神疾病”或者“心理疾病”并按照后续出现的选项发送相应文字即可获得科普文本",
                    "发送“量表”或者“测试”并按照后续出现的选项发送相应文字即可获得链接"
                };
                if (receiver.MessageChain.GetPlainMessage().StartsWith("/help") == true)
                {
                    string[] result = receiver.MessageChain.GetPlainMessage().Split(" ");
                    if (result.Length > 1)
                    {
                        foreach (string q in indexs)
                        {
                            try
                            {
                                if (result[1] == q)
                                {
                                    try
                                    {
                                        await receiver.SendMessageAsync((contents[indexs.IndexOf(q)]));
                                    }
                                    catch { }
                                }
                                else if (result[1].ToInt32() > indexs.Count)
                                {
                                    try
                                    {
                                        await receiver.SendMessageAsync("未找到相关帮助");
                                    }
                                    catch { }
                                    break;
                                }
                            }
                            catch
                            {
                                try
                                {
                                    await receiver.SendMessageAsync("请写数字，不要写别的好吗？");
                                }
                                catch { }
                                break;
                            }
                        }
                    }
                    else if (receiver.MessageChain.GetPlainMessage() == "/help")
                    {
                        try
                        {
                            await receiver.SendMessageAsync("目前有对于以下功能的帮助文档：\r\n[1]群管功能\r\n[2]/echo\r\n[3]/call\r\n[4]精神心理疾病科普\r\n[5]量表测试");
                        }
                        catch { }
                    }
                }
            }
        }
    }
}
