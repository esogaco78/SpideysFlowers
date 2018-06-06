using BusinessLayer.Entities;
using Services;
using System;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                customerBindingSource.DataSource = CustomerService.GetAll();
                businessBindingSource.DataSource = BusinessService.GetAll();
                pCustomer.Enabled = false;

                Customer customer = customerBindingSource.Current as Customer;
                Business business = businessBindingSource.Current as Business;
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            pCustomer.Enabled = true;
        }
    }
}
