#define Run

using PersonalAccountant;
using PersonalAccountant.Models;
using PersonalAccountant.Views.ToDo;
using PersonalAccountant.Views.Transactions;
using Plugin.Notifications;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using DA = PersonalAccountant.Models.DataAccess.SqliteDA;

namespace PersonalAccountant
{
    public partial class MainPage : TabbedPage
    {
        //List<Transaction> list;
        public ObservableCollection<ToDo> ToDoCollection { get; set; }
            = new ObservableCollection<ToDo>();
        public ObservableCollection<Transaction> TransactionCollection { get; set; }
            = new ObservableCollection<Transaction>();
        public MainPage()
        {
            //Title = "Title".GetString();
            //FlowDirection = Values.FlowDirection;
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
#if Run
            TransactionCollection.ReFill(DA.GetTransactions().OrderByDescending(x => x.TransactionDate));
            ToDoCollection.ReFill(DA.GetToDoList());
#endif
            CalculateTransactions();
            ToDoListView.ItemsSource = ToDoCollection;
            TransactionsListView.ItemsSource = TransactionCollection;
            UpdateProgressValue();
        }

        void CalculateTransactions()
        {
            Values.Expence = 0;
            Values.Income = 0;
            foreach (var item in TransactionCollection)
            {
                if (item.Type == 0)
                    Values.Expence += item.Value;
                else
                    Values.Income += item.Value;
            }
        }

        void UpdateProgressValue()
        {
            Values.Balance = Values.Income - Values.Expence;
            IncomeLb.Text = Values.Income.ToString("C");
            ExpenceLb.Text = Values.Expence.ToString("C");
            BalanceLb.Text = Values.Balance.ToString("C");
            ProgressRing.Progress = Values.Income / (Values.Expence + Values.Income);
        }

        void HandelResponse(string response, ToDo item)
        {
            switch (response)
            {
                case "Cancel": break;
                case "Edit": break;
                case "Perform Transaction": break;
                case "Delete": break;
            }
        }

        private async void ToDoListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                var item = e.SelectedItem as ToDo;
                var response = await DisplayActionSheet($"{item.Title}", "Cancel", "Delete", "Edit", "Perform Transaction");
                HandelResponse(response, item);
                ToDoListView.SelectedItem = null;
            }
        }
        private void TransactionsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
                TransactionsListView.SelectedItem = null;
        }

        private async void AddToolbarItem_Activated(object sender, EventArgs e)
        {
            var add = VTransaction.Add();
            await Navigation.PushModalAsync(new NavigationPage(add));
            while (!add.Done)
            {
                await Task.Delay(100);
            }
            if (add.IsInserted)
            {
                TransactionCollection.Add(add.Transaction);
                CalculateTransactions();
                UpdateProgressValue();
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var add = new VToDo();
            await Navigation.PushModalAsync(new NavigationPage(add));
            while (!add.Done)
            {
                await Task.Delay(100);
            }
            ///////
            //if (add.IsInserted)
            //{
            //    TransactionCollection.Add(add.Transaction);
            //    CalculateTransactions();
            //    UpdateProgressValue();
            //}
        }


        private void ToDoListView_Refreshing(object sender, EventArgs e)
        {

        }

        private async void EditMenuItem_Clicked(object sender, EventArgs e)
        {
            var transaction = (sender as MenuItem).CommandParameter as Transaction;
            var edit = VTransaction.Edit(transaction);
            await Navigation.PushModalAsync(new NavigationPage(edit));
            while (!edit.Done)
            {
                await Task.Delay(100);
            }
            if (edit.IsInserted)
            {
                transaction = edit.Transaction;
                TransactionCollection.ReFill(TransactionCollection.OrderByDescending(x => x.TransactionDate).ToList());
                CalculateTransactions();
                UpdateProgressValue();
            }
        }

        private async void DeleteMenuItem_Clicked(object sender, EventArgs e)
        {
            var transaction = (sender as MenuItem).CommandParameter as Transaction;
            var response = await DisplayAlert("Warning!",
                $"Are you sure you want to delete this Transaction\n -Title: {transaction.Title}\n -Shourt Description: {transaction.Description}\n -Value: {transaction.Value.ToString("C")}\n -Transaction Date: {transaction.TransactionDate.ToString("dd-MM-yyy")}",
                "Delete",
                "Cancel");
            if (response)
            {
                TransactionCollection.Remove(transaction);
                DA.Delete(transaction);
                CalculateTransactions();
                UpdateProgressValue();
            }
        }
    }
}
