namespace HackYeah.Infrastructure.Providers
{
    public class HostProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HostProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string Scheme => _httpContextAccessor?.HttpContext?.Request?.Scheme.ToString()!;

        public string Host => _httpContextAccessor?.HttpContext?.Request?.Host.ToString()!;
    }
}
