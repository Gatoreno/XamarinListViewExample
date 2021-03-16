﻿using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ListViewExample.Models;
using Xamarin.Forms;

namespace ListViewExample.ViewModels
{
    public class MainViewModel
    {

        public ObservableCollection<Credit> Collection { get; set; }
        public ICommand AddCreditCommand { get;set;}
        public ICommand DeleteCreditCommand { get; set; }
        public MainViewModel()
        {

            Collection = new ObservableCollection<Credit>();
            AddCreditCommand = new Command(() => OnAddCreditCommand());
            DeleteCreditCommand = new Command<Credit>((Credit) => OnDeleteCreditCommand(Credit));

            LoadCollection();
        }

        public void LoadCollection()
        {
            Credit c1 = new Credit() {  Name="Credit card", Number="1234567" };
                       Collection.Add(c1);
        }

        private void OnDeleteCreditCommand(Credit credit)
        {
            var c = credit;
            Collection.Remove(c);
        }

        private void OnAddCreditCommand()
        {
            var generator = new Random();
            var randomNumber = generator.Next(5, 10000000);
            
            Collection.Add(new Credit
            {  Name ="Credit card", Number= randomNumber.ToString()});
        }
    }
}
