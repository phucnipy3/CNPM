using System;
using System.IO;
using System.Threading.Tasks;

namespace Common.Logger
{
    public static class Logger<T>
    {
        private const string path = "../../../Log/";

        public static async Task LogAsync(string message)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            FileInfo file = new FileInfo(path + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".txt");

            string log = DateTime.Now.ToString() + "\t" + typeof(T) + "\t" + message;

            try
            {
                StreamWriter writer = file.AppendText();
                await writer.WriteLineAsync(log);
                writer.Close();
                file.Refresh();
            }
            catch
            {
                await Task.Delay(2000);
                await LogAsync(message);
            }
        }
    }
}
