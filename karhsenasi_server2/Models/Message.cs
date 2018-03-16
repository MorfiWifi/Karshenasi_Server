using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace karhsenasi_server2.Models
{
    public class Message
    {
        public string id { set; get; }
        public string Send_Date { set; get; }
        public string Recive_Date { set; get; }
        public string Tags { set; get; }
        public string Matn { set; get; }
        public string Sender_ID { set; get; }
        public string Reciver_ID { set; get; }
        public bool Readed { set; get; }
        public kind Reciver_Type { set; get; }

        Message()
        {
            id = "0";
            Send_Date = "";
            Sender_ID = "";
            Reciver_ID = "";
            Reciver_Type = kind.Student;
            Readed = false;
            Matn = "";
            Recive_Date = "";
            Tags = "";
        }
    }
}