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
        private static Repo  Rep;
       
        // Constants !!
        private string LIMIT = "100"; // limiting Number OF Retrived From Database !! _ For Foture Speed Enhance!
        private string connect_str = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=I:\\karshenasi_Project\\Karshenasi_Server\\karhsenasi_server2\\App_Data\\Database1.mdf;Integrated Security=True";

        internal object Users(string iD)
        {
            throw new NotImplementedException();
        }

        internal object Messages(User user)
        {
            throw new NotImplementedException();
        }

        private const string FirstName = "FirstName";
        private const string LastName = "LastName";
        private const string Id = "ID";
        private const string Tip = "Tip";
        private const string pass = "pass";
        private const string pass_hash = "pass_hash";
        private const string Kart_meli = "Kart_meli";
        private const string City = "City";
        private const string Sender = "Sender";
        private const string Reciver = "Reciver";
        private const string Reciver_Type = "Reciver_Type";

        internal object RemoveUser(User user)
        {
            throw new NotImplementedException();
        }

        private const string Tagss = "Tags";
        private const string Matn = "Matn";
        private const string Send_Date = "Send_Date";
        private const string Read_Date = "Read_Date";

        internal object RemoveMessage(Message message)
        {
            throw new NotImplementedException();
        }

        internal object UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        private const string Readed = "Readed";
        private const string Std_ID = "Std_ID";
        private const string Post_ID = "Post_ID";
        private const string Birth_Date = "Birth_Date";
        private const string Adress = "Adress";

        internal object UpdateMessage(Message message)
        {
            throw new NotImplementedException();
        }

        private const string Roozane_Shabane = "Roozane_Shabane";
        private const string Father_Name = "Father_Name";
        public const string Faild = "fail";
        public const string Sucsess = "sucses";
        public const string NON = "non";
        public const string YES = "yes";
        public const string NO = "no";
        public const string OperationFaild = "OPE_FAILD_Check_THINGS";

        public static Repo GetInstance() {
            if (Rep == null)
            {
                Rep = new Repo();
            }
            return Rep;
        }

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

        public void RemoveUser() {}
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
        public string AddMessage(Message message) {
            Values val = new Values();
            // Be aware of Kind Type of !!
            string red = NO;
            if (message.Readed)
            {
                red = YES;
            }
            val.vals.Add(new ValObj (Sender , message.Sender_ID ,Values.integer ));
            val.vals.Add(new ValObj(Reciver, message.Reciver_ID, Values.integer));
            val.vals.Add(new ValObj(Send_Date, message.Send_Date, Values.nvarchar));
            val.vals.Add(new ValObj(Readed, red , Values.nvarchar));
            val.vals.Add(new ValObj(Matn, message.Matn, Values.nvarchar));
            val.vals.Add(new ValObj(Reciver_Type, message.Reciver_Type.GetTypeCode().ToString(), Values.integer));
            val.vals.Add(new ValObj(Read_Date, message.Recive_Date, Values.nvarchar));
            val.vals.Add(new ValObj(Tagss, message.Tags, Values.nvarchar));

            string query = val.GetQuery(Values.Insert, "Message");

            try
            {
                SqlConnection con = new SqlConnection(connect_str);
                con.Open();
                SqlCommand Command = new SqlCommand(query, con);
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
        public string RemoveMessage() { return NON; }
        public string AddTag() { return NON; }
        public string RemoveTag() { return NON; }
        public void Tags() { }
        public void Porperties() { }
        public string AddProperties() { return NON; }
        public string RemoveProperties() { return NON; }



    }
}