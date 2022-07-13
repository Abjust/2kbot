namespace Net_2kBot.modules
{
    public static class Global
    {
        public static long LastCall;
        public static long TimeNow;
        public static readonly int Cd = 40;
        public static string[]? Ops;
        public static string[]? Blocklist;
        public static readonly string Path = Directory.GetCurrentDirectory();
        public static readonly string[] Ignores =
                {
                    "748029973",
                    "2265453790",
                    "2286003479",
                    "3594648576",
                    "3573523379"
                };
        public const string ApiKey = "";
        public const string Qq = "";
        public static readonly string VerifyKey = "";
    };
}
