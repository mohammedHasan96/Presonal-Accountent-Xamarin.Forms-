using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PersonalAccountant.Views.ToDo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VToDo : ContentPage
    {
        public bool Done { get; private set; } = false;

        public VToDo()
        {
            InitializeComponent();
        }

        private void DoneButton_Clicked(object sender, EventArgs e)
        {

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

        private void ToDoDate_DateSelected(object sender, DateChangedEventArgs e)
        {
            NotifyTime.Time = new TimeSpan(9,0,0);
            var date = e.NewDate;
            var year = date.Year;
            var month = date.Month;
            var day = date.Day;
            if (date.Day == 1)
            {
                if (date.Month == 1)
                {
                    year -= 1;
                    month = 12;
                }
                else
                    month -= 1;
                day = DateTime.DaysInMonth(year, month);
            }
            else
            {
                day -= 1;
            }
            NotifyDate.Date = new DateTime(year, month, day);
            


        }
    }
}