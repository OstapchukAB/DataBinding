using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

// Change the namespace to the project name.
namespace WFdataBinding
{
    // This form demonstrates using a BindingSource to bind
    // a list to a DataGridView control. The list does not
    // raise change notifications. However the DemoCustomer1 type
    // in the list does.
    public partial class Form3 : Form
    {
        // This button causes the value of a list element to be changed.
        private Button changeItemBtn = new Button();

        // This DataGridView control displays the contents of the list.
        private DataGridView customersDataGridView = new DataGridView();

        // This BindingSource binds the list to the DataGridView control.
        private BindingSource customersBindingSource = new BindingSource();

        public Form3()
        {
            InitializeComponent();

            // Set up the "Change Item" button.
            this.changeItemBtn.Text = "Change Item";
            this.changeItemBtn.Dock = DockStyle.Bottom;
            this.changeItemBtn.Height = 100;
            this.changeItemBtn.Click +=
             new EventHandler(changeItemBtn_Click);
            //this.changeItemBtn.Click +=
            //changeItemBtn_Click;


            this.Controls.Add(this.changeItemBtn);

            // Set up the DataGridView.
            customersDataGridView.Dock = DockStyle.Top;
            this.Controls.Add(customersDataGridView);

            this.Size = new Size(400, 200);
            this.Load += Form3_Load; 
        }

        

        private void Form3_Load(object sender, EventArgs e)
        {
            this.Top = 100;
            this.Left = 100;
            this.Height = 600;
            this.Width = 1000;

            // Create and populate the list of DemoCustomer objects
            // which will supply data to the DataGridView.
            BindingList<DemoCustomer1> customerList = new();
            customerList.Add(DemoCustomer1.CreateNewCustomer());
            customerList.Add(DemoCustomer1.CreateNewCustomer());
            customerList.Add(DemoCustomer1.CreateNewCustomer());

            // Bind the list to the BindingSource.
            this.customersBindingSource.DataSource = customerList;

            // Attach the BindingSource to the DataGridView.
            this.customersDataGridView.DataSource =
                this.customersBindingSource;
        }

        // Change the value of the CompanyName property for the first
        // item in the list when the "Change Item" button is clicked.
        void changeItemBtn_Click(object sender, EventArgs e)
        {
            // Get a reference to the list from the BindingSource.
            BindingList<DemoCustomer1>? customerList =
                this.customersBindingSource.DataSource as BindingList<DemoCustomer1>;

            // Change the value of the CompanyName property for the
            // first item in the list.
            if (customerList == null )
                return;
            customerList[0].CustomerName = "Tailspin Toys";
            customerList[0].PhoneNumber = "(708)555-0150";
        }

    }

    
}
