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
    public partial class Transactions : Form
    {

        Dictionary<String, CategoryDTO> categoryByName = new Dictionary<String, CategoryDTO>();
        public Transactions()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
          //  label1.Text = Format
        }

        private void Load_Categories(object sender, EventArgs e)
        {
            // Load categories

            CategoryModel categoryModel = new CategoryModel();
            foreach (CategoryDTO categoryDTO in categoryModel.GetCategories())
            {
                comTransCategory.Items.Add(categoryDTO.Name);
                categoryByName.Add(categoryDTO.Name, categoryDTO);
            };
        }

        private void Submit_Transaction(object sender, EventArgs e)
        {
            string name = txtTransName.Text;
            string amount = txtTransAmount.Text;

            if (name == null || amount == "" || comTransCategory.SelectedIndex == -1 || comTransType.SelectedIndex == -1)
            {
                MessageBox.Show("Some fields are empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Create new transaction object
            TransactionDTO transactionDTO = new TransactionDTO();
            transactionDTO.Name = name;
            transactionDTO.Amount = double.Parse(amount);
            transactionDTO.Date = DateTime.Parse(dtpTransDate.Text);
            transactionDTO.Type = comTransType.Text;
            transactionDTO.IsRepete = chkWeekly.Checked;
            transactionDTO.CategoryId = categoryByName[comTransCategory.Text].Id;

            TransactionsModel transactionsModel = new TransactionsModel();
            TransactionResponse result = transactionsModel.SaveTransaction(transactionDTO);
            if (result != null)
            {
                if (result.Sucess == true)
                {
                    MessageBox.Show(result.Discription, "Transaction", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show(result.Discription, "Transaction", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Close();
                }
            }

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
