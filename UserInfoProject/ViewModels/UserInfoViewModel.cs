using FilozopLab02.UserInfoProject.Models;
using FilozopLab02.UserInfoProject.Tools;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace FilozopLab02.UserInfoProject.ViewModels
{
    class UserInfoViewModel : INotifyPropertyChanged
    {
        #region Fields
        private Person _person;
        private string _name;
        private string _surname;
        private string _email;
        private DateTime _date;

        private string _userFirstName = "";
        private string _userSurname = "";
        private string _userEmail = "";
        private string _userBirthday = "";
        private string _userIsAdult = "";
        private string _userAge = "";
        private string _userWesternZodiac = "";
        private string _userChineseZodiac = "";
        private bool _enableButton = true;
        private RelayCommand<object> _proceedCommand;
        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion

        #region Properties
        public string Name
        {
            get 
            {
                return _name; 
            }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Surname
        {
            get 
            {
                return _surname; 
            }
            set
            {
                _surname = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public DateTime Date
        {
            get 
            {
                return _date; 
            }
            set
            {
                _date = value;
                OnPropertyChanged();
            }
        }

        public Person Person
        {
            get 
            {
                return _person; 
            }
            set
            {
                _person = value;
                OnPropertyChanged();
            }
        }

        public string UserName
        {
            get
            {
                return _userFirstName;
            }
            set
            {
                _userFirstName = value;
                OnPropertyChanged();
            }
        }
        public string UserSurname
        {
            get
            {
                return _userSurname;
            }
            set
            {
                _userSurname = value;
                OnPropertyChanged();
            }
        }

        public string UserEmail
        {
            get
            {
                return _userEmail;
            }
            set
            {
                _userEmail = value;
                OnPropertyChanged();
            }
        }
        public string UserBirthday
        {
            get
            {
                return _userBirthday;
            }
            set
            {
                _userBirthday = value;
                OnPropertyChanged();
            }
        }
        public string UserIsAdult
        {
            get
            {
                return _userIsAdult;
            }
            set
            {
                _userIsAdult = value;
                OnPropertyChanged();
            }
        }
        public string UserAge
        {
            get
            {
                return _userAge;
            }
            set
            {
                _userAge = value;
                OnPropertyChanged();
            }
        }
        public string UserWesternZodiac
        {
            get
            {
                return _userWesternZodiac;
            }
            set
            {
                _userWesternZodiac = value;
                OnPropertyChanged();
            }
        }
        public string UserChineseZodiac
        {
            get
            {
                return _userChineseZodiac;
            }
            set
            {
                _userChineseZodiac = value;
                OnPropertyChanged();
            }
        }

        public bool ProceedEnabled
        {
            get 
            {
                return _enableButton; 
            }
            set
            {
                _enableButton = value;
                OnPropertyChanged();
            }
        }
        #endregion

        private void InformationProceedCommand(object obj)
        {
            UserName = "";
            UserSurname = "";
            UserEmail = "";
            UserBirthday = "";
            UserIsAdult = "";
            UserAge = "";
            UserWesternZodiac = "";
            UserChineseZodiac = "";

            Task.Run(() =>
            {
                Person = new Person(Name, Surname, Email, Date);
                string validationMessage = Person.ValidationError();
                if (Person.DateIsValid())
                {
                    UserName = Person.FirstNameString();
                    UserSurname = Person.SurnameString();
                    UserEmail = Person.EmailAddressString();
                    UserBirthday = Person.BirthdayDateString();
                    UserIsAdult = Person.IsAdultString();
                    UserAge = Person.AgeString();
                    UserWesternZodiac = Person.WesternZodiacString();
                    UserChineseZodiac = Person.ChineseZodiacString();
                    if (Person.IsBirthday)
                    {
                        MessageBox.Show("It is your birthday!");
                    }
                }
                else
                {
                    MessageBox.Show(validationMessage);
                }
            });
        }


        private bool CanExecute()
        {
            return !string.IsNullOrWhiteSpace(Name)
                && !string.IsNullOrWhiteSpace(Surname)
                && !string.IsNullOrWhiteSpace(Email)
                && Date != default(DateTime);
        }


        public RelayCommand<object> ProceedCommand
        {
            get
            {
                return _proceedCommand ??= new RelayCommand<object>(InformationProceedCommand, _ => CanExecute());
            }
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}