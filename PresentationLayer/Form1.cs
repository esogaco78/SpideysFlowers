using BusinessLayer.Entities;
using BusinessLayer.Enums;
using Services;
using System;
using System.Windows.Forms;
using System.Linq;
using BusinessLayer.Helpers;

namespace PresentationLayer
{
    public partial class Form1 : Form
    {
        EntityState state = EntityState.Unchanged;

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
                clientBindingSource.DataSource = ClientService.GetAll();

                Customer customer = customerBindingSource.Current as Customer;
                Business business = businessBindingSource.Current as Business;
                Order order = orderBindingSource.Current as Order;
                Client client = clientBindingSource.Current as Client;

                // Set delivery date to order date when delivery date is null
                order = _setDeliveryDate(order);

                clientOrderBindingSource.DataSource = ClientOrderService.GetClientOrders(customer.CustomerId, ClientType.Customer);
                clientOrderBindingSource1.DataSource = ClientOrderService.GetClientOrders(business.BusinessId, ClientType.Business);

                tcntrlLists.SelectedTab = tpageCustomers;
                tcntrlInfo.SelectedTab = tpageCustomer;

                // Set the combo box in orders to be populated with the ClientName string form the binding source
                cboOrderClient.DataSource = ClientService.GetAll().Select(x => x.ClientName).ToList();
                // Set the combo box index the proper client name
                _setOrderComboBoxIndex(order);

                // Setup initial states of pages
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
            btnAdd_Click(sender, e);
        }

        private void btnAddBusiness_Click(object sender, EventArgs e)
        {
            tcntrlInfo.SelectedTab = tpageBusiness;
            btnAdd_Click(sender, e);
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            tcntrlInfo.SelectedTab = tpageOrder;
            btnAdd_Click(sender, e);
        }

        // Grid Clicks
        private void gridCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Customer customer = customerBindingSource.Current as Customer;
                tcntrlInfo.SelectedTab = tpageCustomer;

                clientOrderBindingSource.DataSource = ClientOrderService.GetClientOrders(customer.CustomerId, ClientType.Customer);
                tpageCustomer.Enabled = false;
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
                tpageBusiness.Enabled = false;
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
                order = _setDeliveryDate(order);

                _setOrderComboBoxIndex(order);

                tcntrlInfo.SelectedTab = tpageOrder;
                tpageOrder.Enabled = false;
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Add - Edit - Save - Cancel Buttons
        private void btnAdd_Click(object sender, EventArgs e)
        {
            state = EntityState.Added;

            if (tcntrlInfo.SelectedTab == tpageCustomer)
            {
                _clearCustomer();
                tpageCustomer.Enabled = true;
                tpageBusiness.Enabled = false;
                tpageOrder.Enabled = false;
                txtCustomerFirstName.Focus();
            }
            else if (tcntrlInfo.SelectedTab == tpageBusiness)
            {
                _clearBusiness();
                tpageBusiness.Enabled = true;
                tpageCustomer.Enabled = false;
                tpageBusiness.Enabled = false;
                txtBusinessName.Focus();

            }
            else if (tcntrlInfo.SelectedTab == tpageOrder)
            {
                _clearOrder();
                tpageOrder.Enabled = true;
                tpageCustomer.Enabled = false;
                tpageBusiness.Enabled = false;
                cboOrderClient.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (state == EntityState.Changed)
            {
                if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to cancel editting?  All progress will be lost.", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (tcntrlInfo.SelectedTab == tpageCustomer)
                    {
                        _clearCustomer();
                        tpageCustomer.Enabled = false;
                        tpageBusiness.Enabled = false;
                        tpageOrder.Enabled = false;
                    }
                    else if (tcntrlInfo.SelectedTab == tpageBusiness)
                    {
                        _clearBusiness();
                        tpageBusiness.Enabled = false;
                        tpageCustomer.Enabled = false;
                        tpageBusiness.Enabled = false;

                    }
                    else if (tcntrlInfo.SelectedTab == tpageOrder)
                    {
                        _clearOrder();
                        tpageOrder.Enabled = false;
                        tpageCustomer.Enabled = false;
                        tpageBusiness.Enabled = false;
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            state = EntityState.Changed;

            if (tcntrlInfo.SelectedTab == tpageCustomer)
            {
                tpageCustomer.Enabled = true;
                tpageBusiness.Enabled = false;
                tpageOrder.Enabled = false;
                txtCustomerFirstName.Focus();
            }
            else if (tcntrlInfo.SelectedTab == tpageBusiness)
            {
                tpageBusiness.Enabled = true;
                tpageCustomer.Enabled = false;
                tpageBusiness.Enabled = false;
                txtBusinessName.Focus();

            }
            else if (tcntrlInfo.SelectedTab == tpageOrder)
            {
                tpageOrder.Enabled = true;
                tpageCustomer.Enabled = false;
                tpageBusiness.Enabled = false;
                cboOrderClient.Focus();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool success = false;
            if (state == EntityState.Changed || state == EntityState.Added)
            {

                if (tcntrlInfo.SelectedTab == tpageCustomer)
                {
                    if (_validateCustomer())
                    {
                        try
                        {
                            customerBindingSource.EndEdit();
                            Customer customer = customerBindingSource.Current as Customer;
                            customer = CustomerService.Save(customer, state);
                            gridCustomers.Refresh();
                            success = true;
                        }
                        catch (Exception ex)
                        {
                            MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else if (tcntrlInfo.SelectedTab == tpageBusiness)
                {
                    if (_validateBusiness())
                    {
                        try
                        {
                            businessBindingSource.EndEdit();
                            Business business = businessBindingSource.Current as Business;
                            business = BusinessService.Save(business, state);
                            gridBusinesses.Refresh();
                            success = true;
                        }
                        catch (Exception ex)
                        {
                            MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else if (tcntrlInfo.SelectedTab == tpageOrder)
                {
                    if (_validateOrder())
                    {
                        try
                        {
                            orderBindingSource.EndEdit();
                            Order order = orderBindingSource.Current as Order;
                            order = OrderService.Save(order, state);
                            gridOrders.Refresh();
                            success = true;
                        }
                        catch (Exception ex)
                        {
                            MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }
            }

            if (success)
            {
                state = EntityState.Unchanged;
                tpageCustomer.Enabled = false;
                tpageBusiness.Enabled = false;
                tpageOrder.Enabled = false;
            }
        }

        #region Helpers

        private Order _setDeliveryDate(Order order)
        {
            if (!order.DeliveryDate.HasValue)
            {
                order.DeliveryDate = order.OrderDate;
            }

            return order;
        }

        private void _setOrderComboBoxIndex(Order order)
        {
            cboOrderClient.SelectedIndex = cboOrderClient.FindString(order.ClientName);
        }

        #endregion

        #region ClearOuts

        // Clear out text fields
        private void _clearCustomer()
        {
            txtCustomerFirstName.Text = null;
            txtCustomerLastName.Text = null;
            txtCustomerStreet.Text = null;
            txtCustomerCity.Text = null;
            txtCustomerRegion.Text = null;
            txtCustomerCode.Text = null;
            txtCustomerPhone.Text = null;
            txtCustomerEmail.Text = null;

            gridCustomerOrders.DataSource = null;
        }

        private void _clearBusiness()
        {
            txtBusinessName.Text = null;
            txtBusinessContact.Text = null;
            txtBusinessStreet.Text = null;
            txtBusinessCity.Text = null;
            txtBusinessState.Text = null;
            txtBusinessCode.Text = null;
            txtBusinessPhone.Text = null;
            txtBusinessExtension.Text = null;
            txtBusinessEmail.Text = null;

            gridBusinessOrders.DataSource = null;
        }

        private void _clearOrder()
        {
            cboOrderClient.SelectedIndex = 0;

            dateOrderOrderDate.Value = DateTime.Today;
            dateOrderDeliveryDate.Value = DateTime.Today;
            checkOrderIsDelivery.Checked = false;

            txtOrderRecipient.Text = null;
            txtOrderStreet.Text = null;
            txtOrderCity.Text = null;
            txtOrderState.Text = null;
            txtOrderZip.Text = null;
            txtOrderPhone.Text = null;
            txtOrderExtension.Text = null;
            txtOrderEmail.Text = null;
            txtOrderNumberLillies.Text = null;

            rtbOrderNoteText.Text = null;
        }

        #endregion

        #region Validation

        private bool _validateCustomer()
        {
            if ((txtCustomerFirstName.Text == "" || txtCustomerFirstName.Text == null) ||
                (txtCustomerLastName.Text == "" || txtCustomerLastName.Text == null))
            {
                _missingRequiredFieldsMessage();
                return false;
            }

            if ((txtCustomerEmail.Text != "" && txtCustomerEmail.Text != null) &&
                !StringHelpers.IsValidEmail(txtCustomerEmail.Text))
            {
                _invalidEmailMessage();
                return false;
            }

            return true;
        }

        private bool _validateBusiness()
        {
            if ((txtBusinessName.Text == "" || txtBusinessName.Text == null) ||
                (txtBusinessContact.Text == "" || txtBusinessContact.Text == null))
            {
                _missingRequiredFieldsMessage();
                return false;
            }

            if ((txtBusinessEmail.Text != "" && txtBusinessEmail.Text != null) &&
                !StringHelpers.IsValidEmail(txtBusinessEmail.Text))
            {
                _invalidEmailMessage();
                return false;   
            }

            return true;
        }

        private bool _validateOrder()
        {
            if (txtOrderNumberLillies.Text == "" || txtOrderNumberLillies.Text == null)
            {
                _missingRequiredFieldsMessage();
                return false;
            }

            if ((txtOrderEmail.Text != "" && txtOrderEmail.Text != null) &&
                !StringHelpers.IsValidEmail(txtOrderEmail.Text))
            {
                _invalidEmailMessage();
                return false;
            }

            return true;
        }

        #endregion

        #region ErrorMessages

        private void _missingRequiredFieldsMessage()
        {
            MetroFramework.MetroMessageBox.Show(this, "Missing required fields.");
        }

        private void _invalidEmailMessage()
        {
            MetroFramework.MetroMessageBox.Show(this, "Invalid email address format.");
        }

        #endregion

    }
}
