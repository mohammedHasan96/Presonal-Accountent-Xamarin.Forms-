using SQLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace PersonalAccountant.Models.DataAccess
{
    public static class SqliteDA
    {
        static readonly String DBPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "PersonalAccountant.db3");
        static SQLiteConnection Connection;
        public static void InitialDB()
        {
            Connection = new SQLiteConnection(DBPath);
            Connection.CreateTable<Transaction>();
            Connection.CreateTable<ToDo>();
        }

        public static List<Transaction> GetTransactions()
        {
            var list = new List<Transaction>();
            var q = Connection.Table<Transaction>().OrderByDescending(x => x.TransactionDate);
            foreach (var item in q)
            {
                list.Add(item);
            }
            return list;
        }

        public static List<ToDo> GetToDoList()
        {
            var list = new List<ToDo>();
            var q = Connection.Table<ToDo>().OrderByDescending(x => x.TransactionDate);
            foreach (var item in q)
            {
                list.Add(item);
            }
            return list;
        }

        public static int Insert(object o)
        {
            return Connection.Insert(o);
        }

        public static int Update(object o)
        {
            return Connection.Update(o);
        }

        public static int Delete(object o)
        {
            return Connection.Delete(o);
        }
    }
}
