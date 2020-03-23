using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Sem2IntroProjectWaterfall0._1
{
    public class Logger
    {
        private LoggingLevels loggingLevel;
        private string fileName;
        
        public LoggingLevels LoggingLevel
        {
            get { return this.loggingLevel; }
            set { this.loggingLevel = value; }
        }

        public Logger()
        {
            this.LoggingLevel = LoggingLevels.INFO;
            Initilization();
            DeleteOldLogs(10);
        }

        public Logger(LoggingLevels logLevel)
        {
            this.loggingLevel = logLevel;
            Initilization();
            DeleteOldLogs(10);
        }

        public Logger(LoggingLevels logLevel, int deleteIfMoreThan)
        {
            this.loggingLevel = logLevel;
            Initilization();
            if(deleteIfMoreThan > 0) DeleteOldLogs(deleteIfMoreThan);
        }

        private void Initilization()
        {
            this.fileName = $"log-{DateTime.Now.ToString("dd-MM-yyyy--HH-mm-ss")}.txt";

            FileStream fs = null;
            StreamWriter sw = null;
            try
            {
                Directory.CreateDirectory("logs");
                fs = new FileStream(Path.Combine("logs", fileName), FileMode.OpenOrCreate, FileAccess.Write);
                sw = new StreamWriter(fs);

                sw.WriteLine($"[{DateTime.Now}] Logger initialized");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex}");
            }
            finally
            {
                if (sw != null) sw.Close();
            }
        }

        private void DeleteOldLogs(int skipFirstX)
        {
            try
            {
                int counter = 0;
                foreach (var file in new DirectoryInfo(".\\logs").GetFiles().OrderByDescending(x => x.LastWriteTime).Skip(skipFirstX))
                {
                    file.Delete();
                    counter++;
                }
                InternalLog($"Successfully executed deletion of old logs. As a result, {counter} files were deleted from the system.", LoggingLevels.INFO);
            }
            catch (Exception ex)
            {
                InternalLog($"Application ran into some problems when trying to delete old logs\n{ex}", LoggingLevels.ERROR);
            }
        }

        private void InternalLog(string msg, LoggingLevels logLevel)
        {
            FileStream fs = null;
            StreamWriter sw = null;
            try
            {
                fs = new FileStream(Path.Combine("logs", fileName), FileMode.Append, FileAccess.Write);
                sw = new StreamWriter(fs);

                sw.WriteLine($"[{DateTime.Now}] {logLevel.ToString().PadRight(10)} | {msg}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"ERROR: {ex}");
            }
            finally
            {
                if (sw != null) sw.Close();
            }
        }

        public void Debug(string msg)
        {
            InternalLog(msg, LoggingLevels.DEBUG);
        }

        public void Info(string msg)
        {
            InternalLog(msg, LoggingLevels.INFO);
        }
        public void Warning(string msg)
        {
            InternalLog(msg, LoggingLevels.WARNING);
        }
        public void Error(string msg)
        {
            InternalLog(msg, LoggingLevels.ERROR);
        }

        public void Log (string msg, LoggingLevels logLevel)
        {
            if ((int)logLevel >= (int)this.LoggingLevel) InternalLog(msg, logLevel);
        }
    }
}
