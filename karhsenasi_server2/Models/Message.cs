using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace karhsenasi_server2.Models
{
    public class Message
    {
        string id { set; get; }
        string Send_Date { set; get; }
        string Recive_Date { set; get; }
        string Tags { set; get; }
        string Matn { set; get; }
        string Sender_ID { set; get; }
        string Reciver_ID { set; get; }
        bool Readed { set; get; }
        kind Reciver_Type { set; get; }
    }
}