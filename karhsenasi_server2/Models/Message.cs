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

        public static string Current_Date()
        {
            return DateTime.Now.ToString("yyyy:MM:dd:hh:mm:ss");
        }

        public Message()
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