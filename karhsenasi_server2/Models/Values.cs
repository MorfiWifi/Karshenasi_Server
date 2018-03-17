using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace karhsenasi_server2.Models
{
    public class Values
    {
        public const string nvarchar = "NVARCHAR(255)";
        public const string int_auto_id = "integer PRIMARY KEY IDENTITY";
        public const string integer = "INTEGER";
        public const string Insert = "INSERT INTO";
        public const string Drop = "DROP TABLE";
        public const string Delet = "DELETE FROM";
        
        public List<ValObj> vals { set; get; }
        
        public static string GetQuery ( string command, string Table , List<ValObj> vals)
        {
            string query = "";
            string query2 = "";

            switch (command)
            {
                case Delet:
                    break;
                case Drop:
                    query = command + " " + Table;
                    break;
                case Insert:
                    query = command + " " + Table+ " (";
                    query2 = " (";
                    for (int i = 0; i < vals.Count-1; i++)
                    {
                        query = query + vals.ElementAt(i).name + " ,";
                        query2 = query2 = vals.ElementAt(i).value + " ,";
                    }
                    query = query + vals.Last().name + " ) VALUES";
                    query = query + query2 + vals.Last().value + " )";
                    break;
                default:
                    query = "";
                    break;
            }
            return query;
        }
        public  string GetQuery(string command, string Table)
        {
            string query = "";
            string query2 = "";

            switch (command)
            {
                case Delet:
                    break;
                case Drop:
                    query = command + " " + Table;
                    break;
                case Insert:
                    query = command + " " + Table + " (";
                    query2 = " (";
                    for (int i = 0; i < vals.Count - 1; i++)
                    {
                        query = query + vals.ElementAt(i).name + " ,";
                        query2 = query2 = vals.ElementAt(i).value + " ,";
                    }
                    query = query + vals.Last().name + " ) VALUES";
                    query = query + query2 + vals.Last().value + " )";
                    break;
                default:
                    query = "";
                    break;
            }
            return query;
        }

    }

    public class ValObj
    {
        public string value { set; get; }
        public string type { set; get; }
        public string name { set; get; }

        public ValObj()
        {
            value = "";
            type = "";
            name = "";
        }

        public ValObj( string name , string val , string typ)
        {
            value = val;
            type = typ;
            this.name = name;
        }
    }
}