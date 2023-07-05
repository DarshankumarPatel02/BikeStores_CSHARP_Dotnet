using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BikeStores_CSHARPProject
{
    public partial class FormAMD : Form
    {
        public FormAMD()
        {
            InitializeComponent();
        }
        //During form load i have set property of modify and delete to disable 

        private Customer customer;

        private void Exit_Click(object sender, EventArgs e)
        {
            //close Form
            this.Close();
        }
        //filling textboxes.
        private void DisplayCustomer()
        {
            FirstNameBox.Text = customer.first_name;
            LastNameBox.Text = customer.last_name;
            //PhoneBox.Text = customer.phone;
            EmailBox.Text = customer.email;
            streetBox.Text = customer.street;
            CityBox.Text = customer.city;
            StateBox.Text = customer.state;
            ZipCodeBox.Text = customer.zip_code;
            Add.Enabled = true;
            Modify.Enabled = true;
            Delete.Enabled = true;
        }
        private void Add_Click(object sender, EventArgs e)
        {
            //New form FormAddModify Pop-up 
            FormAddModify addCustomerForm = new FormAddModify();
            //If click on Add Boolean set to true so that we know that we are adding new customer
            addCustomerForm.addCustomer = true;
            DialogResult result = addCustomerForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                customer = addCustomerForm.customer;
                CustIDBox.Text = customer.customer_id.ToString();
                this.DisplayCustomer();
            }
        }
        private void GetCustomer(int customerID)
        {
            try
            {
                //get customer_info using customer_id with(select) query..
                customer = CustomerDB.GetCustomer(customerID);
            }
            catch (Exception ex)
            {
                //if exception arises
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }
        private void ClearControls()
        {
            //clearing all textbox and enable/disable button
            CustIDBox.Text = "";
            FirstNameBox.Text = "";
            LastNameBox.Text = "";
            //PhoneBox.Text = "";
            EmailBox.Text = "";
            streetBox.Text = "";
            CityBox.Text = "";
            StateBox.Text = "";
            ZipCodeBox.Text = "";
            Add.Enabled = true;
            Modify.Enabled = false;
            Delete.Enabled = false;
            CustIDBox.Select();
        }
        private void Modify_Click(object sender, EventArgs e)
        {
            ////New form FormAddModify Pop-up 
            FormAddModify modifyCustomerForm = new FormAddModify();
            //If click on Modify Boolean set to false for addcustomer so that we know that we are modifying existing customer
            modifyCustomerForm.addCustomer = false;
            modifyCustomerForm.customer = customer;
            DialogResult result = modifyCustomerForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                customer = modifyCustomerForm.customer;
                this.DisplayCustomer();
            }
            else if (result == DialogResult.Retry)
            {
                this.GetCustomer(customer.customer_id);
                if (customer != null)
                    this.DisplayCustomer();
                else
                    this.ClearControls();
            }

        }

        private void Load_Click(object sender, EventArgs e)
        {
            //Getting customer_info if present else display error message
            if (Validator.IsPresent(CustIDBox) &&
                Validator.IsInt32(CustIDBox))
            {
                //converting string to int
                int customerID = Convert.ToInt32(CustIDBox.Text);
                //getting customer_info
                this.GetCustomer(customerID);
                //if not present display error message and clearfields else fill out all textboxes.
                if (customer == null)
                {
                    MessageBox.Show("No customer found with this ID. " +
                         "Please try again.", "Customer Not Found");
                    this.ClearControls();
                }
                else
                    this.DisplayCustomer();
                    
            }

        }
        private void Delete_Click(object sender, EventArgs e)
        {
            //show pop-up again ask to confirm user want to delete customer or not.
            DialogResult result = MessageBox.Show("Delete " + customer.first_name + "?",
               "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    //if not able to delete then show error message pop-up else clear all fields with deleting customer..
                    if (!CustomerDB.DeleteCustomer(customer))
                    {
                        MessageBox.Show("Another user has updated or deleted " +
                            "that customer.", "Database Error");
                        this.GetCustomer(customer.customer_id);
                        if (customer != null)
                            this.DisplayCustomer();
                        else
                            this.ClearControls();
                    }
                    else
                        this.ClearControls();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }
            }
        }
    }
}