using financial_management_service.DTO;
using financial_management_service.Repositories;
using financial_management_service.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace financial_management_service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ILogger<TransactionController> _logger;
        private readonly ApplicationDbContext applicationDbContext;

        public TransactionController(ILogger<TransactionController> logger, ApplicationDbContext applicationDbContext1)
        {
            _logger = logger;
            applicationDbContext = applicationDbContext1;
        }
        // GET: TransactionsList
        [HttpGet]
        public GenaralResponse Index()
        {
            GenaralResponse response = new GenaralResponse();

            IEnumerable<Category> categories = applicationDbContext.Categories.ToList();
            IEnumerable<Transaction> transactions = applicationDbContext.Transactions.ToList();
            foreach (Category category in categories)
            {
                category.Transactions = null;
            }
            response.Sucess = true;
            response.Discription = "Found all transactions !";
            response.ReturnResponse = transactions;
            return response;
        }

        // POST: transaction/create
        [HttpPost("create")]
        public GenaralResponse Create([FromBody] Transaction formBody)
        {
            GenaralResponse response = new GenaralResponse();
            applicationDbContext.Transactions.Add(formBody);
            applicationDbContext.SaveChanges();

            response.Sucess = true;
            response.Discription = "Successfully Added New Transactions !";
            return response;
        }

        // GET: transactions/getId?id=1
        [HttpGet("getId")]
        public GenaralResponse GetById(int id)
        {
            GenaralResponse response = new GenaralResponse();
            Transaction trans = applicationDbContext.Transactions.FirstOrDefault(tran => tran.Id == id);
            Category cate = applicationDbContext.Categories.FirstOrDefault(cat => cat.Id == trans.CategoryId);
            trans.Category.Transactions = null;

            if (trans != null)
            {
                response.Sucess = true;
                response.Discription = "Successfully retrived Transaction";
                response.ReturnResponse = trans;
            }
            else 
            {

                response.Sucess = false;
                response.Discription = "Transaction not found";
            }

            return response;
        }

        // POST: transaction/update?id=x
        [HttpPost("update")]
        public GenaralResponse Edit(int id, [FromBody] Transaction formBody)
        {
            GenaralResponse response = new GenaralResponse();
            var trans = applicationDbContext.Transactions.FirstOrDefault(x => x.Id == id);
            formBody.Id = id;
            if (trans != null)
            {
               
                applicationDbContext.Entry(trans).CurrentValues.SetValues(formBody);
                applicationDbContext.SaveChanges();

                response.Sucess = true;
                response.Discription = "Transaction successfully updated !";
            }
            else
            {
                response.Sucess = false;
                response.Discription = "Error Updating Transaction";
            }
            return response;
        }

        // POST: transaction?id=x
        [HttpDelete]
        public GenaralResponse Delete(int id)
        {
            GenaralResponse response = new GenaralResponse();
            var trans= applicationDbContext.Transactions.FirstOrDefault(x => x.Id == id);
            if (trans != null)
            {
                applicationDbContext.Remove(trans);
                applicationDbContext.SaveChanges();

                response.Sucess = true;
                response.Discription = "successfully deleted Transaction!";
            }
            else
            {
                response.Sucess = false;
                response.Discription = "Error while deleteing Transaction";
            }
            return response;
        }

        // GET: transaction/details?id=1
        [HttpGet("getAllReportrs")]
        public ProgressReportRes GetAllReportrs()
        {
            ProgressReportRes response = new ProgressReportRes();

            List<Transaction> transactions;

            response.RecentTransactions = new List<RecentTransaction>();

            for (int i = 0; i < 7; i++)
            {
                double loadTodayIncome = 0;
                double loadTodayExpense = 0;
                transactions = applicationDbContext.Transactions.Where(a => a.Date == DateTime.Today.AddDays(-1 * i)).ToList();

                foreach (Transaction trans in transactions)
                {
                    if (trans.Type == "Expense")
                    {
                        loadTodayExpense += trans.Amount;
                    }
                    else
                    {
                        loadTodayIncome += trans.Amount;
                    }
                }
                RecentTransaction recentTransaction = new RecentTransaction();
                recentTransaction.Date = DateTime.Today.AddDays(-1 * i).ToString();
                recentTransaction.Expense = loadTodayExpense.ToString();
                recentTransaction.Income = loadTodayIncome.ToString();

                response.RecentTransactions.Add(recentTransaction);
            }


                double totalNextWeekIncome = 0;
                double totalNextWeekExpense = 0;

                // Get total recurring
                transactions = applicationDbContext.Transactions.Where(x => x.IsRepete == true).ToList();
                foreach (Transaction trans in transactions)
                {
                    if (trans.Type == "Expense")
                    {
                        totalNextWeekExpense += trans.Amount;
                    }
                    else
                    {
                        totalNextWeekIncome += trans.Amount;
                    }
                }

                // Get week befor last week total non-repete

                double nextWeekIncome = 0;
                double nextWeekExpense = 0;

                DateTime today = DateTime.Today;
                DateTime weekBeforLastWeekStart = DateTime.Today.AddDays(-(int)today.DayOfWeek - 14);
                DateTime weekBeforlastWeekEnd = DateTime.Today.AddDays(-(int)today.DayOfWeek - 7);
                transactions = applicationDbContext.Transactions.Where(x => x.IsRepete == false)
                    .Where(x => x.Date >= weekBeforLastWeekStart)
                    .Where(x => x.Date < weekBeforlastWeekEnd).ToList();
                foreach (Transaction trans in transactions)
                {
                    if (trans.Type == "Expense")
                    {
                        nextWeekExpense += trans.Amount;
                    }
                    else
                    {
                        nextWeekIncome += trans.Amount;
                    }
                }

                // Get last week total non-repete

                DateTime lastWeekStart = DateTime.Today.AddDays(-(int)today.DayOfWeek - 7);
                DateTime lastWeekEnd = DateTime.Today.AddDays(-(int)today.DayOfWeek);
                transactions = applicationDbContext.Transactions.Where(x => x.IsRepete == false)
                    .Where(x => x.Date >= lastWeekStart)
                    .Where(x => x.Date < lastWeekEnd).ToList();
                foreach (Transaction trans in transactions)
                {
                    if (trans.Type == "Expense")
                    {
                        nextWeekExpense += trans.Amount;
                    }
                    else
                    {
                        nextWeekIncome += trans.Amount;
                    }
                }

                // get Avarage next week
                totalNextWeekIncome += nextWeekIncome / 2;
                totalNextWeekExpense += nextWeekExpense / 2;

            response.NextWeekExpense = totalNextWeekExpense.ToString();
            response.NextWeekIncome = totalNextWeekIncome.ToString();


            response.Sucess = true;
            response.Discription = "successfully deleted Transaction!";
            return response;
        }
    }
}
