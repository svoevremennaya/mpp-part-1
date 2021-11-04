using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogBuffer
{
    class Message
    {
        public enum MessageType
        {
            Error,
            Warning,
            Information
        }

        public MessageType type;
        public string text;

        public Message(MessageType type, string text)
        {
            this.type = type;
            this.text = text;
        }

        public override string ToString()
        {
            StringBuilder msgStr = new StringBuilder();
            switch (type)
            {
                case MessageType.Error:
                    msgStr.Append("Error ");
                    break;
                case MessageType.Warning:
                    msgStr.Append("Warning ");
                    break;
                case MessageType.Information:
                    msgStr.Append("Information ");
                    break;
            }

            msgStr.Append(text);
            return msgStr.ToString();
        }
    }
}
