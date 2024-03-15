using System;
using System.Text.RegularExpressions;
using System.Windows;

namespace FilozopLab02.UserInfoProject.Models
{
    class Person
    {
        #region Fields
        private string _firstName;
        private string _lastName;
        private string _emailAddress;
        private DateTime _dateOfBirth;

        private readonly string[] chineseZodiacSign =
        { "Monkey",
           "Rooster",
           "Dog",
           "Pig",
           "Rat",
           "Ox",
           "Tiger",
           "Rabbit",
           "Dragon",
           "Snake",
           "Horse",
           "Goat"
        };

        #endregion

        #region Properties
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;

            }
        }
        public string EmailAddress
        {
            get
            {
                return _emailAddress;
            }
            set
            {
                    _emailAddress = value;
            }
        }

        private bool IsValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }

        public DateTime DateOfBirth
        {
            get
            {
                return _dateOfBirth.Date;
            }
            set
            {
                _dateOfBirth = value;
            }
        }
        private bool _isAdult;
        private string _westernZodiacSign;
        private string _chineseZodiacSign;
        private bool _isBirthday;
        public bool IsAdult
        {
            get 
            {
                return _isAdult; 
            }
            private set 
            {
                _isAdult = value; 
            }
        }

        public string WesternSign
        {
            get 
            {
                return _westernZodiacSign; 
            }
            private set 
            {
                _westernZodiacSign = value; 
            }
        }

        public string ChineseSign
        {
            get 
            {
                return _chineseZodiacSign; 
            }
            private set 
            {
                _chineseZodiacSign = value; 
            }
        }

        public bool IsBirthday
        {
            get 
            {
                return _isBirthday;
            }
            private set 
            {
                _isBirthday = value; 
            }
        }

        #endregion

        #region Methods
        private int CountUserAge()
        {
            var todayDate = DateTime.Today;
            int age = todayDate.Year - DateOfBirth.Year;
            if (todayDate.Month < _dateOfBirth.Month || (todayDate.Month == _dateOfBirth.Month && todayDate.Day < _dateOfBirth.Day))
            {
                age--;
            }
            return age;
        }

        private string ZodiacWestern()
        {
            var day = DateOfBirth.Day;
            var month = DateOfBirth.Month;

            if ((month == 1 && day <= 19) || (month == 12 && day >= 22))
            {
                return "Capricorn";
            }
            else if ((month == 1 && day >= 20) || (month == 2 && day <= 18))
            {
                return "Aquarius";
            }
            else if ((month == 2 && day >= 19) || (month == 3 && day <= 20))
            {
                return "Pisces";
            }
            else if ((month == 3 && day >= 21) || (month == 4 && day <= 19))
            {
                return "Aries";
            }
            else if ((month == 4 && day >= 20) || (month == 5 && day <= 20))
            {
                return "Taurus";
            }
            else if ((month == 5 && day >= 21) || (month == 6 && day <= 20))
            {
                return "Gemini";
            }
            else if ((month == 6 && day >= 21) || (month == 7 && day <= 22))
            {
                return "Cancer";
            }
            else if ((month == 7 && day >= 23) || (month == 8 && day <= 22))
            {
                return "Leo";
            }
            else if ((month == 8 && day >= 23) || (month == 9 && day <= 22))
            {
                return "Virgo";
            }
            else if ((month == 9 && day >= 23) || (month == 10 && day <= 22))
            {
                return "Libra";
            }
            else if ((month == 10 && day >= 23) || (month == 11 && day <= 21))
            {
                return "Scorpio";
            }
            else if ((month == 11 && day >= 22) || (month == 12 && day <= 21))
            {
                return "Sagittarius";
            }
            else
            {
                return "Unknown";
            }
        }

        private string ZodiacChinese()
        {
            var year = DateOfBirth.Year;
            return chineseZodiacSign[year % 12];
        }

        private bool TodayIsBirthday()
        {
            var currentDay = DateTime.Today;
            return DateOfBirth.Day == currentDay.Day && DateOfBirth.Month == currentDay.Month;
        }

        public bool DateIsValid()
        {
            var userAge = CountUserAge();

            if (userAge < 0 || userAge > 135 || !IsValidEmail(EmailAddress))
            {
                return false;
            }
            return true;
        }
        public string ValidationError()
        {
            var userAge = CountUserAge();

            if (userAge < 0)
                return "You're not born yet";
            if (userAge > 135)
                return "You're probably dead";
            if (!IsValidEmail(EmailAddress))
                return "Your email is invalid";

            return "Another error";
        }

        #endregion

        #region Constructors
        public Person(string name, string lastname, string email, DateTime birthday)
        {
            FirstName = name;
            LastName = lastname;
            EmailAddress = email;
            DateOfBirth = birthday;

            IsAdult = CountUserAge() >= 18;
            WesternSign = ZodiacWestern();
            ChineseSign = ZodiacChinese();
            IsBirthday = TodayIsBirthday();
        }

        public Person(string name, string lastname, string emailAddress)
        {
            FirstName = name;
            LastName = lastname;
            EmailAddress = emailAddress;
            DateOfBirth = DateTime.Today;
        }

        public Person(string name, string lastname, DateTime birthday)
        {
            FirstName = name;
            LastName = lastname;
            EmailAddress = "defaultemail@ukma.edu.ua";
            DateOfBirth = birthday;
        }
        #endregion

        public string FirstNameString()
        {
            return FirstName;
        }

        public string SurnameString()
        {
            return LastName;
        }

        public string EmailAddressString()
        {
            return EmailAddress;
        }

        public string BirthdayDateString()
        {
            return $"{DateOfBirth.Day}/{DateOfBirth.Month}/{DateOfBirth.Year}";
        }

        public string IsAdultString()
        {
            return $"{IsAdult}";
        }

        public string AgeString()
        {
            return $"{CountUserAge()}";
        }

        public string WesternZodiacString()
        {
            return WesternSign;
        }

        public string ChineseZodiacString()
        {
            return ChineseSign;
        }

    }
}