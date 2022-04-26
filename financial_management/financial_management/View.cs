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
    public partial class View : Form
    {
        public TransactionsModel model { get; set; }

        public View()
        {
            InitializeComponent();
        }


        private void Load_View(object sender, EventArgs e)
        {
            double TodayIncome = 0;
            double TodayExpense = 0;

            double WeekIncome = 0;
            double WeekExpense = 0;

            TransactionsModel transactionsModel = new TransactionsModel();
            TransactionDTO[] transactions = transactionsModel.LoadTransactionData();

            if (transactions != null)
            {

                foreach (TransactionDTO transactionDTO in transactions)
                {

                    if (transactionDTO.Date == DateTime.Today)
                    {
                        if (transactionDTO.Type.ToString() == "Income")
                        {
                            TodayIncome += double.Parse(transactionDTO.Amount.ToString());
                        }
                        else
                        {
                            TodayExpense += double.Parse(transactionDTO.Amount.ToString());
                        }
                    }

                    if (transactionDTO.Date >= DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek))
                    {
                        if (transactionDTO.Type.ToString() == "Income")
                        {
                            WeekIncome += double.Parse(transactionDTO.Amount.ToString());
                        }
                        else
                        {
                            WeekExpense += double.Parse(transactionDTO.Amount.ToString());
                        }
                    }

                }
            }

            lblDayExpense.Text = TodayExpense.ToString();
            lblDayIncome.Text = TodayIncome.ToString();
            lblWeekExpense.Text = WeekExpense.ToString();
            lblWeekIncome.Text = WeekIncome.ToString();
            LordRecentTransactions();
           // NextWeekPrediction();
        }

        public void LordRecentTransactions()
        {
            TransactionsModel transactionsModel = new TransactionsModel();
            ReportResponse reportResponse = transactionsModel.GetProgressDetails();



            if (reportResponse != null)
            {
                foreach (ReportDTO reportDTO in reportResponse.RecentTransactions)
                {
                    string[] s1 = new string[3];
                    s1[0] = reportDTO.Date;
                    s1[1] = reportDTO.Income;
                    s1[2] = reportDTO.Expense;

                    ListViewItem listItems = new ListViewItem(s1);
                    lstRecentTarnsaction.Items.Add(listItems);
                }
                lblNextIncome.Text = reportResponse.NextWeekIncome;
                lblNextExpense.Text = reportResponse.NextWeekExpense;
            }
            else
            {

                MessageBox.Show("Report generation failed. Please contact support team!", "Progress Report", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Close();
                return;
            }


           

        }

       

            public void NextWeekPrediction()
        {
            /*double totalNextWeekIncome = 0;
            double totalNextWeekExpense = 0;

            DataTable dTable = dbStore.Tables["TransactionsDb"];
            DataRow[] dataRows;

            double nextWeekIncome = 0;
            double nextWeekExpense = 0;

            // Get week befor last week total

            DateTime today = DateTime.Today;
            DateTime weekBeforLastWeekStart = DateTime.Today.AddDays(-(int)today.DayOfWeek - 14);
            DateTime weekBeforlastWeekEnd = DateTime.Today.AddDays(-(int)today.DayOfWeek -7);
            dataRows = dTable.Select("Date >= '" + weekBeforLastWeekStart + "' AND Date < '" + weekBeforlastWeekEnd + "'");
            foreach (DataRow row in dataRows)
            {
                if (row["Type"].ToString() == "Income")
                {
                    nextWeekIncome += double.Parse(row["Amount"].ToString());
                }
                else
                {
                    nextWeekExpense += double.Parse(row["Amount"].ToString());
                }
            }

            // Get last week total

           
            DateTime lastWeekStart = DateTime.Today.AddDays(-(int)today.DayOfWeek - 7);
            DateTime lastWeekEnd = DateTime.Today.AddDays(-(int)today.DayOfWeek);
            dataRows = dTable.Select("Date >= '" + lastWeekStart + "' AND Date < '" + lastWeekEnd + "'");
            foreach (DataRow row in dataRows)
            {
                if (row["Type"].ToString() == "Income")
                {
                    nextWeekIncome += double.Parse(row["Amount"].ToString());
                }
                else
                {
                    nextWeekExpense += double.Parse(row["Amount"].ToString());
                }
            }

            // get Avarage next week
            totalNextWeekIncome += nextWeekIncome / 2;
            totalNextWeekExpense += nextWeekExpense / 2;*/

            /*lblNextIncome.Text = totalNextWeekIncome.ToString();
            lblNextExpense.Text = totalNextWeekExpense.ToString();*/
            

        }

        private void lstRecentTarnsaction_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /*public void rangeTransactions() {

            //lstRecentTarnsaction.Items.Clear();
            DateTime rangeOne = DateTime.Parse(dtpTransDate1.Text);
            DateTime rangeTwo = DateTime.Parse(dtpTransDate2.Text);

            DataTable dTable = dbStore.Tables["TransactionsDb"];
            DataRow[] dataRows;

            double LoadTodayIncome = 0;
            double LoadTodayExpense = 0;

            dataRows = dTable.Select("Date >= '" + rangeOne + "' AND Date < '" + rangeTwo + "'");
            foreach (DataRow row in dataRows)
            {
                if (row["Type"].ToString() == "Income")
                {
                    LoadTodayIncome += double.Parse(row["Amount"].ToString());
                }
                else
                {
                    LoadTodayExpense += double.Parse(row["Amount"].ToString());
                }
            }

            lblDayExpense.Text = LoadTodayExpense.ToString();
            lblDayIncome.Text = LoadTodayIncome.ToString();
        }*/


    }
}
