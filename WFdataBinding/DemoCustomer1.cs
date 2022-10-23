﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WFdataBinding
{
    // This is a simple customer class that
    // implements the IPropertyChange interface.
    public class DemoCustomer1 : INotifyPropertyChanged
    {
        // These fields hold the values for the public properties.
        // private Guid idValue = Guid.NewGuid();
      //  static int idd;
       private Guid idValue = Guid.NewGuid();
       
        private string customerNameValue = String.Empty;
        private string phoneNumberValue = String.Empty;

        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                MessageBox.Show($"{DateTime.Now.ToString()}\n{propertyName}\n{this.idValue}");  
            }
        }

        // The constructor is private to enforce the factory pattern.
        public DemoCustomer1()
        {
            customerNameValue = "Customer";
            phoneNumberValue = "(312)555-0100";
        }
       

        // This is the public factory method.
        public static DemoCustomer1 CreateNewCustomer()
        {
            return new DemoCustomer1();
        }

        // This property represents an ID, suitable
        // for use as a primary key in a database.
        public Guid ID
        {
            get
            {
                return this.idValue;
            }
        }

        public string CustomerName
        {
            get
            {
                return this.customerNameValue;
            }

            set
            {
                if (value != this.customerNameValue)
                {
                    this.customerNameValue = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string PhoneNumber
        {
            get
            {
                return this.phoneNumberValue;
            }

            set
            {
                if (value != this.phoneNumberValue)
                {
                    this.phoneNumberValue = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
