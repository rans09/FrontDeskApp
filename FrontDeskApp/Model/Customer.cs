using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace FrontDeskApp.Model
{
    public class Customer : INotifyPropertyChanged
    {
        private int customerId;
        private string firstName;
        private string lastName;
        private string phoneNumber;
        private int smallBox;
        private int mediumBox;
        private int largeBox;

        public event PropertyChangedEventHandler PropertyChanged;

        public int CustomerId
        {
            get => customerId;
            set
            {
                customerId = value;
                OnPropertyChanged("CustomerId");
            }
        }
        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }
        public string LastName
        {
            get => lastName;
            set
            {
                lastName = value;
                OnPropertyChanged("LastName");
            }
        }
        public string PhoneNumber
        {
            get => phoneNumber;
            set
            {
                phoneNumber = value;
                OnPropertyChanged("PhoneNumber");
            }
        }

        public int SmallBox
        {
            get => smallBox;
            set
            {
                smallBox = value;
                OnPropertyChanged("SmallBox");
            }
        }

        public int MediumBox
        {
            get => mediumBox;
            set
            {
                mediumBox = value;
                OnPropertyChanged("MediumBox");
            }
        }

        public int LargeBox
        {
            get => largeBox;
            set
            {
                largeBox = value;
                OnPropertyChanged("LargeBox");
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }


}
