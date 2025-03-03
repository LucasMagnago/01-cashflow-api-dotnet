using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Exception.ExceptionsBase
{
    public class InvalidLoginException : CashFlowException
    {
        public override int StatusCode => (int)HttpStatusCode.Unauthorized;

        public InvalidLoginException() : base("E-mail e/ou senha inválidos.")
        {
        }

        public override List<string> GetErrors()
        {
            return [Message];
        }
    }
}
