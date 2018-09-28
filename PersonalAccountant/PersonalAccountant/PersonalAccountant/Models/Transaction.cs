using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
namespace PersonalAccountant.Models
{
    public class Transaction : ViewModelBase
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        string _Title;
        [NotNull]
        public String Title
        {
            get => _Title;
            set => Update(value, ref _Title);
        }

        string _Description;
        public String Description
        {
            get => _Description;
            set => Update(value, ref _Description);
        }

        Double _Value = 0;
        [NotNull]
        public Double Value
        {
            get => _Value;
            set => Update(value, ref _Value);
        }

        int _Type = 0;
        [NotNull]
        public int Type
        {
            get => _Type;
            set { Update(value, ref _Type); Color = value.ToColor(); }
        }

        DateTime _Transaction = DateTime.Now;
        [NotNull]
        public DateTime TransactionDate
        {
            get => _Transaction;
            set => Update(value, ref _Transaction);
        }

        DateTime _InsertDate = DateTime.Now;
        public DateTime InsertDate
        {
            get => _InsertDate;
            set => Update(value, ref _InsertDate);
        }
        //
        Color _Color = 1.ToColor();
        [Ignore]
        public Color Color
        {
            get => _Color;
            set => Update(value, ref _Color);
        }
    }

    //public class Transaction
    //{
    //    public int ID { get; set; }
    //    public String Title { get; set; }
    //    public String Description { get; set; }
    //    public double Value { get; set; }
    //    public int Type { get; set; }
    //    public DateTime TransactionDate { get; set; }
    //    public DateTime InsertDate { get; set; }
    //    //
    //    public Color Color { get { return Type.ToColor(); } }

    //}
}
