using PowerHelper.Extension;
using PowerHelper.ViewModel;

namespace PowerHelper.Helpers
{
    internal static class PowerCfgCli
    {
        public static Plan? GetCurrentPowerCfgStatus()
        {
            var strResult = ConsoleHelper.CmdCommand("powercfg /query SCHEME_CURRENT SUB_PROCESSOR");

            return strResult.ParserToPlan();
        }

        /// <summary>
        /// 設定當前的直流電最高效能的數值
        /// </summary>
        public static void SetCurrentPowerCfgDcPROCTHROTTLEMAX(int value)
        {
            var command = $"powercfg -setdcvalueindex SCHEME_CURRENT SUB_PROCESSOR PROCTHROTTLEMAX {value}";
            ConsoleHelper.CmdCommand(command);
        }
    }
}
