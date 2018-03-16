using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace karhsenasi_server2.Models
{
    public class Repo
    {
       
        // Constants !!
        private string LIMIT = "100"; // limiting Number OF Retrived From Database !! _ For Foture Speed Enhance!
        private string connect_str = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Morfi\\Desktop\\Karshenasi_Server\\karhsenasi_server2\\App_Data\\DB.mdf;Integrated Security=True";
        private static string FirstName = "FirstName";
        private static string LastName = "LastName";
        private static string Id = "ID";
        private static string Tip = "Tip";
        private static string pass = "pass";
        private static string pass_hash = "pass_hash";
        private static string Kart_meli = "Kart_meli";
        private static string City = "City";
        private static string Sender = "Sender";
        private static string Reciver = "Reciver";
        private static string Reciver_Type = "Reciver_Type";
        private static string Tagss = "Tags";
        private static string Matn = "Matn";
        private static string Send_Date = "Send_Date";
        private static string Read_Date = "Read_Date";
        private static string Readed = "Readed";
        private static string Std_ID = "Std_ID";
        private static string Post_ID = "Post_ID";
        private static string Birth_Date = "Birth_Date";
        private static string Adress = "Adress";
        private static string Roozane_Shabane = "Roozane_Shabane";
        private static string Father_Name = "Father_Name";
        public static string Faild = "fail";
        public static string Sucsess = "sucses";
        public static string NON = "non";
        public static string YES = "yes";
        public static string NO = "no";


        private static string BuildConnectionString(string dataSource, string userName, string userPassword)
        {
            SqlConnectionStringBuilder builder =
                new SqlConnectionStringBuilder();
            builder.DataSource = dataSource;
            builder.UserID = userName;
            builder.Password = userPassword;
            Console.WriteLine(builder.ConnectionString);
            return builder.ConnectionString;
        }

        public RemoveUser() { };
        public List<User> Users() {
            List<User> users = new List<User>();
            try {
                SqlConnection con = new SqlConnection(connect_str);
                con.Open();
                SqlDataReader reader = new SqlCommand("select * from Users", con).ExecuteReader();
                if (reader.HasRows)
                {
                    User m = new User();
                    while (reader.Read())
                    {
                        m.FName = reader[FirstName].ToString();
                        m.LName = reader[LastName].ToString();
                        m.Type = (kind)Enum.Parse(typeof(kind), reader[Tip].ToString());
                        m.Pass = reader[pass].ToString();
                        m.Pass_hash = reader[pass_hash].ToString();
                        m.Kaet_meli = reader[Kart_meli].ToString();
                        m.id = reader[Id].ToString();
                    }
                    users.Add(m);
                }
                con.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return users;
        }
        public string AddUser (User user) {
            string val1 = "INSERT INTO Users (Tip , LastName , FirstName , pass , pass_hash , Kart_meli)";
            string val2 = " VALUES("+user.Type.GetTypeCode().ToString()+" ,"+user.LName+","+user.FName+","+user.Pass+","+user.Pass_hash+","+user.Kaet_meli+")";

            try
            {
                SqlConnection con = new SqlConnection(connect_str);
                con.Open();
                SqlCommand Command = new SqlCommand(val1 + val2, con);
                int row = Command.ExecuteNonQuery();
                con.Close();
                return row.ToString();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return Faild;
        }
        public string AddUser (string FName , string LName , kind tip , string pass) {
            string val1 = "INSERT INTO Users (Tip , LastName , FirstName , pass , pass_hash , Kart_meli)";
            string val2 = " VALUES(" + tip.GetTypeCode().ToString() + " ," + LName + "," + FName + "," + pass + "," + "" + "," + "" + ")";

            try
            {
                SqlConnection con = new SqlConnection(connect_str);
                con.Open();
                SqlCommand Command = new SqlCommand(val1 + val2, con);
                int row = Command.ExecuteNonQuery();
                con.Close();
                return row.ToString();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return Faild;
        }
        public List<Message> Messages() {
            List<Message> messages = new List<Message>();
            try
            {
                SqlConnection con = new SqlConnection(connect_str);
                con.Open();
                SqlDataReader reader = new SqlCommand("select * from Message", con).ExecuteReader();
                if (reader.HasRows)
                {
                    Message m = new Message();
                    while (reader.Read())
                    {
                        m.Matn = reader[Matn].ToString();
                        m.Sender_ID = reader[Sender].ToString();
                        m.Reciver_Type = (kind)Enum.Parse(typeof(kind), reader[Tip].ToString());
                        m.Reciver_ID = reader[Reciver].ToString();
                        m.Tags = reader[Tagss].ToString();
                        m.Send_Date = reader[Send_Date].ToString();
                        m.Recive_Date = reader[Read_Date].ToString();
                        string Ri = reader[Readed].ToString();
                        if (Ri.Equals(YES))
                        {
                            m.Readed = true;
                        }
                        else
                        {
                            m.Readed = false;
                        }
                        
                    }
                    messages.Add(m);
                }
                con.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return messages;
        }
        public string AddMessage() { }
        public string RemoveMessage() { }
        public string AddTag() { }
        public string RemoveTag() { }
        public void Tags() { }
        public void Porperties() { }
        public string AddProperties() { }
        public string RemoveProperties() { }



    }
}