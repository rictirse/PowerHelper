using PowerHelper.ViewModel;
using System;
using System.Linq;
using System.Reflection;

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

        public static (int acValue, int dcValue) ParserToValue(this string cmdStr)
        {
            var lines = cmdStr.Split("\r\n").ToArray();
            var index = lines.Select((x, i) => new { line = x, index = i++ })
                .Where(x => x.line.Contains("PROCTHROTTLEMAX"))
                .Select(x => x.index)
                .SingleOrDefault();

            if (index == 0
                || index + 6 > lines.Length) return (0, 0);

            try
            {
                var acValue = lines[index + 5].TryGetValue();
                var dcValue = lines[index + 6].TryGetValue();
                
                return (acValue, dcValue);
            }
            catch
            {
                return (0, 0);
            }
        }

        public static Plan? ParserToPlan(this string cmdStr)
        {
            var result = cmdStr.ParserToValue();

            return new Plan
            {
                AcValue = result.acValue,
                DcValue = result.dcValue,
                Name    = "PROCTHROTTLEMAX"
            };
        }
    }
}
