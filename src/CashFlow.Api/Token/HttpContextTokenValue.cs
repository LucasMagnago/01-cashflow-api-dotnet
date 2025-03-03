using CashFlow.Domain.Security.Tokens;

namespace CashFlow.Api.Token
{
    public class HttpContextTokenValue : ITokenProvider
    {
        private readonly HttpContextAccessor _httpContextAccessor;

        public HttpContextTokenValue(HttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string TokenOnRequest()
        {
            var authorization = _httpContextAccessor.HttpContext!.Request.Headers.Authorization.ToString();

            return authorization.Replace("Bearer ", string.Empty);
        }
    }
}
