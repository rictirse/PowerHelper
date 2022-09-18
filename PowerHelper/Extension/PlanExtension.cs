using PowerHelper.ViewModel;
using System;
using System.Linq;

namespace PowerHelper.Extension
{
    internal static class PlanExtension
    {
        /// <summary>
        /// cmd文字解析成Plan
        /// </summary>
        public static int TryGetValue(this string line)
        {
            try
            {
                return Convert.ToInt32(line.Split(":").ElementAt(1).Trim(), 16);
            }
            catch
            {
                return 0;
            }
        }

        public static Plan? ParserToPlan(this string cmdStr)
        {
            var lines = cmdStr.Split("\r\n").ToArray();
            var index = lines.Select((x, i) => new { line = x, index = i++ })
                .Where(x => x.line.Contains("PROCTHROTTLEMAX"))
                .Select(x => x.index)
                .SingleOrDefault();

            if (index == 0 
                || index + 6 > lines.Length) return null;

            try
            {
                return new Plan
                {
                    AcValue = lines[index + 5].TryGetValue(),
                    DcValue = lines[index + 6].TryGetValue(),
                    Name    = "PROCTHROTTLEMAX"
                };
            }
            catch
            {
                return null;
            }
        }
    }
}
