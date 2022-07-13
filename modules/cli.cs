using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Sessions.Http.Managers;
using Mirai.Net.Utils.Scaffolds;

namespace Net_2kBot.modules
{
    public static class Cli
    {
        public static async void Execute(MessageReceiverBase @base)
        {
            if (@base is FriendMessageReceiver receiver)
            {
                if (receiver.MessageChain.GetPlainMessage().ToLower().StartsWith("/send"))
                {
                    string[] text = receiver.MessageChain.GetPlainMessage().Split(" ");
                    if (text.Length >= 3)
                    {
                        string results = "";
                        for (int i = 2; i < text.Length; i++)
                        {
                            if (i == 2)
                            {
                                results = text[i];
                            }
                            else
                            {
                                results = results + " " + text[i];
                            }
                        }
                        try
                        {
                            await MessageManager.SendGroupMessageAsync(text[1], results);
                        }
                        catch
                        {
                            Console.WriteLine("群消息发送失败");
                        }
                    }
                    else
                    {
                        await receiver.SendMessageAsync("参数缺少");
                    }
                }
            }
        }
    }
}
