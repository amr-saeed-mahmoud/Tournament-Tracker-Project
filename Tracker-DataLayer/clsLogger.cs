using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker_DataLayer
{
    public static class clsLogger
    {
        public static void LogErrorToEventLog(string Message)
        {
            try
            {
                using(EventLog Logger = new EventLog())
                {
                    Logger.WriteEntry(Message, EventLogEntryType.Error);
                }
            }catch (Exception ex) { Console.WriteLine(ex.ToString()); }
        }
        //TODO- Make it a debuger attribute
        public static void LogErrorToFile(string Message, string FileLocation = "")
        {
            if(string.IsNullOrEmpty(FileLocation)) 
                FileLocation = Directory.GetCurrentDirectory();

            try
            {
                using(StreamWriter Writer = new StreamWriter(FileLocation))
                {
                    Writer.WriteLine(Message);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
        }
    }
}
