using PersonalAccountant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DA = PersonalAccountant.Models.DataAccess.SqliteDA;

namespace PersonalAccountant.Views.Transactions
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VTransaction : ContentPage
    {
        public Transaction Transaction { get; set; }
        public bool Done { get; private set; } = false;
        public bool IsInserted { get; set; } = false;
        public bool Add_Edit { get; set; }

        public VTransaction()
        {
            InitializeComponent();
            Transaction = new Transaction();
            Add_Edit = true;
        }
        private VTransaction(Transaction transaction)
        {
            InitializeComponent();
            Transaction = transaction;
            Add_Edit = false;
            PresentTransaction(transaction);
        }
        public static VTransaction Edit(Transaction transaction)
            => new VTransaction(transaction);

        public static VTransaction Add()
            => new VTransaction();

        void PresentTransaction(Transaction transaction)
        {
            TitleCell.Text = transaction.Title;
            DescriptionCell.Text = transaction.Description;
            ValueCell.Text = transaction.Value.ToString();
            TypeSW.IsToggled = transaction.Type.ToBool();
            TransactionDate.Date = transaction.TransactionDate;
        }

        String warning = "This Fields Can't Be Empty!";
        String wMessage = "";
        bool DataIsValid()
        {
            var valid = true;

            if (TitleCell.Text.IsNull()) { wMessage += "\n -Transaction Title\n"; valid = false; }
            if (ValueCell.Text.IsNull()) { wMessage += "\n -Transaction Value\n"; valid = false; }

            return valid;
        }

        private async void DoneButton_Clicked(object sender, EventArgs e)
        {

            if (DataIsValid())
            {
                Transaction.Title = TitleCell.Text;
                Transaction.Description = DescriptionCell.Text;
                Transaction.Value = Convert.ToDouble(ValueCell.Text);
                Transaction.Type = TypeSW.IsToggled.ToInt();
                Transaction.TransactionDate = TransactionDate.Date;
                Transaction.InsertDate = DateTime.Now;
                if (Add_Edit)
                    DA.Insert(Transaction);
                else
                    DA.Update(Transaction);
                IsInserted = true;
                await Navigation.PopModalAsync();
                Done = true;
            }
            else
            {
                await DisplayAlert("Some Thing went Wrong!", warning + wMessage, "Ok");
                wMessage = "";
            }
        }

        private async void CancelButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
            Done = true;
        }

        protected override bool OnBackButtonPressed()
        {
            Done = true;
            return base.OnBackButtonPressed();
        }

        private void TypeSW_Toggled(object sender, ToggledEventArgs e)
        {
            TypeLb.Text = e.Value.ToType();
            TypeLb.TextColor = e.Value.ToColor();
        }
    }
}