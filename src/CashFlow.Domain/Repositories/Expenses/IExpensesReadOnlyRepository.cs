using CashFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Domain.Repositories.Expenses
{
    public interface IExpensesReadOnlyRepository
    {
        Task<List<Expense>> GetAll(Entities.User user);
        Task<Expense?> GetById(Entities.User user, long id);
    }
}
