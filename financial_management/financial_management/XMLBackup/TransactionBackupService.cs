using financial_management.DataObjects;
using financial_management.DTO;
using financial_management.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace financial_management.XMLBackup
{
    internal class TransactionBackupService
    {

        public TransactionDTO[] GetAllTransactions(TransactionDTO[] transactions)
        {
            if (transactions != null)
            {
                var xmlData = XElement.Load("C:/Users/scit/source/repos/Cw2_w1850877/financial_management/financial_management/Backup.xml");
                var transXml = transactions.ToList().Select(x => new XElement("Transaction", new XAttribute("Id", x.Id),
                                        new XAttribute("Name", x.Name),
                                        new XAttribute("Type", x.Type),
                                        new XAttribute("Amount", x.Amount),
                                        new XAttribute("Date", x.Date),
                                        new XAttribute("CategoryId", x.CategoryId),
                                        new XElement("CategoryTransaction", new XAttribute("Id", x.Category.Id),
                                        new XAttribute("Name", x.Category.Name)),
                                        new XAttribute("IsRepete", x.IsRepete))).ToList();
                xmlData.Descendants("Transactions").Remove();
                xmlData.Add(new XElement("Transactions", transXml));
                xmlData.Save("C:/Users/scit/source/repos/Cw2_w1850877/financial_management/financial_management/Backup.xml");
            }
            else
            {
                var xmlData = XElement.Load("C:/Users/scit/source/repos/Cw2_w1850877/financial_management/financial_management/Backup.xml");
                transactions = xmlData.Descendants("Transaction").Select(x => new TransactionDTO
                    {
                        Id = int.Parse(x.Attribute("Id").Value.ToString()),
                        Name = x.Attribute("Name").Value,
                        Type = x.Attribute("Type").Value,
                        Amount = double.Parse(x.Attribute("Amount").Value),
                        Date = DateTime.Parse(x.Attribute("Date").Value),
                        CategoryId = int.Parse(x.Attribute("CategoryId").Value.ToString()),
                        Category = new CategoryDTO
                        {
                            Id = int.Parse(x.Element("CategoryTransaction").Attribute("Id").Value.ToString()),
                            Name = x.Element("CategoryTransaction").Attribute("Name").Value
                        },
                        IsRepete = bool.Parse(x.Attribute("IsRepete").Value)}).ToArray();
            }

            return transactions;
        }

        public TransactionDTO GetTransactionByID(int id)
        {
            TransactionDTO transaction = null;

            var xmlData = XElement.Load("C:/Users/scit/source/repos/Cw2_w1850877/financial_management/financial_management/Backup.xml");
            transaction = xmlData.Descendants("Transaction").Where(x => int.Parse(x.Attribute("Id").Value) == id).Select(x => new TransactionDTO
                {
                    Id = int.Parse(x.Attribute("Id").Value.ToString()),
                    Name = x.Attribute("Name").Value,
                    Type = x.Attribute("Type").Value,
                    Amount = double.Parse(x.Attribute("Amount").Value),
                    Date = DateTime.Parse(x.Attribute("Date").Value),
                    CategoryId = int.Parse(x.Attribute("CategoryId").Value.ToString()),
                    Category = new CategoryDTO
                    {
                        Id = int.Parse(x.Element("CategoryTransaction").Attribute("Id").Value.ToString()),
                        Name = x.Element("CategoryTransaction").Attribute("Name").Value
                    },
                    IsRepete = bool.Parse(x.Attribute("IsRepete").Value)
                }).FirstOrDefault();

            return transaction;
        }

        public TransactionResponse CreateTransaction(TransactionDTO transaction)
        {
            TransactionResponse response = new TransactionResponse();
            var xmlData = XElement.Load("C:/Users/scit/source/repos/Cw2_w1850877/financial_management/financial_management/Backup.xml");
            CategoryDTO category = xmlData.Descendants("Category").Where(x => int.Parse(x.Attribute("Id").Value) == transaction.CategoryId).Select(x => new CategoryDTO
                {
                    Id = int.Parse(x.Attribute("Id").Value.ToString()),
                    Name = x.Attribute("Name").Value
                }).FirstOrDefault();

            xmlData.Add(new XElement("Transactions", new XElement("Transaction", new XAttribute("Id", transaction.Id),
                                        new XAttribute("Name", transaction.Name),
                                        new XAttribute("Type", transaction.Type),
                                        new XAttribute("Amount", transaction.Amount),
                                        new XAttribute("Date", transaction.Date),
                                        new XAttribute("CategoryId", transaction.CategoryId),
                                        new XElement("CategoryTransaction", new XAttribute("Id", category.Id),
                                        new XAttribute("Name", category.Name)),
                                        new XAttribute("IsRepete", transaction.IsRepete))));
            xmlData.Save("C:/Users/scit/source/repos/Cw2_w1850877/financial_management/financial_management/Backup.xml");
            response.Sucess = true;
            response.Discription = "Successfully Added New Transaction!";

            return response;
        }

        public TransactionResponse EditTransaction(TransactionDTO transaction, int id)
        {
            TransactionResponse response = new TransactionResponse();
            var xmlData = XElement.Load("C:/Users/scit/source/repos/Cw2_w1850877/financial_management/financial_management/Backup.xml");
            var data = xmlData.Descendants("Transaction").Where(x => int.Parse(x.Attribute("Id").Value) == id).First();

            data.Attribute("Name").Value = transaction.Name;
            data.Attribute("Type").Value = transaction.Type;
            data.Attribute("Amount").Value = transaction.Amount.ToString();
            data.Attribute("Date").Value = transaction.Date.ToString();
            data.Attribute("CategoryId").Value = transaction.CategoryId.ToString();
            data.Descendants("CategoryTransaction").Remove();
            data.Add(new XElement("CategoryTransaction", new XAttribute("Id", transaction.Category.Id),
                                        new XAttribute("Name", transaction.Category.Name)));

            data.Attribute("IsRepete").Value = transaction.IsRepete.ToString();
            xmlData.Save("C:/Users/scit/source/repos/Cw2_w1850877/financial_management/financial_management/Backup.xml");

            response.Sucess = true;
            response.Discription = "Transaction successfully updated!";

            return response;
        }

        public TransactionResponse DeleteTransaction(int id)
        {
            TransactionResponse response = new TransactionResponse();
            var xmlData = XElement.Load("C:/Users/scit/source/repos/Cw2_w1850877/financial_management/financial_management/Backup.xml");
            xmlData.Descendants("Transaction").Where(x => int.Parse(x.Attribute("Id").Value) == id).Remove();

            // Need to remember server fetched transactions only
            if (id > 0)
            {
                xmlData.Add("Deleteted", new XElement("DeletedTransaction"), new XAttribute("Id", id));
            }

            response.Sucess = true;
            response.Discription = "successfully deleted Transaction!";
            return response;
        }

        public int[] GetDeletedTransactions()
        {
            int[] deletedTransactions;

            var xmlData = XElement.Load("C:/Users/scit/source/repos/Cw2_w1850877/financial_management/financial_management/Backup.xml");
            deletedTransactions = xmlData.Descendants("DeletedTransaction").Select(x => int.Parse(x.Attribute("Id").ToString())).ToArray();

            return deletedTransactions;
        }
    }
}
