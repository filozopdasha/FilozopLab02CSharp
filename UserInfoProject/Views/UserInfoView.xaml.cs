using System.Windows.Controls;
using FilozopLab02.UserInfoProject.ViewModels;
using System;

namespace FilozopLab02.UserInfoProject.Views
{
    /// <summary>
    /// Interaction logic for UserDataView.xaml
    /// </summary>
    public partial class UserInfoView : UserControl
    {
        private readonly UserInfoViewModel _userInfoViewModel;
        public UserInfoView()
        {
            InitializeComponent();
            _userInfoViewModel = new UserInfoViewModel();
            DataContext = _userInfoViewModel; 
        }

        private void SelectedDateChangedFromDatePicker(object sender, SelectionChangedEventArgs e)
        {
            DateTime? chosenDate = datePicker.SelectedDate;
            if (chosenDate.HasValue)
                _userInfoViewModel.Date = chosenDate.Value;
        }
    }
}