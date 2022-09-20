using PowerHelper.Extension;
using System.Threading.Tasks;

namespace PowerHelper.Helpers
{
    internal static class PowerCfgCli
    {
        public static async Task<(int acValue, int dcValue)> GetCurrentPowerCfgPlan()
        {
            var strResult = await ConsoleHelper.CmdCommandAsync("powercfg /query SCHEME_CURRENT SUB_PROCESSOR");

            return strResult.ParserToValue();
        }

        /// <summary>
        /// 設定當前的電池最高效能的數值
        /// </summary>
        public static Task SetCurrentDcPROCTHROTTLEMAX(int value)
        {
            var command = $"powercfg -setdcvalueindex SCHEME_CURRENT SUB_PROCESSOR PROCTHROTTLEMAX {value}";
            return ConsoleHelper.CmdCommandAsync(command);
        }

        /// <summary>
        /// 設定當前的室電最高效能的數值
        /// </summary>
        public static Task SetCurrentAcPROCTHROTTLEMAX(int value)
        {
            var command = $"powercfg -setacvalueindex SCHEME_CURRENT SUB_PROCESSOR PROCTHROTTLEMAX {value}";
            return ConsoleHelper.CmdCommandAsync(command);
        }
    }
}
