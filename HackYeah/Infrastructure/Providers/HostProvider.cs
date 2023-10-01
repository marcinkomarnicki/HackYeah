namespace HackYeah.Infrastructure.Providers
{
    public class HostProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HostProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string Scheme
        {
            get
            {
                var scheme = _httpContextAccessor?.HttpContext?.Request?.Scheme.ToString()!;

                if (!scheme.EndsWith("s"))
                {
                    scheme = $"{scheme}s";
                }

                return scheme;
            }
        }

        public string Host => _httpContextAccessor?.HttpContext?.Request?.Host.ToString()!;
    }
}
