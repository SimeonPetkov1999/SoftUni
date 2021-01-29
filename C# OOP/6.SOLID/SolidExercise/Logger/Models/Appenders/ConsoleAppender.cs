using Logger.Common;
using Logger.Models.Contracts;
using Logger.Models.Enumerations;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Logger.Models.Appenders
{
    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout, Level level)
        {
            this.Layout = layout;
            this.Level = level;
        }
        public ILayout Layout { get; private set; }

        public Level Level { get; private set; }

        public int MessageAppended { get; private set; }

        public void Append(IError error)
        {
            string format=this.Layout.Format;

            DateTime dateTime = error.DateTime;
            string message = error.Messege;
            Level level = error.Level;
            string formattedMessage = string.Format(format,
                dateTime.ToString(GlobalConstants.DATE_FORMAT,
                CultureInfo.InvariantCulture), message, level.ToString());

            Console.WriteLine(formattedMessage);
            this.MessageAppended++;
        }

        public override string ToString()
        {
         return $"Appender type: {this.GetType().Name}," +
                $" Layout type: {this.Layout.GetType().Name}, " +
                $"Report level: {this.Level.ToString().ToUpper()}, " +
                $"Messages appended: {this.MessageAppended}";
        }
    }
}
