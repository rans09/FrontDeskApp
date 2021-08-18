using Microsoft.VisualStudio.PlatformUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using FrontDeskApp.Model;
using System.Linq;

namespace FrontDeskApp.ViewModel
{
    class CustomerViewModel
    {
        private ObservableCollection<Customer> CustomerList;

        const int MAX_SMALL_STORAGE = 28;
        const int MAX_MEDIUM_STORAGE = 14;
        const int MAX_LARGE_STORAGE = 12;

        private int availSmallStorage;
        private int availMediumStorage;
        private int availLargeStorage;

        private int totalSmallOccupied;
        private int totalMediumOccupied;
        private int totalLargeOccupied;

        public CustomerViewModel()
        {
            CustomerList = new ObservableCollection<Customer>
            {
                new Customer{CustomerId = 1, FirstName = "Dan", LastName = "Locsin", PhoneNumber = "8700",
                    SmallBox = 1, MediumBox = 2, LargeBox = 3},
                new Customer{CustomerId = 1, FirstName = "Esteban", LastName = "Polo", PhoneNumber = "55555",
                    SmallBox = 3, MediumBox = 3, LargeBox = 3},
            };

            InitialAvailStorage();
        }


        public ObservableCollection<Customer> Customers
        {
            get => CustomerList;
            set => CustomerList = value;
        }

        public int AvailSmallStorageSpace
        {
            get => availSmallStorage;
        }
        public int AvailMediumStorageSpace
        {
            get => availMediumStorage;
        }
        public int AvailLargeStorageSpace
        {
            get => availLargeStorage;
        }

        private int storeSmall;
        private int storeMedium;
        private int storeLarge;
        public int StoreSmall
        {
            set => storeSmall = value;
        }
        public int StoreMedium
        {
            set => storeMedium = value;
        }
        public int StoreLarge
        {
            set => storeLarge = value;
        }

        private RelayCommand addCommand;
        private RelayCommand storeCommand;

        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand(Add);
                }
                return addCommand;
            }
        }

        public ICommand StoreCommand
        {
            get
            {
                if (storeCommand == null)
                {
                    storeCommand = new RelayCommand(Store);
                }
                return storeCommand;
            }
        }

        private void Add(object obj)
        {
            Customer newCustomer = new Customer
            {
                CustomerId = 0,
                FirstName = "<Edit First Name>",
                LastName = "<Edit Last Name>",
                PhoneNumber = "<Edit Phone Number>",
                SmallBox = 0,
                MediumBox = 0,
                LargeBox = 0
            };

            Customers.Add(newCustomer);
        }

        private void Store(object obj)
        {
            if (storeSmall > 0 && storeSmall <= availSmallStorage)
            {
                totalSmallOccupied += storeSmall;
            }
            if (storeMedium > 0 && storeMedium <= availMediumStorage)
            {
                totalSmallOccupied += storeMedium;
            }
            if (storeLarge > 0 && storeLarge <= availLargeStorage)
            {
                totalSmallOccupied += storeLarge;
            }
            CurrentAvailStorage();
        }

        private void InitialAvailStorage()
        {
            totalSmallOccupied = Customers.Sum(a => a.SmallBox);
            availSmallStorage = MAX_SMALL_STORAGE - totalSmallOccupied;

            totalMediumOccupied = Customers.Sum(a => a.MediumBox);
            availMediumStorage = MAX_MEDIUM_STORAGE - totalMediumOccupied;

            totalLargeOccupied = Customers.Sum(a => a.LargeBox);
            availLargeStorage = MAX_LARGE_STORAGE - totalLargeOccupied;
        }

        private void CurrentAvailStorage()
        {
            availSmallStorage -= totalSmallOccupied;

            availMediumStorage -= totalMediumOccupied;

            availLargeStorage -= totalLargeOccupied;
        }
    }
}
