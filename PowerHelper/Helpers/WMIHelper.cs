using System.Management;

namespace PowerHelper.Helpers
{
    public static class WMIHelper
    {
        public static int GetClockSpeed()
        {
            uint clockSpeed = 0;

            try
            {
                var searcher = new ManagementObjectSearcher("select MaxClockSpeed from Win32_Processor");
                foreach (var item in searcher.Get())
                {
                    clockSpeed = (uint)item["MaxClockSpeed"];
                }
            }
            catch { }

            return (int)clockSpeed;
        }
    }
}
