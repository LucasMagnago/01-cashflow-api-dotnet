using CashFlow.Domain.Repositories.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Infrastructure.DataAccess.Repositories
{
    internal class UserRepository : IUserReadOnlyRepository
    {
        private readonly CashFlowDbContext _context;   

        public UserRepository(CashFlowDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ExistActiveUserWithEmail(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email.Equals(email));
        }
    }
}
