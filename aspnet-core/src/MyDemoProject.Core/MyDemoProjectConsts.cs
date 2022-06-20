using MyDemoProject.Debugging;

namespace MyDemoProject
{
    public class MyDemoProjectConsts
    {
        public const string LocalizationSourceName = "MyDemoProject";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "7bbda41cd108476a95c41fd0661908ff";
    }
}
