using financial_management.DataObjects;
using financial_management.Models;
using financial_management.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace financial_management
{
    public partial class TransactionsView : Form
    {
        public TransactionsView()
        {
            InitializeComponent();
        }

        private void OpenTransaction_Save(object sender, EventArgs e)
        {
            Transactions transactions = new Transactions();
            transactions.ShowDialog();
            RefreshTransactionData();
        }

        private void Lorad_Transactions(object sender, EventArgs e)
        {
            RefreshTransactionData();
        }

        public void RefreshTransactionData()
        {
            TransactionsModel transactionsModel = new TransactionsModel();
            lsTransactions.Items.Clear();
            TransactionDTO[] transactions = transactionsModel.LoadTransactionData();

            if (transactions != null) 
            {

                foreach (TransactionDTO transactionDTO in transactions)
                {

                    string[] items = new string[6];
                    items[0] = transactionDTO.Id.ToString();
                    items[1] = transactionDTO.Date.ToString("d");
                    items[2] = transactionDTO.Name.ToString();
                    items[3] = transactionDTO.Type.ToString();
                    items[4] = transactionDTO.Category.Name.ToString();
                    items[5] = transactionDTO.Amount.ToString();

                    ListViewItem listViewItem = new ListViewItem(items);
                    lsTransactions.Items.Add(listViewItem);

                }
            }
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

        }

        private void Update_Transactions(object sender, EventArgs e)
        {
            int id = int.Parse(lsTransactions.SelectedItems[0].SubItems[0].Text);
            UpdateTransactions updateTransactions = new UpdateTransactions(id);
            updateTransactions.ShowDialog();
            updateTransactions.Dispose();
            RefreshTransactionData();
        }

        private void Enabled_Selected(object sender, EventArgs e)
        {
            if (lsTransactions.SelectedItems.Count == 1)
            {
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void Remove_Transaction(object sender, EventArgs e)
        {

            int id = int.Parse(lsTransactions.SelectedItems[0].SubItems[0].Text);
            if (id > 0)
            {
                TransactionsModel transactionsModel = new TransactionsModel();
                TransactionResponse result = transactionsModel.DeleteTransaction(id);
                if (result != null)
                {
                    MessageBox.Show(result.Discription, "Transaction", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                
                RefreshTransactionData();
            }
            
        }
    }
}
