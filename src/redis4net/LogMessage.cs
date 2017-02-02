using System;
using System.Collections.Generic;
namespace redis4net
{
	using System.Globalization;

	public class LogMessage : Dictionary<string, object>
	{
		public string Type
		{
			get
			{
				if (!this.ContainsKey("type"))
					return null;

				return (string)this["type"];
			}
			set
			{
				if (!this.ContainsKey("type"))
					this.Add("type", value);
				else
					this["type"] = value;
			}
		}

		public string Message
		{
			get
			{
				if (!this.ContainsKey("message"))
					return null;

				return (string)this["message"];
			}
			set
			{
				if (!this.ContainsKey("message"))
					this.Add("message", value);
				else
					this["message"] = value;
			}
		}

        public int Level
        {
            get
            {
                if (!this.ContainsKey("level"))
                    return int.MinValue;

                return (int)this["level"];
            }
            set
            {
                if (!this.ContainsKey("level"))
                    this.Add("level", value);
                else
                    this["level"] = value;
            }
        }

        public string LevelName
        {
            get
            {
                if (!this.ContainsKey("levelname"))
                    return "INFO";

                return (string)this["levelname"];
            }
            set
            {
                if (!this.ContainsKey("levelname"))
                    this.Add("levelname", value);
                else
                    this["levelname"] = value;
            }
        }

        public string Host
		{
			get
			{
				if (!this.ContainsKey("host"))
					return null;

				return (string)this["host"];
			}
			set
			{
				if (!this.ContainsKey("host"))
					this.Add("host", value);
				else
					this["host"] = value;
			}
		}

		public string File
		{
			get
			{
				if (!this.ContainsKey("file"))
					return null;

				return (string)this["file"];
			}
			set
			{
				if (!this.ContainsKey("file"))
					this.Add("file", value);
				else
					this["file"] = value;
			}
		}

		public string Line
		{
			get
			{
				if (!this.ContainsKey("line"))
					return null;

				return (string)this["line"];
			}
			set
			{
				if (!this.ContainsKey("line"))
					this.Add("line", value);
				else
					this["line"] = value;
			}
		}

        public string Time
        {
            get
            {
                if (!this.ContainsKey("time"))
                    return DateTime.MinValue.ToShortDateString();

                return (string)this["time"]; ;
            }
            set
            {
                if (!this.ContainsKey("time"))
                    this.Add("time", value);
                else
                    this["time"] = value;
            }
        }
    }
}
