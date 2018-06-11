using BusinessLayer.Entities;
using BusinessLayer.Enums;
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
                orderBindingSource.DataSource = OrderService.GetAll();

                Customer customer = customerBindingSource.Current as Customer;
                Business business = businessBindingSource.Current as Business;
                Order order = orderBindingSource.Current as Order;

                clientOrderBindingSource.DataSource = ClientOrderService.GetClientOrders(customer.CustomerId, ClientType.Customer);
                clientOrderBindingSource1.DataSource = ClientOrderService.GetClientOrders(business.BusinessId, ClientType.Business);

                tcntrlLists.SelectedTab = tpageCustomers;
                tcntrlInfo.SelectedTab = tpageCustomer;

                tpageCustomer.Enabled = false;
                tpageBusiness.Enabled = false;
                tpageOrder.Enabled = false;
                gridCustomerOrders.Enabled = true;
                gridBusinessOrders.Enabled = true;
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // List Buttons
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            tcntrlInfo.SelectedTab = tpageCustomer;
        }

        private void btnAddBusiness_Click(object sender, EventArgs e)
        {
            tcntrlInfo.SelectedTab = tpageBusiness;
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            tcntrlInfo.SelectedTab = tpageOrder;
        }

        // Grid Clicks
        private void gridCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Customer customer = customerBindingSource.Current as Customer;
                tcntrlInfo.SelectedTab = tpageCustomer;

                clientOrderBindingSource.DataSource = ClientOrderService.GetClientOrders(customer.CustomerId, ClientType.Customer);
                gridCustomerOrders.Enabled = true;
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridBusinesses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Business business = businessBindingSource.Current as Business;
                tcntrlInfo.SelectedTab = tpageBusiness;

                clientOrderBindingSource1.DataSource = ClientOrderService.GetClientOrders(business.BusinessId, ClientType.Business);
                gridBusinessOrders.Enabled = true;
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Order order = orderBindingSource.Current as Order;
                tcntrlInfo.SelectedTab = tpageOrder;
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
