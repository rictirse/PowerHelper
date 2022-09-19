using System.Management;

namespace PowerHelper.Helpers
{
    public static class WMIHelper
    {
        public static int GetClockSpeed()
        {
            var searcher = new ManagementObjectSearcher("select MaxClockSpeed from Win32_Processor");
            uint clockSpeed = 0;

            foreach (var item in searcher.Get())
            {
                clockSpeed = (uint)item["MaxClockSpeed"];
            }

            return (int)clockSpeed;
        }
    }
}
