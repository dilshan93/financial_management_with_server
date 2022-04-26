using financial_management.DataObjects;
using financial_management.DTO;
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
    public partial class UpdateTransactions : Form
    {
        Dictionary<String, CategoryDTO> categoryByName = new Dictionary<String, CategoryDTO>();
        int transId;
        public UpdateTransactions(int id)
        {
            InitializeComponent();
            this.transId = id;
        }

        private void UpdateTransactions_Load(object sender, EventArgs e)
        {
            // Load_categories
            CategoryModel categoryModel = new CategoryModel();
            foreach (CategoryDTO categoryDTO in categoryModel.GetCategories())
            {
                comTransCategory.Items.Add(categoryDTO.Name);
                categoryByName.Add(categoryDTO.Name, categoryDTO);
            };

            // Load_transaction
            TransactionsModel transactionsModel = new TransactionsModel();

            TransactionDTO transactionDTO = transactionsModel.LoadTransactionDataById(transId);

            txtTransName.Text = transactionDTO.Name;
            comTransType.Text = transactionDTO.Type.ToString();
            txtTransAmount.Text = transactionDTO.Amount.ToString();
            comTransCategory.Text = transactionDTO.Category.Name;
            chkWeekly.Checked = transactionDTO.IsRepete;
            dtpTransDate.Value = transactionDTO.Date;
        }

        private void Update_Transaction(object sender, EventArgs e)
        {
            string name = txtTransName.Text;
            string amount = txtTransAmount.Text;

            if (name == null || amount == "" || comTransCategory.SelectedIndex == -1 || comTransType.SelectedIndex == -1)
            {
                MessageBox.Show("Some fields are empty!", "Transaction", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Update transaction object
            TransactionDTO transactionDTO = new TransactionDTO();
            transactionDTO.Name = name;
            transactionDTO.Amount = double.Parse(amount);
            transactionDTO.Date = DateTime.Parse(dtpTransDate.Text);
            transactionDTO.Type = comTransType.Text;
            transactionDTO.IsRepete = chkWeekly.Checked;
            transactionDTO.CategoryId = categoryByName[comTransCategory.Text].Id;

            TransactionsModel transactionsModel = new TransactionsModel();
            TransactionResponse transactionResponse = transactionsModel.UpdateTransaction(transactionDTO, transId);
            if (transactionResponse != null)
            {

                MessageBox.Show(transactionResponse.Discription, "Transaction", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Close();
        }

        private void ValidateAmountFeild(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
