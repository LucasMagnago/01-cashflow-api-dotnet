using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Infrastructure.DataAccess.Repositories
{
    internal class ExpensesRepository : IExpensesRepository
    {
        public void Add(Expense expense)
        {
            var dbContext = new CashFlowDbContext();

            dbContext.Expenses.Add(expense);
            dbContext.SaveChanges();
        }
    }
}
