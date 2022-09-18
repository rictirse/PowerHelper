using System.Diagnostics;
using System.Threading.Tasks;

namespace PowerHelper.Helpers
{
    internal class ConsoleHelper
    {
        const string cmdFileName = "cmd.exe";
        private static Process CreatProcess(string fileName) =>
            new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = fileName,
                    UseShellExecute = false,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                }
            };

        public static async Task<string> CmdCommandAsync(params string[] cmds)
            => await CommandAsync(cmdFileName, cmds);

        public static string CmdCommand(params string[] cmds)
            => Command(cmdFileName, cmds);

        public static async Task<string> CommandSingleLineAsync(string fileName, string argument)
        {
            var p = new Process
            {
                StartInfo = new(fileName, argument)
                {
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };
            p.Start();
            return await p.StandardOutput.ReadToEndAsync();
        }

        public static async Task<string> CommandAsync(string fileName, params string[] arguments)
        {
            var p = CreatProcess(fileName);
            p.Start();
            foreach (var argument in arguments)
            {
                p.StandardInput.WriteLine(argument);
            }
            p.StandardInput.WriteLine("exit");
            var result = await p.StandardOutput.ReadToEndAsync();
            var error = await p.StandardError.ReadToEndAsync();
            if (!string.IsNullOrWhiteSpace(error))
                result = result + "\r\n<Error Message>:\r\n" + error;
            await p.WaitForExitAsync();
            p.Close();
            Debug.WriteLine(result);
            return result;
        }

        public static string Command(string fileName, params string[] arguments)
        {
            var p = CreatProcess(fileName);
            p.Start();
            foreach (var argument in arguments)
            {
                p.StandardInput.WriteLine(argument);
            }
            p.StandardInput.WriteLine("exit");
            var result = p.StandardOutput.ReadToEnd();
            var error = p.StandardError.ReadToEnd();
            if (!string.IsNullOrWhiteSpace(error))
                result = result + "\r\n<Error Message>:\r\n" + error;
            p.WaitForExit();
            p.Close();
            Debug.WriteLine(result);
            return result;
        }
    }
}
