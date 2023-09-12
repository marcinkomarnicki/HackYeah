namespace HackYeah.Infrastructure.Providers
{
    public class CurrentUserProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string? UserName => _httpContextAccessor.HttpContext?.User?.Identity?.Name;
    }
}
