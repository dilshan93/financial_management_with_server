 using financial_management.DataObjects;
using financial_management.Global;
using financial_management.Response;
using financial_management.XMLBackup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace financial_management.Models
{
    public class TransactionsModel
    {

        TransactionBackupService transactionBackup = new TransactionBackupService();
        SyncService syncService = new SyncService();

        public TransactionResponse SaveTransaction(TransactionDTO transactionDTO) {

            TransactionResponse response = new TransactionResponse();

            if (Status.IsConnected())
            {

            try
            {
                using (var server = new HttpClient())
                {
                    server.BaseAddress = new Uri(Status.endpointURL);
                    var responseData = server.PostAsJsonAsync<TransactionDTO>("transaction/create", transactionDTO);
                    responseData.Wait();

                    var result = responseData.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readData = result.Content.ReadAsAsync<TransactionResponse>();
                        readData.Wait();

                        response = readData.Result;
                        transactionBackup.CreateTransaction(transactionDTO);
                       // return response;
                    }
                }
            }
            catch (Exception ex)
            {
               syncService.SaveWatingSyncState();
               transactionDTO.Id = Status.GetTransactionId();
               response = transactionBackup.CreateTransaction(transactionDTO);
                
            }

            }
            else
            {
                syncService.SaveWatingSyncState();
                transactionDTO.Id = Status.GetTransactionId();
                response = transactionBackup.CreateTransaction(transactionDTO);
            }
            return response;

        }

        public TransactionDTO[] LoadTransactionData()
        {

            TransactionDTO[] transactions = null;

            if (Status.IsConnected())
            {

            try
            {
                using (var server = new HttpClient())
                {
                    server.BaseAddress = new Uri(Status.endpointURL);
                    var responseData = server.GetAsync("transaction");
                    responseData.Wait();

                    var result = responseData.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readData = result.Content.ReadAsAsync<AllTransactionResponse>();
                        readData.Wait();

                        var response = readData.Result;
                        transactions = response.ReturnResponse;
                        transactionBackup.GetAllTransactions(transactions);
                    }
                }
            }
            catch (Exception ex)
            {
                transactions = transactionBackup.GetAllTransactions(null);
            }

            }
            else
            {
                transactions = transactionBackup.GetAllTransactions(null);
            }


            return transactions;
        }

        public TransactionDTO LoadTransactionDataById(int id)
        {

            TransactionDTO transactions = null;

            if (Status.IsConnected())
            {

            try
            {
                using (var server = new HttpClient())
                {
                    server.BaseAddress = new Uri(Status.endpointURL);
                    var responseData = server.GetAsync("transaction/getId?id=" + id);
                    responseData.Wait();

                    var result = responseData.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readData = result.Content.ReadAsAsync<TransactionResponse>();
                        readData.Wait();

                        var response = readData.Result;
                        transactions = response.ReturnResponse;
                    }
                }
            }
            catch (Exception ex)
            {
                    transactions = transactionBackup.GetTransactionByID(id);
                }

            }
            else
            {
                transactions = transactionBackup.GetTransactionByID(id);
            }


            return transactions;
        }



        public TransactionResponse UpdateTransaction(TransactionDTO transactionDTO, int id)
        {

            TransactionResponse transactions = null;
            if (Status.IsConnected())
            {

            try
            {
                using (var server = new HttpClient())
                {
                    server.BaseAddress = new Uri(Status.endpointURL);
                    var responseData = server.PostAsJsonAsync<TransactionDTO>("transaction/update?id=" + id, transactionDTO);
                    responseData.Wait();

                    var result = responseData.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readData = result.Content.ReadAsAsync<TransactionResponse>();
                        readData.Wait();

                        transactions = readData.Result;
                        transactionBackup.EditTransaction(transactionDTO, id);
                        return transactions;
                    }
                }
            }
            catch (Exception ex)
            {
                    syncService.SaveWatingSyncState();
                    transactions = transactionBackup.EditTransaction(transactionDTO, id);
                
            }

            }
            else
            {
                syncService.SaveWatingSyncState();
                transactions = transactionBackup.EditTransaction(transactionDTO, id);
            }


            return transactions;
        }

        public TransactionResponse DeleteTransaction(int id)
        {
                TransactionResponse response = new TransactionResponse();

            if (Status.IsConnected())
            {
            try
            {
                using (var server = new HttpClient())
                {
                    server.BaseAddress = new Uri(Status.endpointURL);
                    var responseData = server.DeleteAsync("transaction?id=" + id);
                    responseData.Wait();

                    var result = responseData.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readData = result.Content.ReadAsAsync<TransactionResponse>();
                        readData.Wait();

                        response = readData.Result;
                        transactionBackup.DeleteTransaction(id);
                        }
                }
            }
            catch (Exception ex)
            {
                    syncService.SaveWatingSyncState();
                    response = transactionBackup.DeleteTransaction(id);
            }

            }
            else
            {
                syncService.SaveWatingSyncState();
                response = transactionBackup.DeleteTransaction(id);
            }
            return response;
        }

        public ReportResponse GetProgressDetails()
        {
            ReportResponse response = new ReportResponse();
            try
            {
                using (var server = new HttpClient())
                {
                    server.BaseAddress = new Uri(Status.endpointURL);
                    var responseData = server.GetAsync("transaction/getAllReportrs");
                    responseData.Wait();

                    var result = responseData.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readData = result.Content.ReadAsAsync<ReportResponse>();
                        readData.Wait();

                        response = readData.Result;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return response;
        }

    }
}
