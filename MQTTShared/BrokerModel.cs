using System;
using System.Collections.Generic;
using System.Text;

namespace MQTTShared
{
    public class BrokerModel
    {
        public string Url { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public int SSLPort { get; set; }
        public int WebSocketPort { get; set; }
    }
}
