using financial_management.DataObjects;
using financial_management.DTO;
using financial_management.Global;
using financial_management.Models;
using financial_management.XMLBackup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace financial_management
{
    public partial class DashBordView : Form
    {
        public DashBordView()
        {
            InitializeComponent();
        }

        private void OpenTransactions(object sender, EventArgs e)
        {
            TransactionsView transactions = new TransactionsView();
            transactions.ShowDialog();
            transactions.Dispose();
        }

        private void OpenView(object sender, EventArgs e)
        {
            View view = new View();
            view.ShowDialog();
        }

        private void OpenCategory(object sender, EventArgs e)
        {
            Category category = new Category();
            category.ShowDialog();
        }

        private void Add_InitialData(object sender, EventArgs e)
        {
            SyncService syncService = new SyncService();
            syncService.IsWatingSyncTrue();

            backgroundWorker1.RunWorkerAsync();

            /*CategoryDTO categoryDTO = new CategoryDTO();
            categoryDTO.Name = "Education";
            CategoryModel categoryModel = new CategoryModel();
            categoryModel.CreateCategory(dbStore, categoryDTO);*/


        }

        private void Close_WindowsForm(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void LivenessCheck(object sender, DoWorkEventArgs e)
        {
            LivenessModel livenessModel = new LivenessModel();
            while (true)
            {
                bool status = livenessModel.GetServerStatus();
                Status.SetServerStatus(status);

                if (status)
                {
                    bool connected = Status.readyToConnect();
                    if (connected)
                    {

                        svrConnected.Text = "Connected";

                    }
                    else
                    {
                        svrConnected.Text = "Syncing Started";

                        SyncService syncService = new SyncService();
                        syncService.DeleteSyncState();

                       // Category Sync

                        CategoryModel categoryModel = new CategoryModel();
                        CategoryBackupService categoryBackupService = new CategoryBackupService();

                        CategoryDTO[] categories = categoryBackupService.GetAllCategories(null);

                        foreach (CategoryDTO categoryDTO in categories)
                        {

                            // Create
                            CategoryDTO catDTO = new CategoryDTO();
                            catDTO.Name = categoryDTO.Name;

                            categoryModel.CreateCategory(catDTO);
                        }

                        // Load latest server category

                        CategoryDTO[] serverCategories = categoryModel.GetCategories();
                        Dictionary<string, int> categoryList = new Dictionary<string, int>();
                        foreach (CategoryDTO category in serverCategories)
                        {
                            categoryList.Add(category.Name, category.Id);
                        }

                        // Transactions Sync
                        TransactionsModel transactionsModel = new TransactionsModel();
                        TransactionBackupService transactionBackupService = new TransactionBackupService();

                        TransactionDTO[] transactionDTOs = transactionBackupService.GetAllTransactions(null);

                        foreach (TransactionDTO transaction in transactionDTOs)
                        {
                            if (transaction.Id > 0)
                            {
                                // Update transaction
                                TransactionDTO transactionDTO = new TransactionDTO
                                {
                                    Id = transaction.Id,
                                    Name = transaction.Name,
                                    Type = transaction.Type,
                                    Amount = transaction.Amount,
                                    Date = transaction.Date,
                                    CategoryId = categoryList[transaction.Category.Name],
                                    Category = new CategoryDTO
                                    {
                                        Id = categoryList[transaction.Category.Name],
                                        Name = transaction.Category.Name
                                    },

                                    IsRepete = transaction.IsRepete
                                };
                                transactionsModel.UpdateTransaction(transactionDTO, transaction.Id);
                            }
                            else
                            {
                                // Create transaction
                                TransactionDTO transactionDTO = new TransactionDTO
                                {
                                    Name = transaction.Name,
                                    Type = transaction.Type,
                                    Amount = transaction.Amount,
                                    Date = transaction.Date,
                                    CategoryId = categoryList[transaction.Category.Name],
                                    IsRepete = transaction.IsRepete
                                };
                                transactionsModel.SaveTransaction(transactionDTO);
                            }
                        }

                        // deleted transactions using server
                        int[] deletedTransactionIds = transactionBackupService.GetDeletedTransactions();
                        if (deletedTransactionIds != null)
                        {
                            foreach (int transactionId in deletedTransactionIds)
                            {
                                transactionsModel.DeleteTransaction(transactionId);
                            }
                        }

                    }
                }
                else
                {
                    svrConnected.Text = "Lost Connection";
                }

                Thread.Sleep(5000);

            }
        }
    }
}
